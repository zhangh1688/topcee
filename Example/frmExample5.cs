using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Example
{
    public partial class frmExample5 : Form
    {
        public frmExample5()
        {
            InitializeComponent();
        }

        private void frmExample5_Load(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = report1.AddRow(Gscr.Band.Detail);
                report1[index, 3].Value = "您添加的产品...";
                report1[index + 1, 3].Value = "您添加的供应商...";
                report1[index + 2, 3].Value = "您添加的简介...";
                report1[index + 3, 3].Value = 800;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                report1.SelectSQL = "Select * From Product ";
                report1.SetDBConfiguration(DBConfig.ProviderName, DBConfig.ConnectionString);
                report1.Retrieve();

                report1[2, 1].Value = Image.FromFile(Application.StartupPath + "\\01.png");
                report1[6, 1].Value = Image.FromFile(Application.StartupPath + "\\02.png");
                report1[10, 1].Value = Image.FromFile(Application.StartupPath + "\\03.png");
                report1[14, 1].Value = Image.FromFile(Application.StartupPath + "\\04.png");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (report1.CurrentCell == null)
                {
                    MessageBox.Show("请选择要删除的记录。","错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (report1.Rows[report1.CurrentCell.RowIndex].Band != Gscr.Band.Detail)
                {
                    MessageBox.Show("请选择要删除的明细记录。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Gscr.Band band;
                int index = report1.RowsIndexToBandIndex(report1.CurrentCell.RowIndex, out band);
                report1.DeleteRow(band, index);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

    }
}
