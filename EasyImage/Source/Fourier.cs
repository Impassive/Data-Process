using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;

namespace EasyImage.Source
{
    public static class Fourier
    {

        public static void Draw(Chart chart, double[] data, SeriesChartType chartType, string functionName = "Fourier")
        {
            double dt = mainForm.dt;
            chart.Series.Clear();
            Series series = chart.Series.Add(functionName);
            series.ChartType = chartType;
            series.ChartArea = functionName;

            //Теорема Котельникова:
            //Если частота замеров = T, то восстановить зависимости ты можешь до 1/(2dT)
            for (int i = 0; i < data.Length / 2; i++)
            {
                series.Points.AddXY((double)(i * (dt / data.Length)), data[i]);
            }
            Zoom(chart);
            chart.Update();
        }

        public static void Zoom(Chart chart)
        {
            foreach (var chartAreas in chart.ChartAreas)
            {
                chartAreas.AxisX.IsMarginVisible = false;
                //chartAreas.AxisX.ScaleView.Zoomable = true;
                //chartAreas.AxisY.ScaleView.Zoomable = true;
                //chartAreas.CursorX.IsUserEnabled = true;
                //chartAreas.CursorX.IsUserSelectionEnabled = true;
                //chartAreas.CursorY.IsUserEnabled = true;
                //chartAreas.CursorY.IsUserSelectionEnabled = true;
            }
        }


        public static double[] AutoCrossCorrelation(double[] first, double[] second)
        {
            double[] result = new double[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                result[i] = CrossCorrelation(first, second, i);
            }
            return result;
        }

        //Корреляция
        private static double CrossCorrelation(double[] first, double[] second, int lag)
        {
            double firstAVG = CalcAVG(first);
            double secondAVG = CalcAVG(second);
            double sum = 0;
            for (int i = 0; i < (first.Length - lag); i++)
            {
                sum += (first[i] - firstAVG) * (second[i + lag] - secondAVG);
            }
            return sum / ((first.Length - lag) * (CalcStandardDeviation(first) * CalcStandardDeviation(second)));
        }

        //Среднее
        public static double CalcAVG(double[] source)
        {
            double sum = 0;
            foreach (var point in source)
            {
                sum += point;
            }
            return (double)(sum / source.Length);
        }

        //Среднеквадратичное
        public static double CalcRMS(double[] source)
        {
            double sum = 0;

            foreach (var point in source)
            {
                sum += Math.Pow(point, 2);
            }
            return (double)(sum / source.Length);
        }

        //Стандартное отклонение
        public static double CalcStandardDeviation(double[] source)
        {
            return Math.Sqrt(CalcDispersion(source, 2));
        }

        //Среднее отклонение (сигма?)
        private static double CalcAvgDeviation(double[] source)
        {
            return Math.Sqrt(CalcRMS(source));
        }

        //Дисперсия
        public static double CalcDispersion(double[] source, int pow = 2)
        {
            double avg = 0;
            double dispersion = 0;
            avg = CalcAVG(source);
            foreach (var point in source)
            {
                dispersion += Math.Pow(point - avg, pow);
            }
            return dispersion / source.Length;
        }

        public static double CalculateBorder(double dT)
        {
            return 1 / (2 * dT);
        }

        public static double[] Derivative(double[] source)
        {
            for (int i = 0; i < source.Length - 1; i++)
            {
                source[i] = source[i + 1] - source[i];
            }
            return source;
        }

        public static double[] FourierFunction(double[] source)
        {
            int n = source.Length;
            double[] res = new double[n];
            Parallel.For(0, n, i =>
            {
                double Rei = 0;
                for (int k = 0; k < n; k++)
                {
                    Rei += source[k] * Math.Cos((Math.PI * 2 * i * k) / n);
                }
                double Imi = 0;
                for (int k = 0; k < n; k++)
                {
                    Imi += source[k] * Math.Sin((Math.PI * 2 * i * k) / n);
                }
                Rei = Rei / n;
                Imi = Imi / n;

                res[i] = Math.Sqrt(Math.Pow(Rei, 2) + Math.Pow(Imi, 2));
            });
            return res;
        }


        public static Complex[] ReverseFourier(double[] source)
        {
            int n = source.Length;
            Complex[] res = new Complex[n];
            Parallel.For(0, n, i =>
            {
                double Rei = 0;
                for (int k = 0; k < n; k++)
                {
                    Rei += source[k] * Math.Cos((Math.PI * 2 * i * k) / n);
                }
                double Imi = 0;
                for (int k = 0; k < n; k++)
                {
                    Imi += source[k] * Math.Sin((Math.PI * 2 * i * k) / n);
                }
                Complex result = new Complex(Rei, Imi);
                res[i] = result;
            });
            return res;
        }

        public static Complex[] ForwardFourier(double[] source)
        {
            int n = source.Length;
            Complex[] res = new Complex[n];
            Parallel.For(0, n, i =>
            {
                double Rei = 0;
                for (int k = 0; k < n; k++)
                {
                    Rei += source[k] * Math.Cos((Math.PI * 2 * i * k) / n);
                }
                double Imi = 0;
                for (int k = 0; k < n; k++)
                {
                    Imi += source[k] * Math.Sin((Math.PI * 2 * i * k) / n);
                }
                Rei = Rei / n;
                Imi = Imi / n;
                Complex result = new Complex(Rei, Imi);
                res[i] = result;
            });
            return res;
        }

        public static Complex[][] Forward2DFourier(double[][] source)
        {
            int n1 = source.Length;
            Complex[][] res = new Complex[n1][];
            int n = source[0].Length;
            for (int j = 0; j < source.Length; j++)
            {
                res[j] = new Complex[n];

                Parallel.For(0, n, i =>
                {
                    double Rei = 0;
                    for (int k = 0; k < n; k++)
                    {
                        Rei += source[j][k] * Math.Cos((Math.PI * 2 * i * k) / n);
                    }
                    double Imi = 0;
                    for (int k = 0; k < n; k++)
                    {
                        Imi += source[j][k] * Math.Sin((Math.PI * 2 * i * k) / n);
                    }

                    Complex result = new Complex(Rei, Imi);
                    res[j][i] = result;
                });
            }
            return res;
        }


        public static Complex[][] Reversed2DFourier(double[][] source)
        {
            int n1 = source.Length;
            Complex[][] res = new Complex[n1][];
            int n = source[0].Length;
            for (int j = 0; j < source.Length; j++)
            {
                Parallel.For(0, n, i =>
                {
                    double Rei = 0;
                    for (int k = 0; k < n; k++)
                    {
                        Rei += source[j][k] * Math.Cos((Math.PI * 2 * i * k) / n);
                    }
                    double Imi = 0;
                    for (int k = 0; k < n; k++)
                    {
                        Imi += source[j][k] * Math.Sin((Math.PI * 2 * i * k) / n);
                    }
                    Rei = Rei / n;
                    Imi = Imi / n;

                    Complex result = new Complex(Rei, Imi);
                    res[j][i] = result;
                });
            }
            return res;
        }

    }
}
