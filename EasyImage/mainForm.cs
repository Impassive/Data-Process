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
using System.Windows.Forms.DataVisualization.Charting;

namespace EasyImage
{
    public partial class mainForm : Form
    {
        public string image = "empty";
        public Bitmap bmp;
        public string kernel = "empty";
        public double[][] data;
        public double[][] noize;
        int line = 95;
        double filter = 0.09; //для рандомного шума
        //double filter = 0.03; // для соли и перца
        double[] tempFourier1;
        double[] tempFourier2;
        public double[] kernelData;
        public static double dt = 1;
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

        private double[] PrepareVerticalFouirier(double[][] source, int line = 0)
        {
            double[] oneLine;
            //take string x
            oneLine = new double[source.Length];
            for (int i = 0; i < source.Length; i++)
                oneLine[i] = source[i][line];
            //oneLine = Fourier.Derivative(oneLine);
            //oneLine = Fourier.AutoCrossCorrelation(oneLine, oneLine);
            oneLine = Fourier.FourierFunction(oneLine);
            return oneLine;
        }

        public static double[][] Copy2D(double[][] source, double[][] dest)
        {
            dest = new double[source.Length][];
            for (int i = 0; i < source.Length; i++)
            {
                dest[i] = new double[source[i].Length];
                for (int j = 0; j < source[i].Length; j++)
                {
                    dest[i][j] = source[i][j];
                }
            }
            return dest;
        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            x = 1024;
            y = 1024;
            openSource.Text = openKernel.Text = "Open";
            data = Reader.readFile(image, x, y, false);
            //Copy data line for Fourier
            //data = Reader.Rotate(data);
            tempFourier1 = PrepareVerticalFouirier(data, line);
            //Print Fourier
            Fourier.Draw(fourierChart, tempFourier1, SeriesChartType.Spline);
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
                        //improve C after 1 for darkness, degrade after 1 for light
                        //For xcr (need rescale + normilize)
                        result = Processing.Gamma(data, 1, 0.7);
                    }
                    break;
                case ("Remove Border (LPF)"):
                    {
                        result = Border.StepFunction(result, 180, 180, 8);
                        result = Border.RemoveBorder_LPF(result, 0.05, 16, dt);
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
                case ("Recover"):
                    {
                        if (kernel != "empty")
                            result = Recover.recovery(result, kernel);
                        else
                            MessageBox.Show("no kernel uploaded");
                    }
                    break;
                case ("Recover with Noize"):
                    {
                        if (kernel != "empty")
                            result = Recover.recoveryWithNoize(result, kernel, 0.01);
                        else
                            MessageBox.Show("no kernel uploaded");
                    }
                    break;
                case ("Remove Grid"):
                    {
                        //Calculate grid fcuts:
                        //среднее по массиву Фурье:
                        double avg = Fourier.CalcAVG(tempFourier1);
                        //среднеквадратичное отклонение (сигма)
                        double sigma = Fourier.CalcStandardDeviation(tempFourier1);
                        //поиск пика:
                        double[] temp = new double[tempFourier1.Length];
                        for (int i = 0; i < tempFourier1.Length / 2; i++)
                        {
                            if (tempFourier1[i] > avg + sigma / 4)
                                temp[i] = i * (dt / data.Length);
                        }
                        var peaks = from point in temp
                                    where point != 0
                                    select point;
                        double lefttmp = 0.275609756097561;
                        double left = peaks.Min();
                        double right = peaks.Max();
                        result = Recover.removeLines(data, lefttmp, right, 64, dt);
                    }
                    break;
                case ("Dilatation"):
                    {
                        result = Border.StepFunction(result, 180, 180, 8);
                        double[][] step = result;
                        step = Copy2D(result, step);
                        result = Processing.ApplyMaskDilatation(result, 10, 128);
                        for (int i = 0; i < step.Length; i++)
                            for (int j = 0; j < step[0].Length; j++)
                                result[i][j] -= step[i][j];
                    }
                    break;
                case ("Erosion"):
                    {
                        result = Border.StepFunction(result, 180, 180, 8);
                        double[][] step = result;
                        step = Copy2D(result, step);
                        step = Processing.ApplyMaskErosion(step, 10, 128);
                        for (int i = 0; i < step.Length; i++)
                            for (int j = 0; j < step[0].Length; j++)
                                result[i][j] -= step[i][j];
                    }
                    break;
                default:
                    break;
            }
            if (listOperations.SelectedItem.ToString().Trim() != "Equalize")
                pictureAfter.Image = Reader.Draw(Reader.RescaleImage(result, x, y), x, y);
            else
            {
                //Prepare Hist
                int levels = 256;
                DrawHist(Parser.BitmapTo2D((Bitmap)pictureBefore.Image), chartHisto, levels);
                //LEGACY
                //Draw Picture
                pictureBefore.Image = Parser.readFile(image);
                Bitmap temp = (Bitmap)pictureBefore.Image.Clone();
                pictureAfter.Image = Processing.Equalizing(temp);
            }
        }

