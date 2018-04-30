using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyImage.Source
{
    public static class Zoom
    {
        public static double[][] Knearest(double[][] x, double k)
        {
            int width = x.Length;
            int height = x[0].Length;

            int newWidth = (int)(x.Length * k);
            int newHeight = (int)(x[0].Length * k);

            double[][] result = new double[newWidth][];


            for (int i = 0; i < newWidth; i++)
            {
                result[i] = new double[newHeight];
                for (int j = 0; j < newHeight; j++)
                {
                    int srcX = (int)(i / k);
                    int srcY = (int)(j / k);
                    srcX = Math.Min(srcX, width - 1);
                    srcY = Math.Min(srcY, height - 1);
                    result[i][j] = x[srcX][srcY];
                }

            }
            mainForm.x = newWidth;
            mainForm.y = newHeight;
            return result;
        }

        public static double[][] Bilinear(double[][] x, double k)
        {
            int width = x.Length;
            int height = x[0].Length;

            int newWidth = (int)(x.Length * k);
            int newHeight = (int)(x[0].Length * k);

            double[][] result = new double[newWidth][];

            double u;
            double tmp;
            double t;
            int w, h;
            double d1, d2, d3, d4;
            double p1, p2, p3, p4;


            for (int i = 0; i < newWidth; i++)
            {
                result[i] = new double[newHeight];
                tmp = (double)i / (newWidth - 1) * (width - 1);
                w = (int)(tmp);
                if (w < 0)
                    w = 0;
                else
                {
                    if (w >= width - 1)
                        w = width - 2;
                }
                t = tmp - w;

                for (int j = 0; j < newHeight; j++)
                {
                    tmp = (double)j / (newHeight - 1) * (height - 1);
                    h = (int)tmp;
                    if (h < 0)
                    {
                        h = 0;
                    }
                    else
                    {
                        if (h >= height - 1) h = height - 2;
                    }
                    u = tmp - h;

                    d1 = (1 - t) * (1 - u);
                    d2 = t * (1 - u);
                    d3 = t * u;
                    d4 = (1 - t) * u;

                    p1 = x[w][h];
                    p2 = x[w + 1][h];
                    p3 = x[w + 1][h + 1];
                    p4 = x[w][h + 1];

                    result[i][j] = p1 * d1 + p2 * d2 + p3 * d3 + p4 * d4;
                }
            }
            mainForm.x = newWidth;
            mainForm.y = newHeight;
            return result;
        }

        public static double[][] Logarithm(double[][] x, double C)
        {
            int width = x.Length;
            int height = x[0].Length;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    x[i][j] = C * Math.Log10(x[i][j] + 1);
                }
            }
            return x;
        }

    }
}
