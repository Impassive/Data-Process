namespace EasyImage
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabImage = new System.Windows.Forms.TabPage();
            this.noizeGBox = new System.Windows.Forms.GroupBox();
            this.noizeBtn = new System.Windows.Forms.Button();
            this.listNoize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.operationGbox = new System.Windows.Forms.GroupBox();
            this.listOperations = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openSource = new System.Windows.Forms.Button();
            this.openKernel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.goBtn = new System.Windows.Forms.Button();
            this.pictureGBox = new System.Windows.Forms.GroupBox();
            this.labelAfter = new System.Windows.Forms.Label();
            this.labelBefore = new System.Windows.Forms.Label();
            this.pictureAfter = new System.Windows.Forms.PictureBox();
            this.pictureBefore = new System.Windows.Forms.PictureBox();
            this.tabFourier = new System.Windows.Forms.TabPage();
            this.fourierChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabHisto = new System.Windows.Forms.TabPage();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listRemoveNoize = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chartHisto = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl.SuspendLayout();
            this.tabImage.SuspendLayout();
            this.noizeGBox.SuspendLayout();
            this.operationGbox.SuspendLayout();
            this.pictureGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBefore)).BeginInit();
            this.tabFourier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fourierChart)).BeginInit();
            this.tabHisto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHisto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabImage);
            this.tabControl.Controls.Add(this.tabFourier);
            this.tabControl.Controls.Add(this.tabHisto);
            this.tabControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1304, 785);
            this.tabControl.TabIndex = 0;
            // 
            // tabImage
            // 
            this.tabImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabImage.Controls.Add(this.noizeGBox);
            this.tabImage.Controls.Add(this.operationGbox);
            this.tabImage.Controls.Add(this.pictureGBox);
            this.tabImage.Location = new System.Drawing.Point(4, 25);
            this.tabImage.Name = "tabImage";
            this.tabImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabImage.Size = new System.Drawing.Size(1296, 756);
            this.tabImage.TabIndex = 0;
            this.tabImage.Text = "Image";
            this.tabImage.UseVisualStyleBackColor = true;
            // 
            // noizeGBox
            // 
            this.noizeGBox.Controls.Add(this.listRemoveNoize);
            this.noizeGBox.Controls.Add(this.label5);
            this.noizeGBox.Controls.Add(this.noizeBtn);
            this.noizeGBox.Controls.Add(this.listNoize);
            this.noizeGBox.Controls.Add(this.label3);
            this.noizeGBox.Location = new System.Drawing.Point(555, 557);
            this.noizeGBox.Name = "noizeGBox";
            this.noizeGBox.Size = new System.Drawing.Size(314, 167);
            this.noizeGBox.TabIndex = 2;
            this.noizeGBox.TabStop = false;
            this.noizeGBox.Text = "Apply Noize";
            // 
            // noizeBtn
            // 
            this.noizeBtn.Location = new System.Drawing.Point(233, 135);
            this.noizeBtn.Name = "noizeBtn";
            this.noizeBtn.Size = new System.Drawing.Size(75, 28);
            this.noizeBtn.TabIndex = 10;
            this.noizeBtn.Text = "Apply";
            this.noizeBtn.UseVisualStyleBackColor = true;
            this.noizeBtn.Click += new System.EventHandler(this.noizeBtn_Click);
            // 
            // listNoize
            // 
            this.listNoize.FormattingEnabled = true;
            this.listNoize.Items.AddRange(new object[] {
            "None",
            "Random",
            "Impulse (Salt and Pepper)",
            "Both"});
            this.listNoize.Location = new System.Drawing.Point(81, 25);
            this.listNoize.Name = "listNoize";
            this.listNoize.Size = new System.Drawing.Size(196, 24);
            this.listNoize.TabIndex = 12;
            this.listNoize.Text = "None";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Type:";
            // 
            // operationGbox
            // 
            this.operationGbox.Controls.Add(this.listOperations);
            this.operationGbox.Controls.Add(this.label2);
            this.operationGbox.Controls.Add(this.label4);
            this.operationGbox.Controls.Add(this.openSource);
            this.operationGbox.Controls.Add(this.openKernel);
            this.operationGbox.Controls.Add(this.label1);
            this.operationGbox.Controls.Add(this.goBtn);
            this.operationGbox.Location = new System.Drawing.Point(20, 557);
            this.operationGbox.Name = "operationGbox";
            this.operationGbox.Size = new System.Drawing.Size(476, 167);
            this.operationGbox.TabIndex = 1;
            this.operationGbox.TabStop = false;
            this.operationGbox.Text = "Operation";
            // 
            // listOperations
            // 
            this.listOperations.FormattingEnabled = true;
            this.listOperations.Items.AddRange(new object[] {
            "None",
            "Knearest",
            "Bilinear",
            "Logarithm",
            "Negative",
            "Gamma",
            "Equalize",
            "Remove Border (LPF)",
            "Remove Border (Gradient)",
            "Remove Border (Laplassian)",
            "Recover",
            "Recover with Noize",
            "Remove Grid",
            "Dilatation",
            "Erosion"});
            this.listOperations.Location = new System.Drawing.Point(69, 25);
            this.listOperations.Name = "listOperations";
            this.listOperations.Size = new System.Drawing.Size(196, 24);
            this.listOperations.TabIndex = 6;
            this.listOperations.Text = "None";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Source:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Kernel: ";
            // 
            // openSource
            // 
            this.openSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openSource.Location = new System.Drawing.Point(69, 69);
            this.openSource.Name = "openSource";
            this.openSource.Size = new System.Drawing.Size(75, 31);
            this.openSource.TabIndex = 2;
            this.openSource.Text = "Open";
            this.openSource.UseVisualStyleBackColor = true;
            this.openSource.Click += new System.EventHandler(this.openSource_Click);
            // 
            // openKernel
            // 
            this.openKernel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openKernel.Location = new System.Drawing.Point(69, 117);
            this.openKernel.Name = "openKernel";
            this.openKernel.Size = new System.Drawing.Size(75, 31);
            this.openKernel.TabIndex = 5;
            this.openKernel.Text = "Open";
            this.openKernel.UseVisualStyleBackColor = true;
            this.openKernel.Click += new System.EventHandler(this.openKernel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type:";
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(395, 135);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(75, 26);
            this.goBtn.TabIndex = 0;
            this.goBtn.Text = "Perform";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // pictureGBox
            // 
            this.pictureGBox.Controls.Add(this.labelAfter);
            this.pictureGBox.Controls.Add(this.labelBefore);
            this.pictureGBox.Controls.Add(this.pictureAfter);
            this.pictureGBox.Controls.Add(this.pictureBefore);
            this.pictureGBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureGBox.Location = new System.Drawing.Point(3, 3);
            this.pictureGBox.Name = "pictureGBox";
            this.pictureGBox.Size = new System.Drawing.Size(1288, 547);
            this.pictureGBox.TabIndex = 0;
            this.pictureGBox.TabStop = false;
            // 
            // labelAfter
            // 
            this.labelAfter.AutoSize = true;
            this.labelAfter.Location = new System.Drawing.Point(666, 18);
            this.labelAfter.Name = "labelAfter";
            this.labelAfter.Size = new System.Drawing.Size(38, 17);
            this.labelAfter.TabIndex = 3;
            this.labelAfter.Text = "After";
            // 
            // labelBefore
            // 
            this.labelBefore.AutoSize = true;
            this.labelBefore.Location = new System.Drawing.Point(17, 18);
            this.labelBefore.Name = "labelBefore";
            this.labelBefore.Size = new System.Drawing.Size(50, 17);
            this.labelBefore.TabIndex = 2;
            this.labelBefore.Text = "Before";
            // 
            // pictureAfter
            // 
            this.pictureAfter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureAfter.Location = new System.Drawing.Point(670, 41);
            this.pictureAfter.Name = "pictureAfter";
            this.pictureAfter.Size = new System.Drawing.Size(600, 500);
            this.pictureAfter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureAfter.TabIndex = 1;
            this.pictureAfter.TabStop = false;
            // 
            // pictureBefore
            // 
            this.pictureBefore.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBefore.Location = new System.Drawing.Point(17, 41);
            this.pictureBefore.Name = "pictureBefore";
            this.pictureBefore.Size = new System.Drawing.Size(600, 500);
            this.pictureBefore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBefore.TabIndex = 0;
            this.pictureBefore.TabStop = false;
            // 
            // tabFourier
            // 
            this.tabFourier.Controls.Add(this.fourierChart);
            this.tabFourier.Location = new System.Drawing.Point(4, 25);
            this.tabFourier.Name = "tabFourier";
            this.tabFourier.Size = new System.Drawing.Size(1296, 756);
            this.tabFourier.TabIndex = 2;
            this.tabFourier.Text = "Fourier";
            this.tabFourier.UseVisualStyleBackColor = true;
            // 
            // fourierChart
            // 
            chartArea1.Name = "Fourier";
            this.fourierChart.ChartAreas.Add(chartArea1);
            this.fourierChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.fourierChart.Legends.Add(legend1);
            this.fourierChart.Location = new System.Drawing.Point(0, 0);
            this.fourierChart.Name = "fourierChart";
            series1.ChartArea = "Fourier";
            series1.Legend = "Legend1";
            series1.Name = "default";
            this.fourierChart.Series.Add(series1);
            this.fourierChart.Size = new System.Drawing.Size(1296, 756);
            this.fourierChart.TabIndex = 0;
            this.fourierChart.Text = "fourierChart";
            // 
            // tabHisto
            // 
            this.tabHisto.Controls.Add(this.chartHisto);
            this.tabHisto.Location = new System.Drawing.Point(4, 25);
            this.tabHisto.Name = "tabHisto";
            this.tabHisto.Padding = new System.Windows.Forms.Padding(3);
            this.tabHisto.Size = new System.Drawing.Size(1296, 756);
            this.tabHisto.TabIndex = 1;
            this.tabHisto.Text = "Histo";
            this.tabHisto.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "empty";
            this.openFileDialog.InitialDirectory = "C:\\Users\\Admin\\source\\repos\\EasyImage\\Image_Kernel";
            // 
            // listRemoveNoize
            // 
            this.listRemoveNoize.FormattingEnabled = true;
            this.listRemoveNoize.Items.AddRange(new object[] {
            "None",
            "Avg",
            "Median",
            "LPF",
            "HPF"});
            this.listRemoveNoize.Location = new System.Drawing.Point(81, 66);
            this.listRemoveNoize.Name = "listRemoveNoize";
            this.listRemoveNoize.Size = new System.Drawing.Size(196, 24);
            this.listRemoveNoize.TabIndex = 14;
            this.listRemoveNoize.Text = "None";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Type:";
            // 
            // chartHisto
            // 
            chartArea2.Name = "normal";
            chartArea3.Name = "density";
            chartArea4.Name = "equalization";
            chartArea5.Name = "reverse";
            this.chartHisto.ChartAreas.Add(chartArea2);
            this.chartHisto.ChartAreas.Add(chartArea3);
            this.chartHisto.ChartAreas.Add(chartArea4);
            this.chartHisto.ChartAreas.Add(chartArea5);
            this.chartHisto.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartHisto.Legends.Add(legend2);
            this.chartHisto.Location = new System.Drawing.Point(3, 3);
            this.chartHisto.Name = "chartHisto";
            series2.ChartArea = "normal";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartHisto.Series.Add(series2);
            this.chartHisto.Size = new System.Drawing.Size(1290, 750);
            this.chartHisto.TabIndex = 0;
            this.chartHisto.Text = "histo";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 785);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.Text = "Easy Image";
            this.tabControl.ResumeLayout(false);
            this.tabImage.ResumeLayout(false);
            this.noizeGBox.ResumeLayout(false);
            this.noizeGBox.PerformLayout();
            this.operationGbox.ResumeLayout(false);
            this.operationGbox.PerformLayout();
            this.pictureGBox.ResumeLayout(false);
            this.pictureGBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBefore)).EndInit();
            this.tabFourier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fourierChart)).EndInit();
            this.tabHisto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartHisto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabImage;
        private System.Windows.Forms.TabPage tabHisto;
        private System.Windows.Forms.GroupBox pictureGBox;
        private System.Windows.Forms.PictureBox pictureAfter;
        private System.Windows.Forms.PictureBox pictureBefore;
        private System.Windows.Forms.GroupBox operationGbox;
        private System.Windows.Forms.Label labelAfter;
        private System.Windows.Forms.Label labelBefore;
        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.Button openKernel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button openSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ComboBox listOperations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabFourier;
        private System.Windows.Forms.DataVisualization.Charting.Chart fourierChart;
        private System.Windows.Forms.Button noizeBtn;
        private System.Windows.Forms.GroupBox noizeGBox;
        private System.Windows.Forms.ComboBox listNoize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox listRemoveNoize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHisto;
    }
}

