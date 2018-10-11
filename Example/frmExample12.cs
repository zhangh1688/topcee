using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Example
{
    public partial class frmExample12 : Form
    {
        public frmExample12()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //设计报表
            Gscr.Designer.frmReportDesigner frmReportDesigner = new Gscr.Designer.frmReportDesigner();
            //设置需要设计的报表
            frmReportDesigner.SetContextReport(report1);
            //数据库配置(可以注释)
            frmReportDesigner.reportDesign1.SetDBConfiguration(DBConfig.ProviderName, DBConfig.ConnectionString);
            frmReportDesigner.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //==============================
            //把报表保存到数据库
            //==============================
            try
            {
                string fileName = Application.StartupPath + "\\ABC.gsc";
                report1.SaveasGSCFile(fileName);

                FileInfo fi = new FileInfo(fileName);
                FileStream fs = fi.OpenRead();
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));


                OleDbConnection cn = new OleDbConnection();
                cn.ConnectionString = DBConfig.ConnectionString;
                if (cn.State == 0)
                    cn.Open();


                OleDbCommand cmDelete = new OleDbCommand();
                cmDelete.Connection = cn;
                cmDelete.CommandType = CommandType.Text;
                cmDelete.CommandText = "Delete From T_RptFile";
                cmDelete.ExecuteNonQuery();

                OleDbCommand cm = new OleDbCommand();
                cm.Connection = cn;
                cm.CommandType = CommandType.Text;
                cm.CommandText = "Insert Into T_RptFile(Col1) Values(@file)";
                OleDbParameter spFile = new OleDbParameter("@file", OleDbType.Binary);
                spFile.Value = bytes;
                cm.Parameters.Add(spFile);
                cm.ExecuteNonQuery();

                fs.Close();
                cn.Close();

                MessageBox.Show("报表成功保存到数据库表T_RptFile中。",
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("保存失败。" + err.Message,
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            //==============================
            //把报表保存到数据库，以下是SQLServer的例子，列Col1数据类型image
            //==============================
            //string fileName = Application.StartupPath + "\\ABC.gsc";
            //report1.SaveasGSCFile(fileName);

            //FileInfo fi = new FileInfo(fileName);
            //FileStream fs = fi.OpenRead();
            //byte[] bytes = new byte[fs.Length];
            //fs.Read(bytes, 0, Convert.ToInt32(fs.Length));


            //SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = "Data Source=(local);User ID=sa;Password=;Initial Catalog=BYZX";
            //if (cn.State == 0)
            //    cn.Open();

            //SqlCommand cm = new SqlCommand();
            //cm.Connection = cn;
            //cm.CommandType = CommandType.Text;
            //cm.CommandText = "insert into T_RptFile(Col1) values(@file)";
            //SqlParameter spFile = new SqlParameter("@file", SqlDbType.Image);
            //spFile.Value = bytes;
            //cm.Parameters.Add(spFile);
            //cm.ExecuteNonQuery();

            //fs.Close();
            //cn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //==============================
            //从数据库读取报表
            //==============================
            try
            {
                string fileName = Application.StartupPath + "\\ABC.gsc";
                OleDbDataReader dr = null;
                OleDbConnection cn = new OleDbConnection();
                cn.ConnectionString = DBConfig.ConnectionString;
                cn.Open();

                OleDbCommand cm = new OleDbCommand();
                cm.Connection = cn;
                cm.CommandType = CommandType.Text;
                cm.CommandText = "select Top 1 Col1 from T_RptFile";
                dr = cm.ExecuteReader();
                byte[] fileByte = null;
                if (dr.Read())
                {
                    fileByte = (byte[])dr[0];
                }

                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(fileByte, 0, fileByte.Length);
                bw.Close();
                fs.Close();

                report1.OpenGSCFile(fileName);

                cn.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show("从数据库表T_RptFile中读取报表失败。" + err.Message,
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


            //==============================
            //从数据库读取报表，以下是SQLServer的例子，列Col1数据类型image
            //==============================
            //string fileName = Application.StartupPath + "\\ABC.gsc";
            //SqlDataReader dr = null;
            //SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = "Data Source=(local);User ID=sa;Password=;Initial Catalog=BYZX";
            //cn.Open();

            //SqlCommand cm = new SqlCommand();
            //cm.Connection = cn;
            //cm.CommandType = CommandType.Text;
            //cm.CommandText = "select Top 1 Col1 from T_RptFile";
            //dr = cm.ExecuteReader();
            //byte[] fileByte = null;
            //if (dr.Read())
            //{
            //    fileByte = (byte[])dr[0];
            //}

            //FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            //BinaryWriter bw = new BinaryWriter(fs);
            //bw.Write(fileByte, 0, fileByte.Length);
            //bw.Close();
            //fs.Close();

            //report1.OpenGSCFile(fileName);

            //cn.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmExample12_Load(object sender, EventArgs e)
        {

        }
    }
}
