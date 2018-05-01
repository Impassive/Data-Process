using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyImage.Source
{
    public static class Border
    {
        public static double[][] StepFunction(double[][] source, int step_lower = 200, int step_higher = 200, int depth = 8)
        {
            for (int i = 0; i < source.Length; i++)
                for (int j = 0; j < source[i].Length; j++)
                    source[i][j] = _step((int)source[i][j], step_lower, step_higher, depth);
            return source;
        }

        private static int _step(int x, int step_lower = 200, int step_higher = 200, int depth = 8)
        {
            if (x < step_lower)
            {
                x = 0;
            }
            else if (x >= step_higher)
            {
                x = (1 << depth) - 1;
            }
            return x;
        }

        public static double[][] RemoveBorder_LPF(double[][] source, double fcut, int m, double dt)
        {
            double[][] temp = new double[source.Length][];
            for (int i = 0; i < source.Length; i++)
            {
                temp[i] = new double[source[i].Length];
                for (int j = 0; j < source[i].Length; j++)
                    temp[i][j] = source[i][j];
            }
            temp = Filters.LPF(temp, fcut, m, dt);

            //Minus
            for (int i = 0; i < source.Length; i++)
                for (int j = 0; j < source[i].Length; j++)
                {
                    temp[i][j] -= source[i][j];
                    if (temp[i][j] < 0) temp[i][j] = 0;
                }
            return temp;
        }

        public static double[][] ApplyMask(double[][] f, double[][] mask)
        {
            double[][] result = new double[f.Length][];
            for (int i = 0; i < f.Length; i++)
            {
                result[i] = new double[f[i].Length];
                for (int j = 0; j < f[i].Length; j++)
                {
                    int maxMi = (int)mask.Length / 2;
                    int maxMj = (int)mask[0].Length / 2;
                    double[][] range = f.Skip(i - maxMi).Take(i >= maxMi ? mask.Length : i + maxMi + 1)
                        .Select(x => x.Skip(j - maxMj).Take(j >= maxMj ? mask[0].Length : j + maxMj + 1).ToArray())
                        .ToArray();
                    double[][] maskRange = mask.Skip(i < maxMi ? maxMi - i : 0)
                        .Take(i + maxMi >= f.Length ? f.Length - i + 1 : mask.Length)
                        .Select(x => x.Skip(j < maxMj ? maxMj - j : 0)
                                      .Take(j + maxMj >= f[i].Length ? f[i].Length - j + 1 : mask[0].Length)
                                      .ToArray())
                        .ToArray();
                    int counter = 0;
                    double sum = 0;

                    for (int mi = 0; mi < maskRange.Length; mi++)
                    {
                        for (int mj = 0; mj < maskRange[mi].Length; mj++)
                        {
                            sum += range[mi][mj] * maskRange[mi][mj];
                            counter++;
                        }
                    }
                    Console.WriteLine("Summed " + counter + "times");
                    result[i][j] = sum;
                }
            }
            return result;
        }

        public static double[][] Gradient(double[][] f)
        {
            double[][] horMask = new double[3][] { new double[3] { -1, -2, -1 }, new double[3] { 0, 0, 0 }, new double[3] { 1, 2, 1 } };
            double[][] vertMask = new double[3][] { new double[3] { -1, 0, 1 }, new double[3] { -2, 0, 2 }, new double[3] { -1, 0, 1 } };
            double[][] diagMask = new double[3][] { new double[3] { 0, 1, 1 }, new double[3] { -1, 0, 1 }, new double[3] { -1, -1, 0 } };
            double[][] diagMaskReversed = new double[3][] { new double[3] { 1, 1, 0 }, new double[3] { 1, 0, -1 }, new double[3] { 0, -1, -1 } };

            double[][] Horizontal = ApplyMask(f, horMask);
            double[][] Vertical = ApplyMask(f, vertMask);
            double[][] Diagonal = ApplyMask(f, diagMask);
            double[][] DiagonalRev = ApplyMask(f, diagMaskReversed);

            double tmp;
            for (int i = 0; i < f.Length; i++)
            {
                for (int j = 0; j < f[i].Length; j++)
                {
                    tmp = Horizontal[i][j] + Vertical[i][j] + Diagonal[i][j] + DiagonalRev[i][j];
                    if (tmp < 0)
                    {
                        tmp = 0;
                    }
                    f[i][j] = tmp;
                }
            }
            return f;
        }

        public static double[][] Laplassian(double[][] f)
        {
            double[][] horMask = new double[3][] { new double[3] { -1, -1, -1 }, new double[3] { -1, 8, -1 }, new double[3] { -1, -1, -1 } };
            double[][] Horizontal = ApplyMask(f, horMask);

            double tmp;
            for (int i = 0; i < f.Length; i++)
            {
                for (int j = 0; j < f[i].Length; j++)
                {
                    tmp = Horizontal[i][j];
                    if (tmp < 0)
                    {
                        tmp = 0;
                    }

                    f[i][j] = tmp;
                }
            }
            return f;
        }
    }
}
