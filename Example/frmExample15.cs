using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Example
{
    public partial class frmExample15 : Form
    {
        public frmExample15()
        {
            InitializeComponent();
        }

        private void frmExample15_Load(object sender, EventArgs e)
        {
            //获取单元格绑定的子数据源
            List<Unit> unitList = new List<Unit>();
            unitList.Add(new Unit(1, "个"));
            unitList.Add(new Unit(2, "双"));
            unitList.Add(new Unit(3, "台"));

            report1.CellDataSource.Add(new Gscr.CellDataSource("T_Unit", unitList, null, "UnitName", "ID"));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //单据号等隐藏重复值
            report1.Columns[0].HideSameItem = checkBox1.Checked;
            report1.Columns[1].HideSameItem = checkBox1.Checked;
            report1.Columns[2].HideSameItem = checkBox1.Checked;
            report1.Columns[3].HideSameItem = checkBox1.Checked;
            
            List<Bill> list = ListData.Select();
            report1.DataSource = list;
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
