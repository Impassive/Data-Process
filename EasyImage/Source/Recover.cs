using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace EasyImage.Source
{
    public static class Recover
    {
        public static double[][] recovery(double[][] img, string Hfilename)
        {
            double[] h = Reader.readHex(Hfilename);
            double[] complementedH = new double[img[0].Length];


            Array.Copy(h, complementedH, h.Length);
            for (int i = h.Length; i < complementedH.Length; i++)
            {
                complementedH[i] = 0;
            }
            Complex[] H = Fourier.ForwardFourier(complementedH);
            //построчно!
            img = img.Select(row => Fourier.ForwardFourier(row).Select((x, index) => x / H[index])
                                                 .Select(x => x.Imaginary + x.Real)
                                                 .ToArray())
                 .Select(row => Fourier.ReverseFourier(row).Select(x => x.Real + x.Imaginary)
                                                 .ToArray())
                 .ToArray();

            return img;
        }

        public static double[][] recoveryWithNoize(double[][] img, string Hfilename, double regularization)
        {
            double[] h = Reader.readHex(Hfilename);
            double[] complementedH = new double[img[0].Length];

            Array.Copy(h, complementedH, h.Length);
            for (int i = h.Length; i < complementedH.Length; i++)
            {
                complementedH[i] = 0;
            }

            Complex[] H = Fourier.ForwardFourier(complementedH);

            img = img.Select(row => Fourier.ForwardFourier(row).Select((x, index) =>
            {
                Complex rez = x * Complex.Conjugate(H[index]) / (Math.Pow(Complex.Abs(H[index]), 2) + Math.Pow(regularization, 2));
                return rez;
            })
                                                 .Select(x => x.Imaginary + x.Real)
                                                 .ToArray())
                 .Select(row => Fourier.ReverseFourier(row).Select(x => x.Real + x.Imaginary)
                                                 .ToArray())
                 .ToArray();

            return img;
        }

        public static double[][] removeLines(double[][] source, double fcut1, double fcut2, int m, double dT)
        {
            double[][] result = source;
            //Do Not Pivot!
            result = Filters.BSF_x(result, fcut1, fcut2, m, dT);
            return result;
        }

        public static double[] Derivative(double[] source)
        {
            for (int i = 0; i < source.Length - 1; i++)
            {
                source[i] = source[i + 1] - source[i];
            }
            return source;
        }
    }
}
