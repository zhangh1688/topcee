using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Example
{
    public partial class frmExample4 : Form
    {
        public frmExample4()
        {
            InitializeComponent();
        }

        private void frmExample4_Load(object sender, EventArgs e)
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
            try
            {
                report1.SelectSQL = "Select * From Print Where XM='东方不败' ";
                report1.SetDBConfiguration(DBConfig.ProviderName, DBConfig.ConnectionString);
                report1.Retrieve();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            report1.Print();
        }

        private void report1_CellClick(object sender, Gscr.CellEventArgs e)
        {
            if (e.Cell.RowIndex == 1 && e.Cell.ColumnIndex == 5)
            {
                MessageBox.Show("你点击了<" + e.Cell.Tag.ToString() + ">", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (e.Cell.RowIndex == 9 && e.Cell.ColumnIndex == 5)
            {
                MessageBox.Show("你点击了<" + e.Cell.Value.ToString() + ">", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void report1_Click(object sender, EventArgs e)
        {

        }
    }
}