        private void DrawHist(double[][] data, Chart chart, int levels)
        {
            chartHisto.Series.Clear();
            Histo.Draw(chartHisto, "normal", Histo.Hist(data, levels), SeriesChartType.Column);
            Histo.Draw(chartHisto, "density", Histo.Density(Histo.Hist(data, levels)), SeriesChartType.Line);
            Histo.Draw(chartHisto, "equalization", Histo.Hist(Histo.HistEquilization(data, levels), levels), SeriesChartType.Column);
            Histo.Draw(chartHisto, "reverse", Histo.Reversed(Histo.Density(Histo.Hist(data, levels)), levels), SeriesChartType.Column);
        }

        private void noizeBtn_Click(object sender, EventArgs e)
        {
            double[][] result = data;
            switch (listNoize.SelectedItem.ToString().Trim())
            {
                case ("Random"):
                    {
                        result = Processing.ApplyRandNoize(data, 0.25);
                    }
                    break;
                case ("Impulse (Salt and Pepper)"):
                    {
                        result = Processing.noizeSaltAndPepper(data, 0.25);
                    }
                    break;
                case ("Both"):
                    {
                        result = Processing.noizeSaltAndPepper(data, 0.25);
                        result = Processing.ApplyRandNoize(result, 0.25);
                    }
                    break;
                default:
                    break;
            }
            noize = Copy2D(result, noize);
            switch (listRemoveNoize.SelectedItem.ToString().Trim())
            {
                case ("Avg"):
                    {
                        result = Filters.AvgFilter(noize, 3);
                        pictureBefore.Image = Reader.Draw(Reader.RescaleImage(noize, x, y), x, y);
                    }
                    break;
                case ("Median"):
                    {
                        result = Filters.MedianFilter(noize, 7);
                        pictureBefore.Image = Reader.Draw(Reader.RescaleImage(noize, x, y), x, y);
                    }
                    break;
                case ("LPF"):
                    {
                        //find filter freq
                        //prepare clear data fourier and then minus the noize fourier
                        tempFourier2 = new double[tempFourier1.Length];
                        for (int i = 0; i < tempFourier1.Length; i++)
                            tempFourier2[i] -= tempFourier1[i];

                        //Print Fourier wth Noize
                        //tempFourier2 = PrepareVerticalFouirier(result, line);
                        Fourier.Draw(fourierChart, tempFourier2, SeriesChartType.Spline);

                        //LPF Filter
                        result = Filters.LPF_y(result, filter, 64, dt);
                        //Print Fourier after LPF
                        //tempFourier2 = PrepareVerticalFouirier(temp, line);
                        //Fourier.Draw(fourierChart, tempFourier2, System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline);

                        //output noize picture
                        pictureBefore.Image = Reader.Draw(Reader.RescaleImage(noize, x, y), x, y);
                    }
                    break;
                case ("HPF"):
                    {
                        double[][] temp = result;
                        temp = Copy2D(result, temp);
                        //Print Fourier wth Noize
                        tempFourier2 = PrepareVerticalFouirier(temp, line);
                        Fourier.Draw(fourierChart, tempFourier2, SeriesChartType.Spline);

                        //HPF Filter
                        temp = Filters.HPF_y(temp, filter, 64, dt);
                        //Print Fourier after HPF
                        //tempFourier2 = PrepareVerticalFouirier(temp, line);
                        //Fourier.Draw(fourierChart, tempFourier2, System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline);

                        //output noize picture
                        pictureBefore.Image = Reader.Draw(Reader.RescaleImage(noize, x, y), x, y);

                        //HPF minus noize picture
                        for (int i = 0; i < temp.Length; i++)
                            for (int j = 0; j < temp[0].Length; j++)
                                result[i][j] -= temp[i][j];

                    }
                    break;
                default:
                    break;
            }
            pictureAfter.Image = Reader.Draw(Reader.RescaleImage(result, x, y), x, y);
        }
    }
}


