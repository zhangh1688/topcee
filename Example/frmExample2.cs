using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Example
{
    public partial class frmExample2 : Form
    {
        public frmExample2()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            report1.PrintPreview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            report1.SaveAs();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                report1.SelectSQL = "Select * From Sale Order By Product ";
                report1.SetDBConfiguration(DBConfig.ProviderName, DBConfig.ConnectionString);
                report1.Retrieve();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void frmExample2_Load(object sender, EventArgs e)
        {

        }


    }
}
