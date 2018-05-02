using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace EasyImage.Source
{
    public static class Histo
    {
        public static void Draw(Chart chart, string functionName, double[] data, SeriesChartType chartType)
        {
            Series series = chart.Series.Add(functionName);
            series.ChartType = chartType;
            series.ChartArea = functionName;

            for (int i = 0; i < data.Length; i++)
            {
                series.Points.AddY(data[i]);
            }
        }

        public static double[] Hist(double[][] data, int levels)
        {
            double[] ans = new double[levels];
            double N = data.Length;
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[0].Length; j++)
                {
                    try
                    {
                        ans[(int)data[i][j]] += 1;
                    }
                    catch (Exception)
                    {
                        ans[ans.Length - 1] += 1;
                    }
                }
            }

            for (int i = 0; i < ans.Length; i++)
                ans[i] /= N;
            return ans;
        }

        public static double[] Density(double[] histData)
        {
            double[] ans = new double[histData.Length];
            double N = histData.Sum();

            for (int i = 0; i < ans.Length; i++)
            {
                ans[i] = (double)histData.Take(i + 1).Sum() / N;
            }
            return ans;

        }

        public static double[] Reversed(double[] histData, int levels)
        {
            double[] res = new double[histData.Length];
            for (int i = 0; i < histData.Length; i++)
            {
                res[i] = Math.Pow((double)i / 255, 2);
            }
            return res;

        }

        public static double[][] HistReduction(double[][] data, int levels)
        {
            double[] hist = Hist(data, levels);
            double[] density = Density(hist);
            double[] reversed = Reversed(density, levels);

            for (int j = 0; j < data.Length; j++)
            {
                for (int i = 0; i < data[0].Length; i++)
                {
                    for (int k = 0; k < reversed.Length; k++)
                    {
                        if (density[(int)data[j][i]] < reversed[k])
                        {
                            data[j][i] = k;
                            break;
                        }
                    }

                }
            }
            return data;
        }


        public static double[] Equalization(double[] histData, int levels)
        {

            double[] ans = new double[histData.Length];
            double N = histData.Sum();

            for (int i = 0; i < ans.Length; i++)
            {
                ans[i] = (int)((double)histData.Take(i + 1).Sum() / N * (levels - 1));
            }

            return ans;

        }

        public static double[][] HistEquilization(double[][] data, int levels)
        {
            double[] hist = Hist(data, levels);
            double[] eq = Equalization(hist, levels);

            for (int j = 0; j < data.Length; j++)
            {
                for (int i = 0; i < data[0].Length; i++)
                {
                    data[j][i] = (int)eq[(int)data[j][i]];
                }
            }
            return data;
        }
    }
}
