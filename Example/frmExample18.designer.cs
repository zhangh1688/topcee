namespace Example
{
    partial class frmExample18
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Gscr.Column column1 = new Gscr.Column();
            Gscr.Column column2 = new Gscr.Column();
            Gscr.Column column3 = new Gscr.Column();
            Gscr.Column column4 = new Gscr.Column();
            Gscr.Column column5 = new Gscr.Column();
            Gscr.Column column6 = new Gscr.Column();
            Gscr.Column column7 = new Gscr.Column();
            Gscr.Column column8 = new Gscr.Column();
            Gscr.Column column9 = new Gscr.Column();
            Gscr.Row row1 = new Gscr.Row();
            Gscr.Cell cell1 = new Gscr.Cell();
            Gscr.Cell cell2 = new Gscr.Cell();
            Gscr.Cell cell3 = new Gscr.Cell();
            Gscr.Cell cell4 = new Gscr.Cell();
            Gscr.Cell cell5 = new Gscr.Cell();
            Gscr.Cell cell6 = new Gscr.Cell();
            Gscr.Cell cell7 = new Gscr.Cell();
            Gscr.Cell cell8 = new Gscr.Cell();
            Gscr.Cell cell9 = new Gscr.Cell();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExample18));
            Gscr.Row row2 = new Gscr.Row();
            Gscr.Cell cell10 = new Gscr.Cell();
            Gscr.Cell cell11 = new Gscr.Cell();
            Gscr.Cell cell12 = new Gscr.Cell();
            Gscr.Cell cell13 = new Gscr.Cell();
            Gscr.Cell cell14 = new Gscr.Cell();
            Gscr.Cell cell15 = new Gscr.Cell();
            Gscr.Cell cell16 = new Gscr.Cell();
            Gscr.Cell cell17 = new Gscr.Cell();
            Gscr.Cell cell18 = new Gscr.Cell();
            Gscr.SeriesHeaderStyle seriesHeaderStyle1 = new Gscr.SeriesHeaderStyle();
            this.btnSaveUseTran = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnSaveNoTran = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.report1 = new Gscr.Report();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveUseTran
            // 
            this.btnSaveUseTran.Location = new System.Drawing.Point(310, 28);
            this.btnSaveUseTran.Name = "btnSaveUseTran";
            this.btnSaveUseTran.Size = new System.Drawing.Size(94, 23);
            this.btnSaveUseTran.TabIndex = 6;
            this.btnSaveUseTran.Text = "保存(带事务)";
            this.btnSaveUseTran.UseVisualStyleBackColor = true;
            this.btnSaveUseTran.Click += new System.EventHandler(this.btnSaveUseTran_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(31, 28);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(94, 23);
            this.btnAddRow.TabIndex = 8;
            this.btnAddRow.Text = "增加行";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Location = new System.Drawing.Point(137, 28);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(94, 23);
            this.btnDeleteRow.TabIndex = 9;
            this.btnDeleteRow.Text = "删除当前行";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnSaveNoTran
            // 
            this.btnSaveNoTran.Location = new System.Drawing.Point(416, 28);
            this.btnSaveNoTran.Name = "btnSaveNoTran";
            this.btnSaveNoTran.Size = new System.Drawing.Size(94, 23);
            this.btnSaveNoTran.TabIndex = 10;
            this.btnSaveNoTran.Text = "保存(无事务)";
            this.btnSaveNoTran.UseVisualStyleBackColor = true;
            this.btnSaveNoTran.Click += new System.EventHandler(this.btnSaveNoTran_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(619, 28);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // report1
            // 
            this.report1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.report1.Barcode.EncodedType = Gscr.BarcodeLib.TYPE.UNSPECIFIED;
            this.report1.Barcode.EncodingTime = 0;
            this.report1.Barcode.Height = 150;
            this.report1.Barcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            this.report1.Barcode.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.report1.Barcode.RawData = "";
            this.report1.Barcode.Width = 300;
            column1.ColumnName = "ID";
            column2.ColumnName = "单据号";
            column3.ColumnName = "商品名称";
            column4.ColumnName = "颜色";
            column5.ColumnName = "规格";
            column6.ColumnName = "单位";
            column7.ColumnName = "数量";
            column8.ColumnName = "单价";
            column9.ColumnName = "金额";
            this.report1.Columns.AddRange(new Gscr.Column[] {
            column1,
            column2,
            column3,
            column4,
            column5,
            column6,
            column7,
            column8,
            column9});
            cell1.Alignment = System.Drawing.StringAlignment.Center;
            cell1.DataField = "ID";
            cell2.DataField = "单据号";
            cell3.DataField = "商品名称";
            cell3.ReadOnly = false;
            cell4.Alignment = System.Drawing.StringAlignment.Center;
            cell4.DataField = "颜色";
            cell4.ReadOnly = false;
            cell5.Alignment = System.Drawing.StringAlignment.Center;
            cell5.DataField = "规格";
            cell5.ReadOnly = false;
            cell6.Alignment = System.Drawing.StringAlignment.Center;
            cell6.DataField = "单位";
            cell6.ReadOnly = false;
            cell7.Alignment = System.Drawing.StringAlignment.Far;
            cell7.DataField = "数量";
            cell7.EditType = typeof(Gscr.Editer.ReportNumberTextBoxEditer);
            cell7.FormatString = "0.00";
            cell7.ReadOnly = false;
            cell8.Alignment = System.Drawing.StringAlignment.Far;
            cell8.DataField = "单价";
            cell8.EditType = typeof(Gscr.Editer.ReportNumberTextBoxEditer);
            cell8.FormatString = "0.00";
            cell8.ReadOnly = false;
            cell9.Alignment = System.Drawing.StringAlignment.Far;
            cell9.DataField = "金额";
            cell9.EditType = typeof(Gscr.Editer.ReportNumberTextBoxEditer);
            cell9.FormatString = "0.00";
            row1.Cells.AddRange(new Gscr.Cell[] {
            cell1,
            cell2,
            cell3,
            cell4,
            cell5,
            cell6,
            cell7,
            cell8,
            cell9});
            this.report1.DetailRows.AddRange(new Gscr.Row[] {
            row1});
            this.report1.Font = new System.Drawing.Font("宋体", 9F);
            this.report1.GscrID = ((Gscr.GscrID)(resources.GetObject("report1.GscrID")));
            cell10.Alignment = System.Drawing.StringAlignment.Center;
            cell10.Value = "ID";
            cell11.Alignment = System.Drawing.StringAlignment.Center;
            cell11.Value = "单据号";
            cell12.Alignment = System.Drawing.StringAlignment.Center;
            cell12.Value = "商品名称";
            cell13.Alignment = System.Drawing.StringAlignment.Center;
            cell13.Value = "颜色";
            cell14.Alignment = System.Drawing.StringAlignment.Center;
            cell14.Value = "规格";
            cell15.Alignment = System.Drawing.StringAlignment.Center;
            cell15.Value = "单位";
            cell16.Alignment = System.Drawing.StringAlignment.Center;
            cell16.Value = "数量";
            cell17.Alignment = System.Drawing.StringAlignment.Center;
            cell17.Value = "单价";
            cell18.Alignment = System.Drawing.StringAlignment.Center;
            cell18.Value = "金额";
            row2.Cells.AddRange(new Gscr.Cell[] {
            cell10,
            cell11,
            cell12,
            cell13,
            cell14,
            cell15,
            cell16,
            cell17,
            cell18});
            this.report1.HeaderRows.AddRange(new Gscr.Row[] {
            row2});
            this.report1.HighlightDisplayMouserOver = false;
            this.report1.IsExpandBackground = false;
            this.report1.Location = new System.Drawing.Point(13, 68);
            this.report1.Name = "report1";
            this.report1.PrintMargins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.report1.ReadOnly = false;
            this.report1.SelectionMode = Gscr.ReportSelectionMode.FullRowSelect;
            this.report1.SelectSQL = "Select BillDetail.* \nFrom BillMaster,BillDetail \nWhere BillMaster.单据号=BillDetail." +
                "单据号";
            this.report1.SeriesHeaderStyle = seriesHeaderStyle1;
            this.report1.Size = new System.Drawing.Size(923, 512);
            this.report1.TabIndex = 15;
            this.report1.Text = "report1";
            this.report1.UpdateTable = "BillDetail";
            this.report1.CellEndEdit += new System.EventHandler<Gscr.CellEventArgs>(this.report1_CellEndEdit);
            // 
            // frmExample18
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 592);
            this.Controls.Add(this.report1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveNoTran);
            this.Controls.Add(this.btnDeleteRow);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.btnSaveUseTran);
            this.Name = "frmExample18";
            this.Text = "示例18(把报表保存到数据库)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveUseTran;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnSaveNoTran;
        private System.Windows.Forms.Button btnClose;
        private Gscr.Report report1;
    }
}