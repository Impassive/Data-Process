using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyImage.Source
{
    public class Processing
    {
        public static double[][] Nagative(double[][] x, double Lmax)
        {
            int width = x.Length;
            int height = x[0].Length;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    x[i][j] = Lmax - 1 - x[i][j];
                }
            }
            mainForm.x = width;
            mainForm.y = height;
            return x;
        }

        public static double[][] Gamma(double[][] x, double C, double gamma)
        {
            int width = x.Length;
            int height = x[0].Length;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    x[i][j] = C * Math.Pow(x[i][j], gamma);
                }

            }
            mainForm.x = width;
            mainForm.y = height;
            return x;
        }

        public static Bitmap Equalizing(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int bytes = bmpData.Stride * bmp.Height;
            byte[] grayValues = new byte[bytes];
            int[] R = new int[256];
            byte[] N = new byte[256];
            byte[] left = new byte[256];
            byte[] right = new byte[256];
            System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);
            for (int i = 0; i < grayValues.Length; i++) ++R[grayValues[i]];
            int z = 0;
            int Hint = 0;
            int Havg = grayValues.Length / R.Length;
            for (int i = 0; i < N.Length - 1; i++)
            {
                N[i] = 0;
            }
            for (int j = 0; j < R.Length; j++)
            {
                if (z > 255) left[j] = 255;
                else left[j] = (byte)z;
                Hint += R[j];
                while (Hint > Havg)
                {
                    Hint -= Havg;
                    z++;
                }
                if (z > 255) right[j] = 255;
                else right[j] = (byte)z;

                N[j] = (byte)((left[j] + right[j]) / 2);
            }
            for (int i = 0; i < grayValues.Length; i++)
            {
                if (left[grayValues[i]] == right[grayValues[i]]) grayValues[i] = left[grayValues[i]];
                else grayValues[i] = N[grayValues[i]];
            }

            System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
            bmp.UnlockBits(bmpData);
            return bmp;
        }

        public static double Maximum(double[][] source)
        {
            double max = int.MinValue;
            double tmp;
            for (int i = 0; i < source.Length; i++)
            {
                tmp = source[i].Max();
                if (tmp > max)
                {
                    max = tmp;
                }
            }
            return max;
        }

        public static double Minimum(double[][] source)
        {
            double min = int.MaxValue;
            double tmp;
            for (int i = 0; i < source.Length; i++)
            {
                tmp = source[i].Min();
                if (tmp < min)
                {
                    min = tmp;
                }
            }
            return min;
        }

        public static double[][] ApplyMaskedFunction(double[][] f, int maskWidth, Func<double[][], double, double> fromRangeFunction)
        {
            double[][] result = new double[f.Length][];
            for (int i = 0; i < f.Length; i++)
            {
                result[i] = new double[f[i].Length];
                for (int j = 0; j < f[i].Length; j++)
                {
                    int maxMi = (int)maskWidth / 2;
                    int maxMj = (int)maskWidth / 2;
                    double[][] range = f.Skip(i - maxMi).Take(i >= maxMi ? maskWidth : i + maxMi + 1)
                        .Select(x => x.Skip(j - maxMj).Take(j >= maxMj ? maskWidth : j + maxMj + 1).ToArray())
                        .ToArray();

                    result[i][j] = fromRangeFunction.Invoke(range,maskWidth);
                }
            }
            return result;
        }


        public static double[][] ApplyMaskErosion(double[][] source, int maskWidth, double threshold)
        {
            double[][] result = new double[source.Length][];
            int maxMi = (int)maskWidth / 2;
            int maxMj = (int)maskWidth / 2;
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = new double[source[i].Length];
                for (int j = 0; j < source[i].Length; j++)
                {
                    double value = source[i][j];
                    if (i >= maxMi && i < source.Length - maxMi && j >= maxMj && j < source[i].Length - maxMj)
                    {
                        double[][] range = source.Skip(i - maxMi).Take(maskWidth)
                            .Select(x => x.Skip(j - maxMj).Take(maskWidth).ToArray())
                            .ToArray();
                        bool needToDelete = false;
                        for (int mi = 0; mi < range.Length; mi++)
                        {
                            for (int mj = 0; mj < range[mi].Length; mj++)
                            {
                                if (range[mi][mj] < threshold)
                                {
                                    needToDelete = true;
                                }
                            }
                        }
                        if (needToDelete)
                        {
                            double min = Minimum(range);

                            value = min;
                        }
                    }
                    result[i][j] = value;
                }
            }
            return result;
        }

        public static double[][] ApplyMaskDilatation(double[][] source, int maskWidth, double threshold)
        {
            double[][] result = new double[source.Length][];
            int maxMi = (int)maskWidth / 2;
            int maxMj = (int)maskWidth / 2;
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = new double[source[i].Length];
                //++
                for (int j = 0; j < source[i].Length; j++)
                {
                    double value = source[i][j];
                    if (i >= maxMi && i < source.Length - maxMi && j >= maxMj && j < source[i].Length - maxMj)
                    {
                        double[][] range = source.Skip(i - maxMi).Take(maskWidth)
                            .Select(x => x.Skip(j - maxMj).Take(maskWidth).ToArray())
                            .ToArray();

                        bool needToAdd = false;


                        for (int mi = 0; mi < range.Length; mi++)
                        {
                            for (int mj = 0; mj < range[mi].Length; mj++)
                            {
                                if (range[mi][mj] > threshold)
                                {
                                    needToAdd = true;
                                }
                            }
                        }
                        if (needToAdd)
                        {
                            double max = Maximum(range);

                            value = max;
                        }
                    }
                    result[i][j] = value;
                }
            }
            return result;
        }

        public static double[][] randomNoize(double[][] source, double power)
        {
            Random rnd = new Random(source.Length);
            double[][] result = new double[source.Length][];
            double rndValue;
            int min = (int)Minimum(source);
            int max = (int)Maximum(source);
            if (max - min < 128)
            {
                min = 0;
                max = 255;
            }
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = new double[source[i].Length];
                for (int j = 0; j < source[i].Length; j++)
                {
                    rndValue = rnd.NextDouble();
                    result[i][j] = source[i][j];
                    if (rndValue < power)
                    {
                        int value = rnd.Next(1, 15) * rnd.Next(-2, 3);
                        result[i][j] += value;
                        if (result[i][j] > max) result[i][j] -= value;
                        if (result[i][j] < min) result[i][j] += value;
                    }
                }
            }
            return result;
        }

        public static double[][] noizeSaltAndPepper(double[][] source, double power)
        {
            Random rnd = new Random(source.Length);
            double[][] result = new double[source.Length][];
            double rndValue;
            int min = (int)Minimum(source);
            int max = (int)Maximum(source);
            if (max - min < 128)
            {
                min = 0;
                max = 255;
            }
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = new double[source[i].Length];
                for (int j = 0; j < source[i].Length; j++)
                {
                    rndValue = rnd.NextDouble();
                    if (rndValue < power)
                    {
                        result[i][j] = rnd.Next(0, 255);
                    }
                    else
                    {
                        result[i][j] = source[i][j];
                    }
                }
            }
            return result;

        }

    }
}
