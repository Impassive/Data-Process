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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabImage = new System.Windows.Forms.TabPage();
            this.pictureGBox = new System.Windows.Forms.GroupBox();
            this.tabHisto = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.operationGbox = new System.Windows.Forms.GroupBox();
            this.labelBefore = new System.Windows.Forms.Label();
            this.labelAfter = new System.Windows.Forms.Label();
            this.goBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openSource = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openKernel = new System.Windows.Forms.Button();
            this.listOperations = new System.Windows.Forms.ComboBox();
            this.tabControl.SuspendLayout();
            this.tabImage.SuspendLayout();
            this.pictureGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.operationGbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabImage);
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
            // pictureGBox
            // 
            this.pictureGBox.Controls.Add(this.labelAfter);
            this.pictureGBox.Controls.Add(this.labelBefore);
            this.pictureGBox.Controls.Add(this.pictureBox2);
            this.pictureGBox.Controls.Add(this.pictureBox1);
            this.pictureGBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureGBox.Location = new System.Drawing.Point(3, 3);
            this.pictureGBox.Name = "pictureGBox";
            this.pictureGBox.Size = new System.Drawing.Size(1288, 547);
            this.pictureGBox.TabIndex = 0;
            this.pictureGBox.TabStop = false;
            // 
            // tabHisto
            // 
            this.tabHisto.Location = new System.Drawing.Point(4, 25);
            this.tabHisto.Name = "tabHisto";
            this.tabHisto.Padding = new System.Windows.Forms.Padding(3);
            this.tabHisto.Size = new System.Drawing.Size(1296, 756);
            this.tabHisto.TabIndex = 1;
            this.tabHisto.Text = "Histo";
            this.tabHisto.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Location = new System.Drawing.Point(17, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox2.Location = new System.Drawing.Point(669, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(600, 500);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // operationGbox
            // 
            this.operationGbox.Controls.Add(this.listOperations);
            this.operationGbox.Controls.Add(this.openKernel);
            this.operationGbox.Controls.Add(this.label3);
            this.operationGbox.Controls.Add(this.label2);
            this.operationGbox.Controls.Add(this.openSource);
            this.operationGbox.Controls.Add(this.label1);
            this.operationGbox.Controls.Add(this.goBtn);
            this.operationGbox.Location = new System.Drawing.Point(20, 557);
            this.operationGbox.Name = "operationGbox";
            this.operationGbox.Size = new System.Drawing.Size(476, 167);
            this.operationGbox.TabIndex = 1;
            this.operationGbox.TabStop = false;
            this.operationGbox.Text = "Operation";
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
            // labelAfter
            // 
            this.labelAfter.AutoSize = true;
            this.labelAfter.Location = new System.Drawing.Point(666, 18);
            this.labelAfter.Name = "labelAfter";
            this.labelAfter.Size = new System.Drawing.Size(38, 17);
            this.labelAfter.TabIndex = 3;
            this.labelAfter.Text = "After";
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(395, 135);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(75, 26);
            this.goBtn.TabIndex = 0;
            this.goBtn.Text = "Perform";
            this.goBtn.UseVisualStyleBackColor = true;
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
            // openFileDialog
            // 
            this.openFileDialog.FileName = "empty";
            this.openFileDialog.InitialDirectory = @"C:\Users\Admin\source\repos\EasyImage\Image_Kernel";

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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Source:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kernel: ";
            // 
            // openKernel
            // 
            this.openKernel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openKernel.Location = new System.Drawing.Point(69, 119);
            this.openKernel.Name = "openKernel";
            this.openKernel.Size = new System.Drawing.Size(75, 31);
            this.openKernel.TabIndex = 5;
            this.openKernel.Text = "Open";
            this.openKernel.UseVisualStyleBackColor = true;
            this.openKernel.Click += new System.EventHandler(this.openKernel_Click);
            // 
            // listOperations
            // 
            this.listOperations.FormattingEnabled = true;
            this.listOperations.Location = new System.Drawing.Point(69, 25);
            this.listOperations.Name = "listOperations";
            this.listOperations.Size = new System.Drawing.Size(121, 24);
            this.listOperations.TabIndex = 6;
            this.listOperations.Text = "None";
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
            this.pictureGBox.ResumeLayout(false);
            this.pictureGBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.operationGbox.ResumeLayout(false);
            this.operationGbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabImage;
        private System.Windows.Forms.TabPage tabHisto;
        private System.Windows.Forms.GroupBox pictureGBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox operationGbox;
        private System.Windows.Forms.Label labelAfter;
        private System.Windows.Forms.Label labelBefore;
        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.Button openKernel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button openSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ComboBox listOperations;
    }
}

