using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Example
{
    public partial class frmExample20 : Form
    {
        public frmExample20()
        {
            InitializeComponent();
        }

        private void frmExample20_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                string sql = " SELECT B.Name AS 部门, SUM(工作完成量) AS 工作完成量 " +
                             " FROM Member A, Department B " +
                             " WHERE A.部门 = B.Code "+
                             " GROUP BY B.Name";

                DataTable dtblData = DBAccess.GetDataTable(sql);

                report1.DataSource = dtblData;

                //绑定数据源
                report1.DataBind();

                //MsChart图表
                this.FillChartData(dtblData);

                //在行列索引3, 2, 9, 2围成的单元格区域内，嵌入MsChart图表
                report1.CellEmbedChart(chart1, 3, 2, 9, 2);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            this.Cursor = Cursors.Arrow;
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

        /// <summary>
        /// MsChart图表
        /// </summary>
        /// <param name="dtblData"></param>
        private void FillChartData(DataTable dtblData)
        {
            try
            {
                this.chart1.ChartAreas.Clear();
                this.chart1.Legends.Clear();
                this.chart1.Series.Clear();

                System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
                chartArea1.BackColor = System.Drawing.Color.Transparent;
                chartArea1.Name = "ChartArea1";
                //不显示X轴的图表中间的分割线
                chartArea1.AxisX.MajorGrid.Enabled = false;

                this.chart1.ChartAreas.Add(chartArea1);


                System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
                legend1.BackColor = System.Drawing.Color.Transparent;
                legend1.Name = "Legend1";
                this.chart1.Legends.Add(legend1);


                System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
                series1.ChartArea = "ChartArea1";
                series1.Legend = "Legend1";
                series1.Name = "工作量";
                series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                series1.Color = Color.Red;
                this.chart1.Series.Add(series1);

                for (int i = 0; i < dtblData.Rows.Count; i++)
                {
                    series1.Points.AddXY(dtblData.Rows[i]["部门"], dtblData.Rows[i]["工作完成量"]);
                }
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show("查询失败。" + err.Message,
                    "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
            }
        }

        private void report1_CellClick(object sender, Gscr.CellEventArgs e)
        {
            if (e.Cell.RowIndex == 1 && e.Cell.ColumnIndex == 2)
            {
                System.Diagnostics.Process.Start("http://www.microsoft.com/zh-cn/download/details.aspx?id=14422");
            }
        }


    }
}
