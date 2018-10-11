using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Example
{
    public partial class frmExample18 : Form
    {

        public frmExample18()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //检索数据
            this.RetrieveData();
        }


        private void btnAddRow_Click(object sender, EventArgs e)
        {
            int rowIndex = this.report1.AddRow(Gscr.Band.Detail);
            //设置单据号初始值
            this.report1[rowIndex, 1].Value = "000001";

            Gscr.Cell cell = report1[rowIndex, "商品名称"];
            if (cell != null)
            {
                this.report1.SetCurrentCell(cell);
            }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (this.report1.CurrentCell == null)
            {
                return;
            }

            if (this.report1.Rows[this.report1.CurrentCell.RowIndex].Band == Gscr.Band.Detail)
            {
                int rowIndex = this.report1.CurrentCell.RowIndex;
                int columnIndex = this.report1.CurrentCell.ColumnIndex;

                this.report1.DeleteRow(this.report1.CurrentCell.RowIndex);

                //重新定位当前行
                if (rowIndex >= this.report1.RowCount)
                {
                    rowIndex = this.report1.RowCount - 1;
                }
                Gscr.Cell cell = report1[rowIndex, columnIndex];
                if (cell != null)
                {
                    this.report1.SetCurrentCell(cell);
                }
            }
            else
            {
                MessageBox.Show("当前行属于非明细行，不必删除。",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        private void btnSaveUseTran_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(DBConfig.ConnectionString))
                {
                    //打开数据库连接
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    using (OleDbTransaction trans = conn.BeginTransaction())
                    {
                        //提交编辑
                        this.report1.CommitEdit();

                        //更新数据
                        int count = this.report1.UpdateDb(trans, 30);

                        //提交事务
                        trans.Commit();
                        
                        MessageBox.Show("提交成功，影响行数" + count.ToString() + "。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        //重新检索数据
                        this.RetrieveData();
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnSaveNoTran_Click(object sender, EventArgs e)
        {
            report1.ProviderName = DBConfig.ProviderName;
            report1.ConnectionString = DBConfig.ConnectionString;
            try
            {
                //提交编辑
                this.report1.CommitEdit();

                //更新数据
                int count = this.report1.UpdateDb(null, 30);

                MessageBox.Show("保存成功，影响行数" + count.ToString() + "。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                //重新检索数据
                this.RetrieveData();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void report1_CellEndEdit(object sender, Gscr.CellEventArgs e)
        {
            if (e.Cell != null)
            {
                if (this.report1.Rows[e.Cell.RowIndex].Band == Gscr.Band.Detail)
                {
                    if (this.report1.Columns[e.Cell.ColumnIndex].ColumnName == "数量" ||
                        this.report1.Columns[e.Cell.ColumnIndex].ColumnName == "单价")
                    {
                        this.report1[e.Cell.RowIndex, "金额"].Value = Decimal.Parse(this.report1[e.Cell.RowIndex, "数量"].Value.ToString()) * Decimal.Parse(this.report1[e.Cell.RowIndex, "单价"].Value.ToString());
                    }
                }
            }
        }


        /// <summary>
        /// 检索数据
        /// </summary>
        private void RetrieveData()
        {
            try
            {
                string sql = " Select * From BillDetail ";
                DataTable dt = DBAccess.GetDataTable(sql);

                report1.DataSource = dt;
                report1.DataBind();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }



    }
}