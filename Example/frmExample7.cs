using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Example
{
    public partial class frmExample7 : Form
    {
        public frmExample7()
        {
            InitializeComponent();
        }

        private void frmExample7_Load(object sender, EventArgs e)
        {
            //获取单元格绑定的子数据源
            this.GetSubDataSource();

            //<部门>绑定的子数据源，使用的数据源来自数据库
            Gscr.CellDataSource cdsDepartment = new Gscr.CellDataSource("T_Department", dtDepartment, null, "Name", "Code");
            report1.CellDataSource.Add(cdsDepartment);

            //<性别>绑定的子数据源，使用的数据源来自固定值，通过自创表
            Gscr.CellDataSource cdsSex = new Gscr.CellDataSource("T_Sex", dtSex, null, "Name", "Code");
            report1.CellDataSource.Add(cdsSex);

            //<职务>绑定的子数据源，使用的数据源来自数据库
            Gscr.CellDataSource cdsPost = new Gscr.CellDataSource("T_Post", dtPost, null, "Name", "Code");
            report1.CellDataSource.Add(cdsPost);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //检索数据
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
            //报表打印预览
            report1.PrintPreview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //报表另存为
            report1.SaveAs();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //报表重置
            report1.ReSet();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private DataTable dtDepartment, dtSex, dtPost;
        /// <summary>
        /// 获取单元格绑定的子数据源
        /// </summary>
        private void GetSubDataSource()
        {
            //部门列
            dtDepartment = DBAccess.GetDataTable("SELECT Code, Name FROM Department");
            //把report2作为<部门>的选择数据
            report2.DataSource = dtDepartment;
            report2.DataBind();

            //性别，构造表，插入数据，1：男，2：女
            dtSex = new DataTable();
            dtSex.Columns.Add("Code", typeof(string));
            dtSex.Columns.Add("Name", typeof(string));

            DataRow dr = dtSex.NewRow();
            dr["Code"] = "1";
            dr["Name"] = "男";
            dtSex.Rows.Add(dr);

            dr = dtSex.NewRow();
            dr["Code"] = "2";
            dr["Name"] = "女";

            dtSex.Rows.Add(dr);

            //职务
            dtPost = DBAccess.GetDataTable("SELECT Code, Name FROM Post");
        }


        /// <summary>
        /// 单元格开始编辑时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void report1_CellBeginEdit(object sender, Gscr.CellCancelEventArgs e)
        {
            if (this.report1.Rows[e.Cell.RowIndex].Band == Gscr.Band.Detail && e.Cell.ColumnIndex == 4)
            {
                //编辑的是<部门>列，对<部门>列的编辑控件ReportFindEditer进行配置
                if (report1.EditingControl != null && report1.EditingControl is Gscr.Editer.ReportFindEditer)
                {
                    //获取<部门>列的编辑控件
                    Gscr.Editer.ReportFindEditer editer = ((Gscr.Editer.ReportFindEditer)report1.EditingControl);

                    //ReportFindEditer增量查询时，对应的列索引，本例选择的是<Code>，索引为0
                    editer.FindColumnIndex = 0;

                    //ReportFindEditer要选择的值所在的索引，本例选择的是<Code>，索引为0
                    editer.ValueColumnIndex = 0;

                    //配置ReportFindEditer报表的数据源
                    Gscr.Report rpt = editer.PopupControl.report1;

                    ////把report2的整个报表包括数据复制给ReportFindEditer报表
                    report2.CopyReport(rpt, false);


                    ////你也可以如下写
                    ////自动创建列
                    //rpt.AutoGenerateColumns = true;
                    ////设置数据源
                    //rpt.DataSource = dtDepartment;
                    ////绑定数据源
                    //rpt.DataBind();


                }
            }

            if (this.report1.Rows[e.Cell.RowIndex].Band == Gscr.Band.Detail && e.Cell.ColumnIndex == 7)
            {
                //编辑的是<应发款>列，对<应发款>列的编辑控件ReportNumberTextBoxEditer进行配置
                if (report1.EditingControl != null && report1.EditingControl is Gscr.Editer.ReportNumberTextBoxEditer)
                {
                    //获取<应发款>列的编辑控件
                    Gscr.Editer.ReportNumberTextBoxEditer editer = ((Gscr.Editer.ReportNumberTextBoxEditer)report1.EditingControl);
                    //设置为输入四位小数
                    editer.NumberDecimalDigits = 4;
                    editer.SelectAll();
                }
            }

            if (this.report1.Rows[e.Cell.RowIndex].Band == Gscr.Band.Detail && report1.Columns[e.Cell.ColumnIndex].ColumnName=="出生日期" )
            {
                //编辑的是<出生日期>列，对<出生日期>列的编辑控件ReportDateTimePickerEditer进行配置
                if (report1.EditingControl != null && report1.EditingControl is Gscr.Editer.ReportDateTimePickerEditer)
                {
                    //获取<出生日期>列的编辑控件
                    Gscr.Editer.ReportDateTimePickerEditer editer = ((Gscr.Editer.ReportDateTimePickerEditer)report1.EditingControl);
                    editer.FormatCustom = "yyyy-MM-dd hh:mm:ss";
                    editer.Format = Gscr.Controls.DateTimePickerFormat.LongDateTime;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            report1.ReadOnly = false;

            //增加行
            int index = report1.AddRow(Gscr.Band.Detail);

            //滚动到增加的行
            report1.ScrollRows(index);

            //设置当前单元格
            report1.SetCurrentCell(report1[index, 1]);

            if (!report1.IsCurrentCellInEditMode)
            {
                //进入编辑模式
                report1.IsCurrentCellInEditMode = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //删除当前单元格所在的行
                if (report1.CurrentCell != null)
                {
                    report1.DeleteRow(report1.CurrentCell.RowIndex);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            //获取修改过的行
            string tip = "修改过的行：";
            for (int i = 0; i < report1.Rows.Count; i++)
            {
                Gscr.Row row = report1.Rows[i];
                if (row.CellValueChanged)
                {
                    tip += i.ToString() + " ";
                }
            }
            
            MessageBox.Show(tip, "提示");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //选择单元格选择模式，还是整行选择模式
            if (button8.Text == "整行选择")
            {
                button8.Text = "单元格选择";
                report1.SelectionMode = Gscr.ReportSelectionMode.FullRowSelect;
            }
            else
            {
                button8.Text = "整行选择";
                report1.SelectionMode = Gscr.ReportSelectionMode.CellSelect;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //打开设计器，可以对报表进行重新设计
            Gscr.Designer.frmReportDesigner frmReportDesigner = new Gscr.Designer.frmReportDesigner();
            
            frmReportDesigner.SetContextReport(report1);
            
            frmReportDesigner.ShowDialog();
        }

        private void report1_OpenCustomDlgEdier(object sender, Gscr.CustomDlgEditerEventArgs e)
        {
            if (this.report1.Rows[e.Cell.RowIndex].Band == Gscr.Band.Detail && e.Cell.ColumnIndex == 5)
            {
                //编辑<性别>列，弹出性别的选择窗口
                frmSelectSex dlg = new frmSelectSex();

                dlg.Sex = e.Cell.Value.ToString();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //把新选择的值赋给单元格
                    e.NewValue = dlg.Sex;
                }
            }
        }

        private void report1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F2:
                    MessageBox.Show("写入你的KeyDown代码，你按下了" + e.KeyCode.ToString() + "键。");
                    break;
            }

        }
    }
}
