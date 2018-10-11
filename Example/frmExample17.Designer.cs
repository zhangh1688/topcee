namespace Example
{
    partial class frmExample17
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExample17));
            Gscr.Row row2 = new Gscr.Row();
            Gscr.Cell cell5 = new Gscr.Cell();
            Gscr.Cell cell6 = new Gscr.Cell();
            Gscr.Cell cell7 = new Gscr.Cell();
            Gscr.Cell cell8 = new Gscr.Cell();
            Gscr.SeriesHeaderStyle seriesHeaderStyle1 = new Gscr.SeriesHeaderStyle();
            this.report1 = new Gscr.Report();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            column1.CellValueType = Gscr.ColumnValueType.Number;
            column1.ColumnName = "本期收入";
            column1.Width = 150;
            column2.CellValueType = Gscr.ColumnValueType.Number;
            column2.ColumnName = "本期支出";
            column2.Width = 150;
            column3.CellValueType = Gscr.ColumnValueType.Number;
            column3.ColumnName = "收支差";
            column3.Width = 150;
            column4.CellValueType = Gscr.ColumnValueType.Number;
            column4.ColumnName = "本期余额";
            column4.Width = 150;
            this.report1.Columns.AddRange(new Gscr.Column[] {
            column1,
            column2,
            column3,
            column4});
            cell1.Alignment = System.Drawing.StringAlignment.Far;
            cell1.DataField = "SR";
            cell1.FormatString = "0.00";
            cell2.Alignment = System.Drawing.StringAlignment.Far;
            cell2.DataField = "ZC";
            cell2.FormatString = "0.00";
            cell3.Alignment = System.Drawing.StringAlignment.Far;
            cell3.FormatString = "0.00";
            cell3.FormulaExpression = "=[本期收入] - [本期支出]";
            cell4.Alignment = System.Drawing.StringAlignment.Far;
            cell4.ForeColor = System.Drawing.Color.Blue;
            cell4.FormatString = "0.00";
            cell4.FormulaExpression = "=[本期收入] - [本期支出] + GetDetailUpRowValue([本期余额])";
            row1.Cells.AddRange(new Gscr.Cell[] {
            cell1,
            cell2,
            cell3,
            cell4});
            this.report1.DetailRows.AddRange(new Gscr.Row[] {
            row1});
            this.report1.Font = new System.Drawing.Font("宋体", 9F);
            this.report1.GscrID = ((Gscr.GscrID)(resources.GetObject("report1.GscrID")));
            cell5.Alignment = System.Drawing.StringAlignment.Center;
            cell5.Value = "本期收入";
            cell6.Alignment = System.Drawing.StringAlignment.Center;
            cell6.Value = "本期支出";
            cell7.Alignment = System.Drawing.StringAlignment.Center;
            cell7.Value = "收支差";
            cell8.Alignment = System.Drawing.StringAlignment.Center;
            cell8.Value = "本期余额";
            row2.Cells.AddRange(new Gscr.Cell[] {
            cell5,
            cell6,
            cell7,
            cell8});
            this.report1.HeaderRows.AddRange(new Gscr.Row[] {
            row2});
            this.report1.Location = new System.Drawing.Point(5, 75);
            this.report1.Name = "report1";
            this.report1.PrintCellBackColor = true;
            this.report1.PrintMargins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.report1.SelectSQL = "SELECT \n\tAccount.SR,\n\tAccount.ZC\nFROM\n\tAccount ";
            this.report1.SeriesHeaderStyle = seriesHeaderStyle1;
            this.report1.Size = new System.Drawing.Size(948, 571);
            this.report1.TabIndex = 0;
            this.report1.Text = "report1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(173, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 51;
            this.button2.Text = "打印预览";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(266, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 52;
            this.button3.Text = "导出";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(359, 35);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 55;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 56;
            this.button1.Text = "绑定数据(Access)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmExample17
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 652);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.report1);
            this.Name = "frmExample17";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "示例17(余额计算)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmExample17_Load);
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gscr.Report report1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
    }
}