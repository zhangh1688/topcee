using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Example
{
    public partial class frmExample3 : Form
    {
        public frmExample3()
        {
            InitializeComponent();
        }

        private void frmExample3_Load(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            report1.PrintPreview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            report1.SaveAs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //设置单元格的值
            report1[5, 2].Value = 150000;
            report1[5, 3].Value = 210000;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void report1_CellClick(object sender, Gscr.CellEventArgs e)
        {

        }

    }
}
