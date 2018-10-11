using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Example
{
    public partial class frmExample19 : Form
    {
        public frmExample19()
        {
            InitializeComponent();
        }

        private void frmExample19_Load(object sender, EventArgs e)
        {
            //设置单元格的编辑格式           
            report1.DetailRows[0].Cells[2].EditType = typeof(Example.ReportCheckedListBoxEditer);

            //增加1空行
            report1.AddRow(Gscr.Band.Detail);
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            //增加行
            report1.AddRow(Gscr.Band.Detail);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 单元格开始编辑时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void report1_CellBeginEdit(object sender, Gscr.CellCancelEventArgs e)
        {
            if (this.report1.Rows[e.Cell.RowIndex].Band == Gscr.Band.Detail && e.Cell.ColumnIndex == 2)
            {
                //编辑的是<选修课>列，对<选修课>列的编辑控件ReportCheckedListBoxEditer进行配置
                if (report1.EditingControl != null && report1.EditingControl is Example.ReportCheckedListBoxEditer)
                {
                    Example.ReportCheckedListBoxEditer editer = ((Example.ReportCheckedListBoxEditer)report1.EditingControl);

                    //增加项
                    editer.Items.Add("电子信息");
                    editer.Items.Add("会计");
                    editer.Items.Add("计算机");

                    //初始化ReportCheckedListBoxEditer值，即把单元格的值赋给ReportCheckedListBoxEditer控件
                    editer.InitEditControlValue(e.Cell);
                }
            }

        }



    }
}
