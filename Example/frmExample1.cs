using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Example
{
    public partial class frmExample1 : Form
    {
        public frmExample1()
        {
            InitializeComponent();
        }

        private void frmExample1_Load(object sender, EventArgs e)
        {
            textBox1.Text = DBConfig.ProviderName;
            richTextBox1.Text = DBConfig.ConnectionString;
            richTextBox2.Text = "SELECT * FROM Member";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                report1.AutoGenerateColumns = true;
                report1.SelectSQL = richTextBox2.Text;
                
                report1.SetDBConfiguration(textBox1.Text, richTextBox1.Text);
                report1.Retrieve();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            report1.PrintPreview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            report1.SaveAs();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            report1.ReSet();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void report1_SelectionChanged(object sender, EventArgs e)
        {
            //double sum = 0, cellNumber = 0;
            //foreach (Gscr.Cell cell in report1.SelectedCells)
            //{
            //    if (cell.FormatValue == null || cell.FormatValue == DBNull.Value)
            //    {
            //        continue;
            //    }

            //    if (double.TryParse(cell.FormatValue.ToString(), out cellNumber))
            //    {
            //        sum += cellNumber;
            //    }
            //}
            //label4.Text = "求和=" + sum.ToString();
        }
    }
}
