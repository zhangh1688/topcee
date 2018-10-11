using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Example
{
    public partial class frmExample11 : Form
    {
        public frmExample11()
        {
            InitializeComponent();
        }

        private void frmExample11_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //数据库配置
                report1.SetDBConfiguration(DBConfig.ProviderName, DBConfig.ConnectionString);

                //检索数据---输入参数检索
                object[] parms = new object[1];
                if (radioButton1.Checked)
                {
                    parms[0] = "1";
                }
                else
                {
                    parms[0] = "0";
                }
                report1.Retrieve(parms);
            }
            catch (Exception err)
            {
                MessageBox.Show("查询失败。" + err.Message,
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //数据库配置
                report1.SetDBConfiguration(DBConfig.ProviderName, DBConfig.ConnectionString);

                //检索数据---无参数
                report1.Retrieve();
            }
            catch (Exception err)
            {
                MessageBox.Show("查询失败。" + err.Message,
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

    }
}
