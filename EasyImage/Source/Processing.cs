﻿using System;
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
    }
}
