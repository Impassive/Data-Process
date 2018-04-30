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
    public static class Reader
    {

        public static double[][] readFile(string file, int width, int height, bool rescale = true)
        {
            string direction = "straight";
            BinaryReader reader = null;
            String[] arr = file.Split('.');
            double[][] result = new double[height][];
            switch (Path.GetExtension(file))
            {
                case (".jpg"):
                    {
                        Bitmap bmp = new Bitmap(Image.FromFile(file));
                        width = bmp.Width;
                        height = bmp.Height;
                        result = new double[width][];

                        for (int i = 0; i < width; i++)
                        {

                            result[i] = new double[height];
                            for (int j = 0; j < height; j++)
                            {
                                int value = bmp.GetPixel(i, j).ToArgb();

                                result[i][j] = value;
                            }
                        }
                        result = RescaleImage(result, width, height);
                    }
                    break;
                case (".xcr"):
                    {
                        reader = new BinaryReader(new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None));
                        string[] splited = file.Split('\\');
                        if (splited.Last().StartsWith("c"))
                        {
                            reader.BaseStream.Position = 0x800;     // The offset you are reading the data from
                            direction = "inverted";
                        }
                        else
                        {
                            string[] sizes = splited.Last().Substring(1, splited.Last().Length - 5).Split('x');
                            height = int.Parse(sizes[0]);
                            width = int.Parse(sizes[1]);
                            result = new double[width][];
                            direction = "straight";
                        }

                        for (int i = 0; i < width; i++)
                        {
                            result[i] = new double[height];
                            for (int j = 0; j < height; j++)
                            {
                                int value;
                                if (direction == "inverted")
                                {
                                    value = (UInt16)((reader.ReadByte() << 8) + reader.ReadByte());
                                }
                                else
                                {
                                    value = reader.ReadUInt16();
                                }

                                result[i][j] = value;
                            }
                        }
                        reader.Close();
                        result = RescaleImage(result, width, height);
                    }
                    break;
                case (".dat"):
                    {
                        Regex regex = new Regex(@"\d+x\d+");
                        Match match = regex.Match(file);
                        if (match.Success)
                        {
                            String[] sizes = regex.Match(file).Value.Split('x');

                            result = readHex2D(file, int.Parse(sizes[1]), int.Parse(sizes[0]));
                            width = result.Length;
                            height = result[0].Length;
                        }
                        break;
                    }
            }
            mainForm.x = width;
            mainForm.y = height;
            if (Path.GetExtension(file) == ".dat" || rescale == false)
                return result;
            else 
                return RescaleImage(result, width, height);
        }

        public static double[] readHex(string filename)
        {
            BinaryReader reader = new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None));
            reader.BaseStream.Position = 0x0;
            string[] splitted = filename.Split('\\');

            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(splitted.Last());
            double[] data = new double[1000];
            if (match.Success)
            {
                int len = int.Parse(match.Value);
                data = new double[len];
                for (int i = 0; i < len; i++)
                {
                    data[i] = reader.ReadSingle();
                }
                reader.Close();
            }
            return data;
        }

        public static double[][] readHex2D(string filename, int _width, int _height)
        {
            BinaryReader reader = new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None));
            reader.BaseStream.Position = 0x0;
            double[][] data = new double[_width][];
            for (int i = 0; i < _width; i++)
            {
                data[i] = new double[_height];
                for (int j = 0; j < _height; j++)
                {
                    data[i][j] = reader.ReadSingle();
                }
            }
            reader.Close();
            return data;
        }

        public static double[][] RescaleImage(double[][] source, int _width, int _height)
        {
            double[][] target = new double[source.Length][];
            double max = Int16.MinValue;
            double min = Int16.MaxValue;
            for (int j = 0; j < _width; j++)
            {
                for (int i = 0; i < _height; i++)
                {
                    double value = source[j][i];

                    if (value < min)
                    {
                        min = value;
                    }
                    if (value > max)
                    {
                        max = value;
                    }
                }
            }
            for (int i = 0; i < _width; i++)
            {
                target[i] = new double[source[i].Length];
                for (int j = 0; j < _height; j++)
                {
                    double value = source[i][j];
                    value = (int)(((double)(value - min) / (double)(max - min)) * 255);

                    target[i][j] = value;
                }
            }
            return target;
        }


        public static Bitmap Draw(double[][] source, int _width, int _height)
        {
            _width = source.Length;
            _height = source[0].Length;
            Bitmap bmp = new Bitmap(_width, _height);

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    int value = (int)source[i][j];
                    Color c = Color.FromArgb(255, value, value, value);
                    bmp.SetPixel(i, j, c);

                }
            }
            return Image.FromHbitmap(bmp.GetHbitmap());
        }


    }
}
