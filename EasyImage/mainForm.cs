using EasyImage.Source;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyImage
{
    public partial class mainForm : Form
    {
        public string image = "empty";
        public Bitmap bmp;
        public string kernel = "empty";
        public double[][] data;
        public double[] kernelData;
        public static int x = 1024;
        public static int y = 1024;
        public mainForm()
        {
            InitializeComponent();
        }

        private void openKernel_Click(object sender, EventArgs e)
        {
            while (openFileDialog.FileName == "empty")
            {
                openFileDialog.ShowDialog();
                kernel = openFileDialog.FileName;
            }

            openFileDialog.FileName = "empty";
            openKernel.Text = kernel;
        }

        private void openSource_Click(object sender, EventArgs e)
        {
            while (openFileDialog.FileName == "empty")
            {
                openFileDialog.ShowDialog();
                image = openFileDialog.FileName;
            }

            openFileDialog.FileName = "empty";
            openSource.Text = image;
        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            x = 1024;
            y = 1024;
            openSource.Text = openKernel.Text = "Open";
            data = Reader.readFile(image, x, y, false);
            if (kernel != "empty")
                kernelData = Reader.readHex(kernel);
            double[][] result = data;
            pictureBefore.Image = Reader.Draw(Reader.RescaleImage(data, x, y), x, y);
            switch (listOperations.SelectedItem.ToString().Trim())
            {
                case ("Knearest"):
                    {
                        result = Zoom.Knearest(data, 2);
                    }
                    break;
                case ("Bilinear"):
                    {
                        result = Zoom.Bilinear(data, 2);
                    }
                    break;
                case ("Logarithm"):
                    {
                        result = Zoom.Logarithm(data, 2);
                    }
                    break;
                case ("Negative"):
                    {
                        result = Processing.Nagative(data, 256);
                    }
                    break;
                case ("Gamma"):
                    {
                        result = Processing.Gamma(data, 1, 0.7);
                    }
                    break;
                case ("Remove Border (LPF)"):
                    {
                        result = Border.StepFunction(result, 180, 180, 8);
                        result = Border.RemoveBorder_LPF(result, 0.05, 16, 1);
                    }
                    break;
                case ("Remove Border (Gradient)"):
                    {
                        result = Border.Gradient(result);
                        result = Border.StepFunction(result, 1, 1, 8);
                    }
                    break;
                case ("Remove Border (Laplassian)"):
                    {
                        result = Border.Laplassian(result);
                    }
                    break;
                default:
                    break;
            }
            if (listOperations.SelectedItem.ToString().Trim() != "Equalize")
                pictureAfter.Image = Reader.Draw(Reader.RescaleImage(result,x,y), x, y);
            else
            {
                //LEGACY
                pictureBefore.Image = Parser.readFile(image);
                Bitmap temp = (Bitmap)pictureBefore.Image.Clone();
                pictureAfter.Image = Processing.Equalizing(temp);
            }
        }
    }
}


