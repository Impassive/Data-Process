using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyImage.Source
{
    public static class Filters
    {
        public static List<double> _LPF_Filter(double fcut, int m, double dt)
        {
            List<double> lpw = new List<double>();
            //прямоугольник
            double[] d = { 0.35577019, 0.2436983, 0.07211497, 0.00630165 };
            double arg = 2 * fcut * dt;
            lpw.Add(arg);
            arg *= Math.PI;

            for (int i = 1; i <= m; i++)
            {
                lpw.Add(Math.Sin(arg * i) / (Math.PI * i));
            }
            //трапеция
            lpw[m] /= 2;

            //окно P310 (Поттера)
            double sumg = lpw[0];
            double sum = 0;
            for (int i = 1; i <= m; i++)
            {
                sum = d[0];
                arg = Math.PI * i / m;
                for (int k = 1; k <= 3; k++)
                    sum += 2 * d[k] * Math.Cos(arg * k);
                lpw[i] *= sum;
                sumg += 2 * lpw[i];
            }
            //нормировка
            for (int i = 0; i <= m; i++)
                lpw[i] /= sumg;
            //зеркально отразить график, сдвинуть, чтобы был от 0 до 2m+1
            List<double> total_lpw = new List<double>();
            lpw.Reverse();
            total_lpw.AddRange(lpw);
            total_lpw.RemoveAt(total_lpw.Count - 1);
            lpw.Reverse();
            total_lpw.AddRange(lpw);
            return total_lpw;
        }

        public static double[][] LPF(double[][] source, double fcut, int m, double dt)
        {
            List<double> lpw_lpf = _LPF_Filter(fcut, m, dt);

            for (int j = 0; j < source.Length; j++)
            {
                int n = source[j].Length;
                double[] y = new double[n];
                for (int i = 0; i < n; i++)
                    y[i] = source[j][i];
                double[] res = new double[n + m];

                for (int k = 0; k < res.Length; k++)
                {
                    double yk = 0;
                    for (int l = 0; l < lpw_lpf.Count; l++)
                    {
                        if ((k - l < 0) || (k - l >= n))
                        { }
                        else
                        {
                            yk += y[k - l] * lpw_lpf[l];
                        }
                    }
                    res[k] = yk;
                }
                for (int i = 0; i < n; i++)
                    source[j][i] = res[i + m];
            }
            return source;
        }


        //гребенчатый фильтр
        public static double[] CombFilter(double[] x, double g, int M)
        {
            double[] y = new double[x.Length];
            for (int i = 0; i < M; i++)
            {
                y[i] = x[i];
            }
            for (int i = M; i < x.Length; i++)
            {
                y[i] = x[i] - g * y[i - M];

            }

            return y;
        }

        /// <summary>
        /// 
        ///универсальный  фильтр позволяет  реализовать гребенчатый фильтр, фазовый фильтр, delay фильр
        ///        
        /// Представляет собой фазовый фильтр с оператором  задержки на M сэмплов. и дополнительным множителем FF.
        /// FIR Comb - гребенчатый, в котором задержанный сигнал добавляется к входному с каким-то коэфициентом FF.
        /// IIR Comb - входной сигнал циркулирует в задерживаемой строке, которая потом снова складывается с входным сигналом.
        /// перед каждым сложением - уменьшение c коэф FB (циклично)
        /// 
        /// Allpass - BL - a , FB -a FF 1.
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="BL">blend 1 если гребенчатый , FB(a) если Allpass</param>
        /// <param name="FF">feedforward g  если FIR, 0 если IIR, 1 если allpass или delay</param>
        /// <param name="FB">feedbackward g если  IIR  -a если allpass, иначе 0</param>
        /// <param name="M">задержка</param>
        /// <returns></returns>
        public static double[] UniversalCombFilter(double[] x, double BL, double FB, double FF, int M)
        {
            /*BL = 0.5;
            FB = -0.5;
            FF = 1;
            M = 10;*/

            double[] y = new double[x.Length];
            double xh;
            Queue<double> delayLine = new Queue<double>();

            for (int i = 0; i < M; i++)
            {

                delayLine.Enqueue(0.0);
            }
            for (int i = 0; i < x.Length; i++)
            {
                xh = x[i] + FB * delayLine.Peek();
                y[i] = FF * delayLine.Peek() + BL * xh;
                delayLine.Dequeue();
                delayLine.Enqueue(xh);
            }
            return y;
        }

        public static double[] Normalize(double[] x)
        {
            double min = x.Min();
            double max = x.Max();
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = (x[i] / (max - min));
            }
            return x;
        }

        /// <summary>
        /// Фильтр шрёдера
        /// </summary>
        /// <param name="x">входной сигнал</param>
        /// <param name="cg">массив потерь для гребенчатых фильтров</param>
        /// <param name="cd">массив задержек для гребенчатых сильтров</param>
        /// <param name="ag">массив потерь для фазовых фильтров</param>
        /// <param name="ad">массив задержек для фазовых фильров</param>
        /// <param name="k">ослабление для оригинального вектора</param>
        /// <returns></returns>
        public static double[] ShroederFilter(double[] x, double[] cg, int[] cd, double ag, int[] ad, double k)
        {
            double[][] cbres = new double[cg.Length][];
            for (int i = 0; i < cg.Length; i++)
            {
                cbres[i] = UniversalCombFilter(x, 1, cg[i], 0, cd[i]);
            }
            double[] combres = new double[cbres[0].Length];
            for (int i = 0; i < combres.Length; i++)
            {
                for (int j = 0; j < cbres.Length; j++)
                {
                    combres[i] += cbres[j][i];
                }
            }
            double[] res = combres;
            for (int i = 0; i < ad.Length; i++)
            {
                res = UniversalCombFilter(res, ag, -ag, 1, ad[0]);
            }
            for (int i = 0; i < x.Length; i++)
            {
                res[i] += k * x[i];
            }

            return Normalize(res);
        }

        public static double[][] AvgFilter(double[][] source, int maskWidth)
        {
            double[][] result = new double[source.Length][];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = new double[source[i].Length];
                for (int j = 0; j < source[i].Length; j++)
                {
                    int maxMi = (int)maskWidth / 2;
                    int maxMj = (int)maskWidth / 2;
                    double[][] range = source.Skip(i - maxMi).Take(i >= maxMi ? maskWidth : i + maxMi + 1)
                        .Select(x => x.Skip(j - maxMj).Take(j >= maxMj ? maskWidth : j + maxMj + 1).ToArray())
                        .ToArray();
                    double avg = range.SelectMany(x => x).Average();
                    result[i][j] = avg;
                }
            }
            return result;
        }

        public static double[][] MedianFilter(double[][] source, int maskWidth)
        {
            double[][] result = new double[source.Length][];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = new double[source[i].Length];
                for (int j = 0; j < source[i].Length; j++)
                {
                    int maxMi = (int)maskWidth / 2;
                    int maxMj = (int)maskWidth / 2;
                    double[][] range = source.Skip(i - maxMi).Take(i >= maxMi ? maskWidth : i + maxMi + 1)
                        .Select(x => x.Skip(j - maxMj).Take(j >= maxMj ? maskWidth : j + maxMj + 1).ToArray())
                        .ToArray();

                    double[] values = range.SelectMany(x => x).OrderBy(x => x).ToArray();
                    result[i][j] = values[values.Length / 2];
                }
            }
            return result;
        }

    }
}
