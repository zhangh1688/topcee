using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Example
{
    public partial class frmExample9 : Form
    {
        public frmExample9()
        {
            InitializeComponent();
        }

        private void frmExample8_Load(object sender, EventArgs e)
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

                report1.Sort("column2");
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

    }
}
