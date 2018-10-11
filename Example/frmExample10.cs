using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Example
{
    public partial class frmExample10 : Form
    {
        public frmExample10()
        {
            InitializeComponent();
        }

        private void frmExample10_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //方法1：Retrieve方法，使用System.Data.OleDb
            string sql = "Select * From  Member";

            try
            {
                //数据库配置
                report1.SetDBConfiguration(DBConfig.ProviderName, DBConfig.ConnectionString);

                //赋值sql语句
                report1.SelectSQL = sql;

                //检索数据
                report1.Retrieve();
            }
            catch (Exception err)
            {
                MessageBox.Show("查询失败。" + err.Message,
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //方法1：Retrieve方法,使用System.Data.Odbc
            string providerName = "System.Data.Odbc";
            string connectionString = "Driver={Microsoft Access Driver (*.mdb)};" + @"Dbq=" + Application.StartupPath + "\\Data.mdb;" + "Uid=Admin;Pwd=;";
            string sql = "Select * From  Member";

            try
            {
                //数据库配置
                report1.SetDBConfiguration(providerName, connectionString);

                //赋值sql语句
                report1.SelectSQL = sql;

                //检索数据
                report1.Retrieve();
            }
            catch (Exception err)
            {
                MessageBox.Show("查询失败。" + err.Message,
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //方法2：DataBind方法
            string sql = "Select * From  Member";

            DataTable dt = DBAccess.GetDataTable(sql);

            report1.DataSource = dt;

            //绑定数据源dt
            report1.DataBind();
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
