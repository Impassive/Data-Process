using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyImage.Source
{
    public static class Parser
    {
        public static Bitmap readFile(string file)
        {
            switch (Path.GetExtension(file))
            {
                case (".xcr"):
                    Stream temp = File.Open(file, FileMode.Open);
                    using (BinaryReader Breader = new BinaryReader(temp))
                    {
                        for (int i = 0; i < 2048; i++)
                            Breader.ReadByte();
                        byte[] arr = new byte[2048 * 2048];
                        for (int i = 0; i < 2 * 1024 * 1024; i++)
                            arr[i] = Breader.ReadByte();
                        arr = ReverseBytes(arr);
                        ushort[] ns = new ushort[1024 * 1024];
                        double max = 0;
                        double min = short.MaxValue;
                        for (int i = 0; i < 1024 * 1024 * 2; i += 2)
                        {
                            ns[i / 2] = BitConverter.ToUInt16(new byte[2] { arr[i], arr[i + 1] }, 0); ;
                            if (ns[i / 2] > max)
                                max = ns[i / 2];
                            if (ns[i / 2] < min)
                                min = ns[i / 2];
                        }
                        byte[] barr = new byte[ns.Length];
                        Bitmap bitmap = new Bitmap(1024, 1024, PixelFormat.Format24bppRgb);
                        for (int i = 0; i < ns.Length; i++)
                        {
                            barr[i] = Convert.ToByte(((ns[i] - min) / (max - min)) * 255);
                            bitmap.SetPixel((i - i % 1024) / 1024, i % 1024, Color.FromArgb(barr[i], barr[i], barr[i]));
                        }
                        bitmap.RotateFlip(RotateFlipType.Rotate270FlipX);
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                        return bitmap;
                    }

                case (".jpg"):
                    Bitmap img = (Bitmap)Image.FromFile(file);
                    //Bitmap clone = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);
                    return img;
            }
            return null;
        }
        public static byte[] ReverseBytes(byte[] InArr)
        {
            byte[] SaveArr = new byte[InArr.Length];
            for (int i = 0; i < 1024 * 1024 * 2; i += 2)
            {
                SaveArr[i] = InArr[i + 1];
                SaveArr[i + 1] = InArr[i];
            }
            return SaveArr;
        }
    }
}

