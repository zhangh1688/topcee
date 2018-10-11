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
    public partial class frmExample13 : Form
    {
        public frmExample13()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //清空报表
            report1.ClearReport();

            //设置报表为非只读
            report1.ReadOnly = false;

            //标题
            report1.AddRow(Gscr.Band.Title);

            //列标题
            report1.AddRow(Gscr.Band.Header);

            //明细行
            report1.AddRow(Gscr.Band.Detail); //临时创建Detail行
            report1.DetailRows.Insert(0, (Gscr.Row)report1.Rows[2].Clone());//把临时创建的Detail行克隆到设计时的DetailRows行信息
            report1.DeleteRow(Gscr.Band.Detail, 0); //删除临时创建的Detail行

            //产生2列
            report1.AddColumn(2);
            //第1列：姓名
            //标题名称
            report1.HeaderRows[0].Cells[0].Value = "姓名";
            //明细行关联字段
            report1.DetailRows[0].Cells[0].DataField = "姓名";
            //居中
            report1.DetailRows[0].Cells[0].Alignment = StringAlignment.Center;

            //第1列：证件号
            //标题名称
            report1.HeaderRows[0].Cells[1].Value = "证件号";
            //明细行关联字段
            report1.DetailRows[0].Cells[1].DataField = "证件号";
            //列的长度
            report1.Columns[1].Width = 300;


            //标题行居中
            for (int i = 0; i < report1.ColumnCount; i++)
            {
                report1.HeaderRows[0].Cells[i].LineAlignment = StringAlignment.Center;
                report1.HeaderRows[0].Cells[i].Alignment = StringAlignment.Center;
            }
            //标题
            report1.TitleRows[0].Cells[0].Value = "人员信息一览表";
            report1.TitleRows[0].Cells[0].LineAlignment = StringAlignment.Center;
            report1.TitleRows[0].Cells[0].Alignment = StringAlignment.Center;
            report1.TitleRows[0].Cells[0].Font = new Font("宋体", 20);
            report1.TitleRows[0].Height = 40;
            //合并Title行
            report1.MergeCells(0, 0, 0, report1.ColumnCount - 1);

            //方法2：DataBind方法
            string sql = "Select * From  Member";
            report1.SelectSQL = sql;
            DataTable dt = DBAccess.GetDataTable(sql);
            report1.DataSource = dt;

            //绑定数据源dt
            report1.DataBind();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清空报表
            report1.ClearReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmExample13_Load(object sender, EventArgs e)
        {

        }

    }
}
