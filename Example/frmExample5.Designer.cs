namespace Example
{
    partial class frmExample5
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
            Gscr.Row row1 = new Gscr.Row();
            Gscr.Cell cell1 = new Gscr.Cell();
            Gscr.Cell cell2 = new Gscr.Cell();
            Gscr.Cell cell3 = new Gscr.Cell();
            Gscr.Cell cell4 = new Gscr.Cell();
            Gscr.Cell cell5 = new Gscr.Cell();
            Gscr.Row row2 = new Gscr.Row();
            Gscr.Cell cell6 = new Gscr.Cell();
            Gscr.Cell cell7 = new Gscr.Cell();
            Gscr.Cell cell8 = new Gscr.Cell();
            Gscr.Cell cell9 = new Gscr.Cell();
            Gscr.Cell cell10 = new Gscr.Cell();
            Gscr.Row row3 = new Gscr.Row();
            Gscr.Cell cell11 = new Gscr.Cell();
            Gscr.Cell cell12 = new Gscr.Cell();
            Gscr.Cell cell13 = new Gscr.Cell();
            Gscr.Cell cell14 = new Gscr.Cell();
            Gscr.Cell cell15 = new Gscr.Cell();
            Gscr.Row row4 = new Gscr.Row();
            Gscr.Cell cell16 = new Gscr.Cell();
            Gscr.Cell cell17 = new Gscr.Cell();
            Gscr.Cell cell18 = new Gscr.Cell();
            Gscr.Cell cell19 = new Gscr.Cell();
            Gscr.Cell cell20 = new Gscr.Cell();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExample5));
            Gscr.Row row5 = new Gscr.Row();
            Gscr.Cell cell21 = new Gscr.Cell();
            Gscr.Cell cell22 = new Gscr.Cell();
            Gscr.Cell cell23 = new Gscr.Cell();
            Gscr.Cell cell24 = new Gscr.Cell();
            Gscr.Cell cell25 = new Gscr.Cell();
            Gscr.Row row6 = new Gscr.Row();
            Gscr.Cell cell26 = new Gscr.Cell();
            Gscr.Cell cell27 = new Gscr.Cell();
            Gscr.Cell cell28 = new Gscr.Cell();
            Gscr.Cell cell29 = new Gscr.Cell();
            Gscr.Cell cell30 = new Gscr.Cell();
            Gscr.SeriesHeaderStyle seriesHeaderStyle1 = new Gscr.SeriesHeaderStyle();
            this.report1 = new Gscr.Report();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // report1
            // 
            this.report1.AllowOrder = false;
            this.report1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.report1.BackColor = System.Drawing.Color.White;
            this.report1.Barcode.EncodedType = Gscr.BarcodeLib.TYPE.UNSPECIFIED;
            this.report1.Barcode.EncodingTime = 0;
            this.report1.Barcode.Height = 150;
            this.report1.Barcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            this.report1.Barcode.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.report1.Barcode.RawData = "";
            this.report1.Barcode.Width = 300;
            column1.ColumnName = "column1";
            column1.Width = 54;
            column2.ColumnName = "column2";
            column2.Width = 143;
            column3.ColumnName = "column3";
            column3.Width = 82;
            column4.ColumnName = "column4";
            column4.Width = 486;
            column5.ColumnName = "column5";
            this.report1.Columns.AddRange(new Gscr.Column[] {
            column1,
            column2,
            column3,
            column4,
            column5});
            cell1.BorderStyle = Gscr.CellBorderStyle.None;
            cell1.FormulaExpression = "";
            cell2.BorderStyle = Gscr.CellBorderStyle.None;
            cell2.CellDrawMode = Gscr.CellDrawMode.Image;
            cell2.IsMerge = true;
            cell2.MergeEndColumnIndexDiffer = 0;
            cell2.MergeEndRowIndexDiffer = 3;
            cell2.MergeStartColumnIndexDiffer = 0;
            cell2.MergeStartRowIndexDiffer = 0;
            cell3.BorderStyle = Gscr.CellBorderStyle.None;
            cell3.Value = "产品名称：";
            cell4.BorderStyle = Gscr.CellBorderStyle.None;
            cell4.DataField = "ProductName";
            cell4.ForeColor = System.Drawing.Color.Blue;
            cell5.BorderStyle = Gscr.CellBorderStyle.None;
            row1.Cells.AddRange(new Gscr.Cell[] {
            cell1,
            cell2,
            cell3,
            cell4,
            cell5});
            cell6.BorderStyle = Gscr.CellBorderStyle.None;
            cell7.BorderStyle = Gscr.CellBorderStyle.None;
            cell7.IsMerge = true;
            cell7.MergeEndColumnIndexDiffer = 0;
            cell7.MergeEndRowIndexDiffer = 2;
            cell7.MergeStartColumnIndexDiffer = 0;
            cell8.BorderStyle = Gscr.CellBorderStyle.None;
            cell8.Value = "产品制造商：";
            cell9.BorderStyle = Gscr.CellBorderStyle.None;
            cell9.DataField = "Manufacturer";
            cell10.BorderStyle = Gscr.CellBorderStyle.None;
            row2.Cells.AddRange(new Gscr.Cell[] {
            cell6,
            cell7,
            cell8,
            cell9,
            cell10});
            cell11.BorderStyle = Gscr.CellBorderStyle.None;
            cell12.BorderStyle = Gscr.CellBorderStyle.None;
            cell12.IsMerge = true;
            cell12.MergeEndColumnIndexDiffer = 0;
            cell12.MergeEndRowIndexDiffer = 1;
            cell12.MergeStartColumnIndexDiffer = 0;
            cell12.MergeStartRowIndexDiffer = -2;
            cell13.BorderStyle = Gscr.CellBorderStyle.None;
            cell13.Value = "产品简介：";
            cell14.BorderStyle = Gscr.CellBorderStyle.None;
            cell14.DataField = "Note";
            cell15.BorderStyle = Gscr.CellBorderStyle.None;
            row3.Cells.AddRange(new Gscr.Cell[] {
            cell11,
            cell12,
            cell13,
            cell14,
            cell15});
            cell16.BorderStyle = Gscr.CellBorderStyle.None;
            cell17.BorderStyle = Gscr.CellBorderStyle.None;
            cell17.IsMerge = true;
            cell17.MergeEndColumnIndexDiffer = 0;
            cell17.MergeEndRowIndexDiffer = 0;
            cell17.MergeStartColumnIndexDiffer = 0;
            cell17.MergeStartRowIndexDiffer = -3;
            cell18.BorderStyle = Gscr.CellBorderStyle.None;
            cell18.Value = "报价：";
            cell19.BorderStyle = Gscr.CellBorderStyle.None;
            cell19.DataField = "Price";
            cell19.FormatString = "0.00";
            cell20.BorderStyle = Gscr.CellBorderStyle.None;
            cell20.CellDrawMode = Gscr.CellDrawMode.Link;
            cell20.Value = "详细>>";
            row4.Cells.AddRange(new Gscr.Cell[] {
            cell16,
            cell17,
            cell18,
            cell19,
            cell20});
            this.report1.DetailRows.AddRange(new Gscr.Row[] {
            row1,
            row2,
            row3,
            row4});
            this.report1.DifferentRowColor = true;
            this.report1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.report1.GscrID = ((Gscr.GscrID)(resources.GetObject("report1.GscrID")));
            cell21.BorderStyle = Gscr.CellBorderStyle.None;
            cell22.Alignment = System.Drawing.StringAlignment.Center;
            cell22.BorderStyle = Gscr.CellBorderStyle.None;
            cell22.Font = new System.Drawing.Font("仿宋_GB2312", 20F);
            cell22.IsMerge = true;
            cell22.MergeEndColumnIndexDiffer = 3;
            cell22.MergeEndRowIndexDiffer = 0;
            cell22.MergeStartColumnIndexDiffer = 0;
            cell22.MergeStartRowIndexDiffer = 0;
            cell22.Value = "产品报价表";
            cell23.IsMerge = true;
            cell23.MergeEndColumnIndexDiffer = 2;
            cell23.MergeEndRowIndexDiffer = 0;
            cell23.MergeStartRowIndexDiffer = 0;
            cell24.IsMerge = true;
            cell24.MergeEndColumnIndexDiffer = 1;
            cell24.MergeEndRowIndexDiffer = 0;
            cell24.MergeStartColumnIndexDiffer = -2;
            cell24.MergeStartRowIndexDiffer = 0;
            cell25.IsMerge = true;
            cell25.MergeEndColumnIndexDiffer = 0;
            cell25.MergeEndRowIndexDiffer = 0;
            cell25.MergeStartColumnIndexDiffer = -3;
            cell25.MergeStartRowIndexDiffer = 0;
            row5.Cells.AddRange(new Gscr.Cell[] {
            cell21,
            cell22,
            cell23,
            cell24,
            cell25});
            row5.Height = 61;
            cell26.BorderStyle = Gscr.CellBorderStyle.None;
            cell27.BorderStyle = Gscr.CellBorderStyle.None;
            cell28.BorderStyle = Gscr.CellBorderStyle.None;
            cell29.BorderStyle = Gscr.CellBorderStyle.None;
            cell30.BorderStyle = Gscr.CellBorderStyle.None;
            row6.Cells.AddRange(new Gscr.Cell[] {
            cell26,
            cell27,
            cell28,
            cell29,
            cell30});
            this.report1.HeaderRows.AddRange(new Gscr.Row[] {
            row5,
            row6});
            this.report1.Location = new System.Drawing.Point(5, 75);
            this.report1.Name = "report1";
            this.report1.PrintLandscape = true;
            this.report1.PrintMargins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.report1.ReadOnly = false;
            this.report1.SeriesHeaderStyle = seriesHeaderStyle1;
            this.report1.Size = new System.Drawing.Size(948, 571);
            this.report1.TabIndex = 0;
            this.report1.Text = "report1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(360, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 51;
            this.button2.Text = "打印预览";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(449, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 52;
            this.button3.Text = "导出";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(538, 35);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 55;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 56;
            this.button1.Text = "增加行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(29, 35);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 23);
            this.button4.TabIndex = 57;
            this.button4.Text = "绑定数据(Access)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(266, 35);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 58;
            this.button5.Text = "删除行";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // frmExample5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 652);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.report1);
            this.Name = "frmExample5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Example5(多行明细行)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmExample5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gscr.Report report1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}