namespace Example
{
    partial class frmExample19
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
            Gscr.Row row1 = new Gscr.Row();
            Gscr.Cell cell1 = new Gscr.Cell();
            Gscr.Cell cell2 = new Gscr.Cell();
            Gscr.Cell cell3 = new Gscr.Cell();
            Gscr.Cell cell4 = new Gscr.Cell();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExample19));
            Gscr.Row row2 = new Gscr.Row();
            Gscr.Cell cell5 = new Gscr.Cell();
            Gscr.Cell cell6 = new Gscr.Cell();
            Gscr.Cell cell7 = new Gscr.Cell();
            Gscr.Cell cell8 = new Gscr.Cell();
            Gscr.SeriesHeaderStyle seriesHeaderStyle1 = new Gscr.SeriesHeaderStyle();
            this.report1 = new Gscr.Report();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
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
            column1.ColumnName = "column1";
            column1.Width = 200;
            column2.ColumnName = "column2";
            column2.Width = 160;
            column3.ColumnName = "column3";
            column3.Width = 160;
            column4.ColumnName = "column4";
            column4.Width = 160;
            this.report1.Columns.AddRange(new Gscr.Column[] {
            column1,
            column2,
            column3,
            column4});
            cell1.Alignment = System.Drawing.StringAlignment.Center;
            cell1.DataField = "姓名";
            cell1.ReadOnly = false;
            cell2.DataField = "学校";
            cell2.EditType = typeof(Gscr.Editer.ReportTextBoxEditer);
            cell2.ReadOnly = false;
            cell3.Alignment = System.Drawing.StringAlignment.Center;
            cell3.DataField = "选修课";
            cell3.EditType = typeof(Gscr.Editer.ReportTextBoxEditer);
            cell3.ReadOnly = false;
            cell4.Alignment = System.Drawing.StringAlignment.Center;
            cell4.DataField = "备注";
            cell4.ReadOnly = false;
            row1.Cells.AddRange(new Gscr.Cell[] {
            cell1,
            cell2,
            cell3,
            cell4});
            row1.Height = 60;
            this.report1.DetailRows.AddRange(new Gscr.Row[] {
            row1});
            this.report1.DifferentRowColor = true;
            this.report1.FixedFooterRowsToBottom = true;
            this.report1.Font = new System.Drawing.Font("宋体", 9F);
            this.report1.GscrID = ((Gscr.GscrID)(resources.GetObject("report1.GscrID")));
            cell5.Alignment = System.Drawing.StringAlignment.Center;
            cell5.Value = "姓名";
            cell6.Alignment = System.Drawing.StringAlignment.Center;
            cell6.Value = "学校";
            cell7.Alignment = System.Drawing.StringAlignment.Center;
            cell7.Value = "选修课";
            cell8.Alignment = System.Drawing.StringAlignment.Center;
            cell8.Value = "备注";
            row2.Cells.AddRange(new Gscr.Cell[] {
            cell5,
            cell6,
            cell7,
            cell8});
            row2.Height = 40;
            this.report1.HeaderRows.AddRange(new Gscr.Row[] {
            row2});
            this.report1.HighlightDisplayMouserOver = false;
            this.report1.Location = new System.Drawing.Point(5, 77);
            this.report1.Name = "report1";
            this.report1.PrintMargins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.report1.ReadOnly = false;
            this.report1.SelectionMode = Gscr.ReportSelectionMode.FullRowSelect;
            this.report1.SelectSQL = "SELECT * FROM Member";
            this.report1.SeriesHeaderStyle = seriesHeaderStyle1;
            this.report1.Size = new System.Drawing.Size(945, 569);
            this.report1.TabIndex = 0;
            this.report1.Text = "report1";
            this.report1.CellBeginEdit += new System.EventHandler<Gscr.CellCancelEventArgs>(this.report1_CellBeginEdit);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(330, 29);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 55;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(224, 29);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(75, 23);
            this.btnAddRow.TabIndex = 56;
            this.btnAddRow.Text = "增加行";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // frmExample19
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 652);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.report1);
            this.Name = "frmExample19";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Example19(自定义编辑控件)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmExample19_Load);
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gscr.Report report1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddRow;
    }
}