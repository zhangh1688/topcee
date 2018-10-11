namespace Example
{
    partial class frmExample20
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
            Gscr.Row row1 = new Gscr.Row();
            Gscr.Cell cell1 = new Gscr.Cell();
            Gscr.Cell cell2 = new Gscr.Cell();
            Gscr.Cell cell3 = new Gscr.Cell();
            Gscr.Row row2 = new Gscr.Row();
            Gscr.Cell cell4 = new Gscr.Cell();
            Gscr.Cell cell5 = new Gscr.Cell();
            Gscr.Cell cell6 = new Gscr.Cell();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExample20));
            Gscr.Row row3 = new Gscr.Row();
            Gscr.Cell cell7 = new Gscr.Cell();
            Gscr.Cell cell8 = new Gscr.Cell();
            Gscr.Cell cell9 = new Gscr.Cell();
            Gscr.SeriesHeaderStyle seriesHeaderStyle1 = new Gscr.SeriesHeaderStyle();
            Gscr.Row row4 = new Gscr.Row();
            Gscr.Cell cell10 = new Gscr.Cell();
            Gscr.Cell cell11 = new Gscr.Cell();
            Gscr.Cell cell12 = new Gscr.Cell();
            Gscr.Row row5 = new Gscr.Row();
            Gscr.Cell cell13 = new Gscr.Cell();
            Gscr.Cell cell14 = new Gscr.Cell();
            Gscr.Cell cell15 = new Gscr.Cell();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.report1 = new Gscr.Report();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 50;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(130, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 51;
            this.button2.Text = "打印预览";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(223, 31);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 52;
            this.button3.Text = "导出";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(316, 31);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 53;
            this.button4.Text = "ReSet";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(409, 31);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 55;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // report1
            // 
            this.report1.AccountPrefix = "";
            this.report1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.report1.BackColor = System.Drawing.Color.White;
            this.report1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.report1.Barcode.EncodedType = Gscr.BarcodeLib.TYPE.UNSPECIFIED;
            this.report1.Barcode.EncodingTime = 0;
            this.report1.Barcode.Height = 150;
            this.report1.Barcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            this.report1.Barcode.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.report1.Barcode.RawData = "";
            this.report1.Barcode.Width = 300;
            column1.ColumnName = "column4";
            column1.Width = 150;
            column2.CellValueType = Gscr.ColumnValueType.Number;
            column2.ColumnName = "column10";
            column2.Width = 150;
            column3.ColumnName = "column1";
            column3.Width = 600;
            this.report1.Columns.AddRange(new Gscr.Column[] {
            column1,
            column2,
            column3});
            cell1.Alignment = System.Drawing.StringAlignment.Center;
            cell1.DataField = "部门";
            cell1.DataSourceName = "";
            cell2.Alignment = System.Drawing.StringAlignment.Center;
            cell2.DataField = "工作完成量";
            cell3.BorderStyle = Gscr.CellBorderStyle.Left;
            row1.Cells.AddRange(new Gscr.Cell[] {
            cell1,
            cell2,
            cell3});
            row1.Height = 40;
            this.report1.DetailRows.AddRange(new Gscr.Row[] {
            row1});
            this.report1.FixedHeaderRows = false;
            this.report1.Font = new System.Drawing.Font("宋体", 9F);
            cell4.Alignment = System.Drawing.StringAlignment.Center;
            cell4.Value = "工作量合计";
            cell5.Alignment = System.Drawing.StringAlignment.Center;
            cell5.FormulaExpression = "=Sum([B])";
            cell5.Value = 0;
            cell6.BorderStyle = Gscr.CellBorderStyle.Left;
            row2.Cells.AddRange(new Gscr.Cell[] {
            cell4,
            cell5,
            cell6});
            row2.Height = 40;
            this.report1.FooterRows.AddRange(new Gscr.Row[] {
            row2});
            this.report1.GscrID = ((Gscr.GscrID)(resources.GetObject("report1.GscrID")));
            cell7.Alignment = System.Drawing.StringAlignment.Center;
            cell7.Value = "部门";
            cell8.Alignment = System.Drawing.StringAlignment.Center;
            cell8.Value = "工作完成量";
            cell9.BorderStyle = Gscr.CellBorderStyle.Left;
            row3.Cells.AddRange(new Gscr.Cell[] {
            cell7,
            cell8,
            cell9});
            row3.Height = 40;
            this.report1.HeaderRows.AddRange(new Gscr.Row[] {
            row3});
            this.report1.Location = new System.Drawing.Point(12, 80);
            this.report1.Name = "report1";
            this.report1.PrintLandscape = true;
            this.report1.PrintMargins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.report1.SelectSQL = "";
            this.report1.SeriesHeaderStyle = seriesHeaderStyle1;
            this.report1.Size = new System.Drawing.Size(933, 560);
            this.report1.TabIndex = 57;
            this.report1.Text = "report1";
            cell10.Alignment = System.Drawing.StringAlignment.Center;
            cell10.BorderStyle = Gscr.CellBorderStyle.None;
            cell10.Font = new System.Drawing.Font("宋体", 20F);
            cell10.IsMerge = true;
            cell10.MergeEndColumnIndexDiffer = 2;
            cell10.MergeEndRowIndexDiffer = 0;
            cell10.MergeStartColumnIndexDiffer = 0;
            cell10.MergeStartRowIndexDiffer = 0;
            cell10.Value = "MSChart嵌入图表示例";
            cell11.BorderStyle = Gscr.CellBorderStyle.None;
            cell11.IsMerge = true;
            cell11.MergeEndColumnIndexDiffer = 1;
            cell11.MergeEndRowIndexDiffer = 0;
            cell11.MergeStartRowIndexDiffer = 0;
            cell12.BorderStyle = Gscr.CellBorderStyle.None;
            cell12.IsMerge = true;
            cell12.MergeEndColumnIndexDiffer = 0;
            cell12.MergeEndRowIndexDiffer = 0;
            cell12.MergeStartColumnIndexDiffer = -2;
            cell12.MergeStartRowIndexDiffer = 0;
            row4.Cells.AddRange(new Gscr.Cell[] {
            cell10,
            cell11,
            cell12});
            row4.Height = 60;
            cell13.BorderStyle = Gscr.CellBorderStyle.Bottom;
            cell14.BorderStyle = Gscr.CellBorderStyle.Bottom;
            cell15.Alignment = System.Drawing.StringAlignment.Center;
            cell15.BorderStyle = Gscr.CellBorderStyle.None;
            cell15.CellDrawMode = Gscr.CellDrawMode.Link;
            cell15.Value = "MSChart下载地址";
            row5.Cells.AddRange(new Gscr.Cell[] {
            cell13,
            cell14,
            cell15});
            row5.Height = 30;
            this.report1.TitleRows.AddRange(new Gscr.Row[] {
            row4,
            row5});
            this.report1.CellClick += new System.EventHandler<Gscr.CellEventArgs>(this.report1_CellClick);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(435, 240);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(400, 300);
            this.chart1.TabIndex = 58;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // frmExample20
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 652);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.report1);
            this.Name = "frmExample20";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Example20(显示MsChart图表)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmExample20_Load);
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnClose;
        private Gscr.Report report1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}