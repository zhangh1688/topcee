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
    public partial class frmExample14 : Form
    {
        public frmExample14()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //清空报表
            report1.ClearReport();

            //设置报表为非只读
            report1.ReadOnly = false;

            //报表停止公式计算，这样速度快点
            report1.CalcFormula(false);
            //报表停止绘制
            report1.AllowDraw(false);

            string fileName = Application.StartupPath + "\\Test.xls";
            NPOI.HSSF.UserModel.HSSFWorkbook hssfworkbook;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new NPOI.HSSF.UserModel.HSSFWorkbook(fileStream);
                    NPOI.HSSF.UserModel.HSSFSheet sheet = hssfworkbook.GetSheetAt(0);

                    if (sheet.LastRowNum == 0)
                    {
                        this.Cursor = Cursors.Arrow;
                        return;
                    }
                    else
                    {
                        //产生列
                        NPOI.HSSF.UserModel.HSSFRow row = sheet.GetRow(0);
                        //report1.AddColumn(row.Cells.Count);
                        report1.AddColumn(row.LastCellNum);
                    }

                    int rowIndex = 0;
                    System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                    while (rows.MoveNext())
                    {

                        //增加行
                        rowIndex = report1.AddRow(Gscr.Band.Detail);

                        NPOI.HSSF.UserModel.HSSFRow row = (NPOI.HSSF.UserModel.HSSFRow)rows.Current;
                        for (int i = 0; i < row.LastCellNum; i++)
                        {
                            Gscr.Cell cellRpt = report1[rowIndex, i];

                            NPOI.HSSF.UserModel.HSSFCell cell = row.GetCell(i);
                            if (cell == null)
                            {
                                cellRpt.Value = null;
                            }
                            else
                            {
                                switch (cell.CellType)
                                {
                                    case NPOI.HSSF.UserModel.HSSFCellType.BLANK:
                                        cellRpt.Value = null;
                                        break;

                                    case NPOI.HSSF.UserModel.HSSFCellType.BOOLEAN:
                                        cellRpt.Value = cell.BooleanCellValue;
                                        break;

                                    case NPOI.HSSF.UserModel.HSSFCellType.NUMERIC:
                                        cellRpt.Value = cell.ToString();
                                        break;

                                    case NPOI.HSSF.UserModel.HSSFCellType.STRING:
                                        cellRpt.Value = cell.StringCellValue;
                                        break;

                                    case NPOI.HSSF.UserModel.HSSFCellType.ERROR:
                                        cellRpt.Value = cell.ErrorCellValue;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }

                //报表恢复公式计算
                report1.CalcFormula(true);
                //报表恢复绘制
                report1.AllowDraw(true);
                this.Cursor = Cursors.Arrow;

                MessageBox.Show("成功读取Excel文件【" + fileName + " 】。",
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                report1.CalcFormula(true);
                report1.AllowDraw(true);

                this.Cursor = Cursors.Arrow;
                MessageBox.Show("读取Excel文件失败。" + err.Message,
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }

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

        private void frmExample14_Load(object sender, EventArgs e)
        {

        }

    }
}
