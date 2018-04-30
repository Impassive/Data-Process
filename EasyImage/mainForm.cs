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
        public string image = "";
        public string kernel = "";
        public mainForm()
        {
            InitializeComponent();
        }

        private void openKernel_Click(object sender, EventArgs e)
        {
            while (openFileDialog.FileName == "empty")
            {
                openFileDialog.ShowDialog();
                image = openFileDialog.FileName;
            }

            openFileDialog.FileName = "empty";
        }

        private void openSource_Click(object sender, EventArgs e)
        {
            while (openFileDialog.FileName == "empty")
            {
                openFileDialog.ShowDialog();
                kernel = openFileDialog.FileName;
            }

            openFileDialog.FileName = "empty";
        }
    }
}
