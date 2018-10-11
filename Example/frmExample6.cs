using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Example
{
    public partial class frmExample6 : Form
    {
        public frmExample6()
        {
            InitializeComponent();
        }

        private void frmExample6_Load(object sender, EventArgs e)
        {
            //获取单元格绑定的子数据源
            this.GetSubDataSource();
            report1.CellDataSource.Add(new Gscr.CellDataSource("T_Department", dtDepartment, null, "Name", "Code"));
            report1.CellDataSource.Add(new Gscr.CellDataSource("T_Sex", dtSex, null, "Name", "Code"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                report1.SelectSQL = "SELECT * FROM Member";
                report1.SetDBConfiguration(DBConfig.ProviderName, DBConfig.ConnectionString);
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



        DataTable dtDepartment, dtSex;
        private void GetSubDataSource()
        {
            dtDepartment = DBAccess.GetDataTable("SELECT Code, Name FROM Department");
            dtSex = DBAccess.GetDataTable("SELECT Code, Name FROM Sex");
        }

        private void report1_CellClick(object sender, Gscr.CellEventArgs e)
        {
            if (this.report1.Rows[e.Cell.RowIndex].Band == Gscr.Band.Detail && e.Cell.ColumnIndex == 8)
            {
                if (!(e.Cell.Value == null || e.Cell.Value == DBNull.Value))
                {
                    System.Diagnostics.Process.Start(e.Cell.Value.ToString());
                }
            }
        }
    }
}
