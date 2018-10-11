using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Gscr;

namespace Example
{
    public partial class frmReportDesigner : Form
    {

        public frmReportDesigner()
        {
            InitializeComponent();

            //加载字体
            foreach (FontFamily fam in FontFamily.Families)
            {
                fontToolStripComboBox.Items.Add(fam.Name);
                fam.Dispose();
            }
            propertyGridReport.SelectedObject = report1;
        }


        #region 方法


        /// <summary>
        /// 显示属性
        /// </summary>
        private void ShowProperty()
        {
            //单元格属性
            object[] objCells = new object[report1.SelectedCells.Count];
            int i = 0;
            foreach (Cell cell in report1.SelectedCells)
            {
                objCells[i] = cell;
                i++;
            }
            propertyGridCell.SelectedObjects = objCells;

            //列属性
            int minColumIndex = -1;
            int maxColumIndex = -1;
            i = 0;
            foreach (Cell cell in report1.SelectedCells)
            {
                if (i == 0)
                {
                    minColumIndex = maxColumIndex = cell.ColumnIndex;
                }
                else
                {
                    minColumIndex = Math.Min(cell.ColumnIndex, minColumIndex);
                    maxColumIndex = Math.Max(cell.ColumnIndex, maxColumIndex);
                }
                i++;
            }
            if (minColumIndex == -1 || maxColumIndex == -1)
            {
                propertyGridColumn.SelectedObjects = null;
            }
            else
            {
                object[] objCulumns = new object[maxColumIndex - minColumIndex + 1];
                i = 0;
                for (int j = minColumIndex; j <= maxColumIndex; j++)
                {
                    objCulumns[i] = report1.Columns[j];
                    i++;
                }
                propertyGridColumn.SelectedObjects = objCulumns;
            }

        }

        /// <summary>
        /// 重新设置工具栏
        /// </summary>
        private void ReSetToolStripMenuItemChecked()
        {
            //值
            bool isSameValue = true;
            //字体，是否相同
            bool isSameFontName = true;
            bool isSameFontSize = true;
            bool isSameFontBold = true;
            bool isSameFontItalic = true;
            bool isSameFontUnderline = true;
            //对齐位置，是否相同
            bool isSameAlign = true;
            bool isLineAlignment = true;

            if (report1.CurrentCell != null)
            {
                //值
                object value = report1.CurrentCell.Value;
                //字体
                string fontName = report1.CurrentCell.PaintFont.FontFamily.Name;
                float fontSize = report1.CurrentCell.PaintFont.Size;
                bool fontBold = report1.CurrentCell.PaintFont.Bold;
                bool fontItalic = report1.CurrentCell.PaintFont.Italic;
                bool fontUnderline = report1.CurrentCell.PaintFont.Underline;
                //对齐位置
                StringAlignment align = report1.CurrentCell.Alignment;
                StringAlignment aineAlignment = report1.CurrentCell.LineAlignment;

                foreach (Cell c in report1.SelectedCells)
                {
                    //值
                    if (!isSameValue || value != c.Value)
                        isSameValue = false;

                    //字体
                    if (!isSameFontName || fontName != c.PaintFont.FontFamily.Name)
                        isSameFontName = false;
                    if (!isSameFontSize || fontSize != c.PaintFont.Size)
                        isSameFontSize = false;
                    if (!isSameFontBold || fontBold != c.PaintFont.Bold)
                        isSameFontBold = false;
                    if (!isSameFontItalic || fontItalic != c.PaintFont.Italic)
                        isSameFontItalic = false;
                    if (!isSameFontUnderline || fontUnderline != c.PaintFont.Underline)
                        isSameFontUnderline = false;

                    //对齐位置
                    if (!isSameAlign || (align != c.Alignment))
                        isSameAlign = false;

                    if (!isLineAlignment || (aineAlignment != c.LineAlignment))
                        isLineAlignment = false;


                }
                //值
                valueToolStripTextBox.Text = (isSameValue) ? ((value == null) ? "" : value.ToString()) : "";

                //字体
                fontToolStripComboBox.Text = (isSameFontName) ? fontName : "";
                fontSizeToolStripComboBox.Text = (isSameFontSize) ? fontSize.ToString() : "";
                boldToolStripButton.Checked = (isSameFontBold) ? fontBold : false;
                italicToolStripButton.Checked = (isSameFontItalic) ? fontItalic : false;
                underLineToolStripButton.Checked = (isSameFontUnderline) ? fontUnderline : false;

                //对齐位置
                alignLeftToolStripButton.Checked = (isSameAlign && align == StringAlignment.Near) ? true : false;
                alignCenterToolStripButton.Checked = (isSameAlign && align == StringAlignment.Center) ? true : false;
                alignRightToolStripButton.Checked = (isSameAlign && align == StringAlignment.Far) ? true : false;

                lineAlignmentTopToolStripButton.Checked = (isLineAlignment && aineAlignment == StringAlignment.Near) ? true : false;
                lineAlignmentCenterToolStripButton.Checked = (isLineAlignment && aineAlignment == StringAlignment.Center) ? true : false;
                lineAlignmentBottomToolStripButton.Checked = (isLineAlignment && aineAlignment == StringAlignment.Far) ? true : false;
            }
        }

        #endregion

        #region propertyReport控件事件

        private void propertyReportReport_SelectedReportItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            report1.ReDraw();
        }

        private void propertyReportColumn_SelectedReportItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            report1.ReDraw();
        }

        private void propertyReportCell_SelectedReportItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            report1.ReDraw();
        }

        #endregion

        #region reportDesign控件事件

        private void report1_MouseMove(object sender, MouseEventArgs e)
        {

            //状态栏提示
            string tipInfo = " X=" + e.X.ToString() + "，Y=" + e.Y.ToString();

            Cell cell = report1.CurrentCell;
            if (cell != null)
            {
                tipInfo += "，CurrentCell={" + cell.RowIndex.ToString() + "," + cell.ColumnIndex.ToString() + "}" + "，Band=" + report1.Rows[cell.RowIndex].Band.ToString();
            }
            else
            {
                tipInfo += "，CurrentCell=null";
            }

            this.statusStrip1.Items[0].Text = tipInfo;
        }

        private void report1_MouseUp(object sender, MouseEventArgs e)
        {
            this.ShowProperty();
            //当选择单元格时，相应的工具栏修改
            this.ReSetToolStripMenuItemChecked();
        }

        private void report1_KeyUp(object sender, KeyEventArgs e)
        {
            this.ShowProperty();
            //当选择单元格时，相应的工具栏修改
            this.ReSetToolStripMenuItemChecked();
        }


        #endregion

        #region 菜单(文件)

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确定新建报表？",
                "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                report1.ClearReport();

                report1.AllowOrder = false;
                report1.DetailRowCreateType = DetailRowCreateType.BlankRow;
                report1.IsLoadDetailRowsInitialize = true;
                report1.ReadOnly = false;
                report1.ShowBand = true;
                report1.ShowRuler = true;

                report1.AddColumn(6);

                report1.AddRow(Band.Header);
                report1.AddRow(Band.Detail);

                propertyGridReport.Refresh();
                propertyGridColumn.Refresh();
                propertyGridCell.Refresh();
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确定新建报表？",
                "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                report1.ClearReport();

                report1.AllowOrder = false;
                report1.DetailRowCreateType = DetailRowCreateType.BlankRow;
                report1.IsLoadDetailRowsInitialize = true;
                report1.ReadOnly = false;
                report1.ShowBand = true;
                report1.ShowRuler = true;

                report1.AddColumn(6);

                report1.AddRow(Band.Header);
                report1.AddRow(Band.Detail);

                propertyGridReport.Refresh();
                propertyGridColumn.Refresh();
                propertyGridCell.Refresh();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report1.ShowOpenGSCFileDlg();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            report1.ShowOpenGSCFileDlg();
        }

        string _openGscFileName = String.Empty;
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(_openGscFileName))
                {
                    //打开
                    SaveFileDialog saveFileDlg = new SaveFileDialog();

                    saveFileDlg.Filter = "Report Files(*.gsc)|*.gsc";
                    if (saveFileDlg.ShowDialog() != DialogResult.OK)
                    {
                        goto Label1;
                    }

                    string fileName = saveFileDlg.FileName;
                    if (String.IsNullOrEmpty(fileName))
                    {
                        goto Label1;
                    }

                    report1.SaveAs(ExportType.GSC, fileName);

                    _openGscFileName = saveFileDlg.FileName;

                Label1:
                    saveFileDlg.Dispose();
                }
                else
                {
                    report1.SaveAs(ExportType.GSC, _openGscFileName);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report1.ShowSaveasGSCFileDlg();
        }

        private void saveasToolStripButton_Click(object sender, EventArgs e)
        {
            report1.ShowSaveasGSCFileDlg();
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gscr.Designer.frmPageSetupDlg frmPageSetupDlg = new Gscr.Designer.frmPageSetupDlg(report1);
            if (frmPageSetupDlg.ShowDialog() == DialogResult.OK)
            {
                propertyGridReport.Refresh();
            }
        }


        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report1.PrintPreview();
        }

        private void previewToolStripButton_Click(object sender, EventArgs e)
        {
            report1.PrintPreview();
        }

        private void existXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 菜单(编辑)

        /// <summary>
        /// 清除全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Cell cell in report1.SelectedCells)
            {
                //内容
                cell.Value = null;
                cell.FormatString = null;
                cell.Tag = null;
                cell.ToolTipText = null;
                cell.FormulaExpression = null;

                //格式
                cell.ReadOnly = true;
                cell.IsPrint = true;
                cell.EditType = null;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;
                cell.Font = null;
                cell.Alignment = StringAlignment.Near;
                cell.LineAlignment = StringAlignment.Center;
                cell.BorderStyle = CellBorderStyle.All;
                cell.BorderColor = System.Drawing.Color.DarkGray;
                cell.BorderWidth = 1;
                cell.CellDrawMode = CellDrawMode.Normal;
                cell.BarcodeEncoding = Gscr.BarcodeLib.TYPE.CODE39;
                cell.TextFormat = Gscr.TextFormat.MultilineEllipsis;
            }
            propertyGridCell.Refresh();
            this.ReSetToolStripMenuItemChecked();
        }

        /// <summary>
        /// 清除格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearFormateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Cell cell in report1.SelectedCells)
            {
                //格式
                cell.ReadOnly = true;
                cell.IsPrint = true;
                cell.EditType = null;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;
                cell.Font = null;
                cell.Alignment = StringAlignment.Near;
                cell.LineAlignment = StringAlignment.Center;
                cell.BorderStyle = CellBorderStyle.All;
                cell.BorderColor = System.Drawing.Color.DarkGray;
                cell.BorderWidth = 1;
                cell.CellDrawMode = CellDrawMode.Normal;
                cell.BarcodeEncoding = Gscr.BarcodeLib.TYPE.CODE39;
                cell.TextFormat = Gscr.TextFormat.MultilineEllipsis;
            }
            propertyGridCell.Refresh();
            this.ReSetToolStripMenuItemChecked();
        }

        /// <summary>
        /// 清除内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Cell cell in report1.SelectedCells)
            {
                //内容
                cell.Value = null;
                cell.FormatString = null;
                cell.Tag = null;
                cell.ToolTipText = null;
                cell.FormulaExpression = null;
            }
            propertyGridCell.Refresh();
            this.ReSetToolStripMenuItemChecked();
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除所有行列？",
                "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                report1.ClearReport();

                propertyGridReport.Refresh();
                propertyGridColumn.Refresh();
                propertyGridCell.Refresh();
            }
        }

        private void rowHeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (report1.CurrentCell == null)
                return;

            try
            {
                int rowIndex = report1.CurrentCell.RowIndex;
                int rowHeight = report1.Rows[rowIndex].Height;

                Gscr.Designer.frmRowHeightDlg frmRowHeight = new Gscr.Designer.frmRowHeightDlg();
                frmRowHeight.RowHeight = rowHeight;
                if (frmRowHeight.ShowDialog() == DialogResult.OK)
                {
                    foreach (Cell cell in report1.SelectedCells)
                    {
                        report1.Rows[cell.RowIndex].Height = frmRowHeight.RowHeight;
                    }
                }
            }
            catch
            {
                MessageBox.Show("请选择行。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void columnWidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (report1.CurrentCell == null)
                return;

            try
            {
                int columnIndex = report1.CurrentCell.ColumnIndex;
                int columnWidth = report1.Columns[columnIndex].Width;

                Gscr.Designer.frmColumnWidthDlg frmColumnWidth = new Gscr.Designer.frmColumnWidthDlg();
                frmColumnWidth.ColumnWidth = columnWidth;
                if (frmColumnWidth.ShowDialog() == DialogResult.OK)
                {
                    foreach (Cell cell in report1.SelectedCells)
                    {
                        report1.Columns[cell.ColumnIndex].Width = frmColumnWidth.ColumnWidth;
                    }
                }

                propertyGridColumn.Refresh();
            }
            catch
            {
                MessageBox.Show("请选择列。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void adjustColumnIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (report1.ColumnCount > 0)
            {
                Gscr.Designer.frmAdjustColumnIndexDlg frmAdjustColumnIndex = new Gscr.Designer.frmAdjustColumnIndexDlg(report1.ColumnCount);
                if (frmAdjustColumnIndex.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        report1.AdjustColumnIndex(frmAdjustColumnIndex.OldColumnIndex, frmAdjustColumnIndex.NewColumnIndex);

                        propertyGridReport.Refresh();
                        propertyGridColumn.Refresh();
                        propertyGridCell.Refresh();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message,
                            "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        private void pageHeaderFootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gscr.Designer.frmPageHeaderFooterDlg frmDlg = new Gscr.Designer.frmPageHeaderFooterDlg();
            frmDlg.ContextReport = report1;
            if (frmDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //页眉
                    if (!String.IsNullOrEmpty(frmDlg.TopLeftText))
                    {
                        report1.PrintAdditionalText.Add
                            (new Gscr.Print.AdditionalText(frmDlg.TopLeftText, Gscr.Print.TextPosition.HTopLeft));
                    }
                    if (!String.IsNullOrEmpty(frmDlg.TopCenterText))
                    {
                        report1.PrintAdditionalText.Add
                            (new Gscr.Print.AdditionalText(frmDlg.TopCenterText, Gscr.Print.TextPosition.HTopCenter));
                    }
                    if (!String.IsNullOrEmpty(frmDlg.TopRightText))
                    {
                        report1.PrintAdditionalText.Add(
                            new Gscr.Print.AdditionalText(frmDlg.TopRightText, Gscr.Print.TextPosition.HTopRight));
                    }

                    //页脚
                    if (!String.IsNullOrEmpty(frmDlg.BottomLeftText))
                    {
                        report1.PrintAdditionalText.Add(
                            new Gscr.Print.AdditionalText(frmDlg.BottomLeftText, Gscr.Print.TextPosition.HBottomLeft));
                    }
                    if (!String.IsNullOrEmpty(frmDlg.BottomCenterText))
                    {
                        report1.PrintAdditionalText.Add(
                            new Gscr.Print.AdditionalText(frmDlg.BottomCenterText, Gscr.Print.TextPosition.HBottomCenter));
                    }
                    if (!String.IsNullOrEmpty(frmDlg.BottomRightText))
                    {
                        report1.PrintAdditionalText.Add(
                            new Gscr.Print.AdditionalText(frmDlg.BottomRightText, Gscr.Print.TextPosition.HBottomRight));
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message,
                        "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Gscr.Designer.frmGroupInfo frmGroup = new Gscr.Designer.frmGroupInfo();
                frmGroup.ContextReport = report1;
                if (frmGroup.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void visibleColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Gscr.Designer.frmVisibleColumn frmVisibleColumn = new Gscr.Designer.frmVisibleColumn();
                frmVisibleColumn.ContextReport = report1;
                if (frmVisibleColumn.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dbConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (Gscr.Designer.frmDataSourceConfig dlg = new Gscr.Designer.frmDataSourceConfig())
                {
                    dlg.ContextReport = report1;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        if (dlg.checkBox1.Checked)
                        {
                            propertyGridReport.Refresh();
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void cellPhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (report1.CurrentCell == null)
            {
                MessageBox.Show("请选择单元格。",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Gscr.Designer.frmCellPhotoDlg frmCellPhotoDlg = new Gscr.Designer.frmCellPhotoDlg();
                frmCellPhotoDlg.Cell = report1.CurrentCell;
                frmCellPhotoDlg.ShowDialog();

                propertyGridCell.Refresh();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gscr.Designer.frmReportAbout frmAbout = new Gscr.Designer.frmReportAbout();
            frmAbout.ShowDialog();
        }

        #endregion

        #region 工具栏菜单(单元格)

        //值
        private void valueToolStripTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double doubleValue;
                foreach (Cell cell in report1.SelectedCells)
                {
                    if (String.IsNullOrEmpty(valueToolStripTextBox.Text))
                    {
                        cell.Value = null;
                    }
                    else
                    {
                        doubleValue = 0;
                        if (Double.TryParse(valueToolStripTextBox.Text, out doubleValue))
                        {
                            //优先是数值类型
                            cell.Value = doubleValue;
                        }
                        else
                        {
                            cell.Value = valueToolStripTextBox.Text;
                        }
                    }
                }
                propertyGridCell.Refresh();
            }
        }

        private void valueToolStripTextBox_Leave(object sender, EventArgs e)
        {
            double doubleValue;
            foreach (Cell cell in report1.SelectedCells)
            {
                if (String.IsNullOrEmpty(valueToolStripTextBox.Text))
                {
                    cell.Value = null;
                }
                else
                {
                    doubleValue = 0;
                    if (Double.TryParse(valueToolStripTextBox.Text, out doubleValue))
                    {
                        //优先是数值类型
                        cell.Value = doubleValue;
                    }
                    else
                    {
                        cell.Value = valueToolStripTextBox.Text;
                    }
                }
            }
            propertyGridCell.Refresh();
        }

        //字体
        private string fontComboBoxTxt = "";
        private string fontSizeComboBoxTxt = "";

        private void fontToolStripComboBox_GotFocus(object sender, EventArgs e)
        {
            fontComboBoxTxt = fontToolStripComboBox.Text;
        }

        private void fontToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FontFamily ff = new FontFamily(fontToolStripComboBox.Text);
                fontComboBoxTxt = ff.Name;

                FontStyle style;
                Font font;
                foreach (Cell cell in report1.SelectedCells)
                {
                    style = cell.PaintFont.Style;
                    font = new Font(ff, cell.PaintFont.Size, style);
                    cell.Font = (Font)font.Clone();
                    font.Dispose();
                }
                propertyGridCell.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void fontToolStripComboBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(fontToolStripComboBox.Text))
                {
                    FontFamily ff = new FontFamily(fontToolStripComboBox.Text);
                }
            }
            catch (Exception)
            {
                fontToolStripComboBox.Text = fontComboBoxTxt;
                return;
            }
        }



        private void fontSizeToolStripComboBox_GotFocus(object sender, EventArgs e)
        {
            fontSizeComboBoxTxt = fontSizeToolStripComboBox.Text;
        }

        private void fontSizeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                float size;
                if (float.TryParse(fontSizeToolStripComboBox.Text, out size))
                {
                    fontSizeComboBoxTxt = size.ToString();

                    FontStyle style;
                    Font font;
                    foreach (Cell cell in report1.SelectedCells)
                    {
                        style = cell.PaintFont.Style;
                        font = new Font(cell.PaintFont.FontFamily, size, style);

                        cell.Font = (Font)font.Clone();
                        font.Dispose();
                    }
                    propertyGridCell.Refresh();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void fontSizeToolStripComboBox_Leave(object sender, EventArgs e)
        {
            float size;
            if (!float.TryParse(fontSizeToolStripComboBox.Text, out size))
            {
                fontSizeToolStripComboBox.Text = fontSizeComboBoxTxt;
                return;
            }
            propertyGridCell.Refresh();
        }



        private void boldToolStripButton_Click(object sender, EventArgs e)
        {
            FontStyle style;
            Font font;
            foreach (Cell cell in report1.SelectedCells)
            {
                style = cell.PaintFont.Style;
                if (cell.PaintFont.Bold)
                {
                    style = style ^ FontStyle.Bold;
                }
                else
                {
                    style = style | FontStyle.Bold;
                }

                font = new Font(cell.PaintFont, style);
                cell.Font = (Font)font.Clone();
                font.Dispose();
            }
            propertyGridCell.Refresh();
            this.ReSetToolStripMenuItemChecked();
        }

        private void italicToolStripButton_Click(object sender, EventArgs e)
        {
            FontStyle style;
            Font font;
            foreach (Cell cell in report1.SelectedCells)
            {
                style = cell.PaintFont.Style;
                if (cell.PaintFont.Italic)
                {
                    style = style ^ FontStyle.Italic;
                }
                else
                {
                    style = style | FontStyle.Italic;
                }

                font = new Font(cell.PaintFont, style);
                cell.Font = (Font)font.Clone();
                font.Dispose();
            }
            propertyGridCell.Refresh();
            this.ReSetToolStripMenuItemChecked();
        }

        private void underLineToolStripButton_Click(object sender, EventArgs e)
        {
            FontStyle style;
            Font font;
            foreach (Cell cell in report1.SelectedCells)
            {
                style = cell.PaintFont.Style;
                if (cell.PaintFont.Underline)
                {
                    style = style ^ FontStyle.Underline;
                }
                else
                {
                    style = style | FontStyle.Underline;
                }

                font = new Font(cell.PaintFont, style);
                cell.Font = (Font)font.Clone();
                font.Dispose();
            }
            propertyGridCell.Refresh();
            this.ReSetToolStripMenuItemChecked();
        }

        //对齐
        private void alignLeftToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (Cell cell in report1.SelectedCells)
            {
                cell.Alignment = StringAlignment.Near;
            }
            propertyGridCell.Refresh();
            this.ReSetToolStripMenuItemChecked();
        }

        private void alignCenterToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (Cell cell in report1.SelectedCells)
            {
                cell.Alignment = StringAlignment.Center;
            }
            propertyGridCell.Refresh();
            this.ReSetToolStripMenuItemChecked();
        }

        private void alignRightToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (Cell cell in report1.SelectedCells)
            {
                cell.Alignment = StringAlignment.Far;
            }
            propertyGridCell.Refresh();
            this.ReSetToolStripMenuItemChecked();
        }

        private void lineAlignmentTopToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (Cell cell in report1.SelectedCells)
            {
                cell.LineAlignment = StringAlignment.Near;
            }
            propertyGridCell.Refresh();
            this.ReSetToolStripMenuItemChecked();
        }

        private void lineAlignmentCenterToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (Cell cell in report1.SelectedCells)
            {
                cell.LineAlignment = StringAlignment.Center;
            }
            propertyGridCell.Refresh();
            this.ReSetToolStripMenuItemChecked();
        }

        private void lineAlignmentBottomToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (Cell cell in report1.SelectedCells)
            {
                cell.LineAlignment = StringAlignment.Far;
            }
            propertyGridCell.Refresh();
            this.ReSetToolStripMenuItemChecked();
        }

        //边框
        private void borderNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Collection<Range> list = report1.GetSeletionRectangleList();
            foreach (Range r in list)
            {
                report1.SetCellBorderStyle(r, CellBorderStyle.None);
            }
            propertyGridCell.Refresh();
        }

        private void borderLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Collection<Range> list = report1.GetSeletionRectangleList();
            foreach (Range r in list)
            {
                report1.SetCellBorderStyle(r, CellBorderStyle.Left);
            }
            propertyGridCell.Refresh();
        }

        private void borderRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Collection<Range> list = report1.GetSeletionRectangleList();
            foreach (Range r in list)
            {
                report1.SetCellBorderStyle(r, CellBorderStyle.Right);
            }
            propertyGridCell.Refresh();
        }

        private void borderTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Collection<Range> list = report1.GetSeletionRectangleList();
            foreach (Range r in list)
            {
                report1.SetCellBorderStyle(r, CellBorderStyle.Top);
            }
            propertyGridCell.Refresh();
        }

        private void borderBottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Collection<Range> list = report1.GetSeletionRectangleList();
            foreach (Range r in list)
            {
                report1.SetCellBorderStyle(r, CellBorderStyle.Bottom);
            }
            propertyGridCell.Refresh();
        }

        private void borderOuterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetBorderOuter();
        }

        private void SetBorderOuter()
        {
            Collection<Range> list = report1.GetSeletionRectangleList();
            Cell cell;
            foreach (Range r in list)
            {
                if (r.Equals(Range.Empty))
                    continue;

                Gscr.CellBorderStyle style = CellBorderStyle.None;
                for (int i = r.StartPosition.RowIndex; i <= r.EndPosition.RowIndex; i++)
                {
                    for (int j = r.StartPosition.ColumnIndex; j <= r.EndPosition.ColumnIndex; j++)
                    {
                        cell = this.report1.GetCell(i, j);
                        if (cell == null)
                            continue;

                        style = CellBorderStyle.None;

                        if (r.StartPosition.RowIndex == cell.RowIndex || (cell.IsMerge && cell.MergeStartRowIndex == r.StartPosition.RowIndex))
                        {
                            style = style | Gscr.CellBorderStyle.Top;
                        }

                        if (r.EndPosition.RowIndex == cell.RowIndex || (cell.IsMerge && cell.MergeEndRowIndex == r.EndPosition.RowIndex))
                        {
                            style = style | CellBorderStyle.Bottom;
                        }

                        if (r.StartPosition.ColumnIndex == cell.ColumnIndex || (cell.IsMerge && cell.MergeStartColumnIndex == r.StartPosition.ColumnIndex))
                        {
                            style = style | CellBorderStyle.Left;
                        }

                        if (r.EndPosition.ColumnIndex == cell.ColumnIndex || (cell.IsMerge && cell.MergeEndColumnIndex == r.EndPosition.ColumnIndex))
                        {
                            style = style | CellBorderStyle.Right;
                        }

                        cell.BorderStyle = style;
                    }
                }
            }
            propertyGridCell.Refresh();
        }

        private void borderAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Collection<Range> list = report1.GetSeletionRectangleList();
            foreach (Range r in list)
            {
                report1.SetCellBorderStyle(r, CellBorderStyle.All);
            }
            propertyGridCell.Refresh();
        }

        private void borderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (report1.SelectedCells.Count == 0)
            {
                MessageBox.Show("请选择单元格。",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Gscr.Designer.frmCellBorderDlg frmCellBorderDlg = new Gscr.Designer.frmCellBorderDlg();
            if (report1.SelectedCells.Count == 1)
            {
                frmCellBorderDlg.Border = report1.SelectedCells[0].BorderStyle;
            }

            if (frmCellBorderDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (frmCellBorderDlg.IsOuterBorder)
                    {
                        this.SetBorderOuter();
                        //============================
                        //是否选择了斜线
                        //============================
                        Collection<Range> list = report1.GetSeletionRectangleList();
                        Cell cell;
                        foreach (Range r in list)
                        {
                            if (r.Equals(Range.Empty))
                                continue;

                            Gscr.CellBorderStyle cellStyle = CellBorderStyle.None;
                            for (int i = r.StartPosition.RowIndex; i <= r.EndPosition.RowIndex; i++)
                            {
                                for (int j = r.StartPosition.ColumnIndex; j <= r.EndPosition.ColumnIndex; j++)
                                {
                                    cell = this.report1.GetCell(i, j);
                                    if (cell == null)
                                        continue;

                                    cellStyle = cell.BorderStyle;

                                    //单斜
                                    if ((frmCellBorderDlg.Border & Gscr.CellBorderStyle.Diagonal) == Gscr.CellBorderStyle.Diagonal)
                                    {
                                        if (!((cellStyle & Gscr.CellBorderStyle.Diagonal) == Gscr.CellBorderStyle.Diagonal))
                                        {
                                            cellStyle = cellStyle | Gscr.CellBorderStyle.Diagonal;
                                        }
                                    }
                                    //双斜
                                    if ((frmCellBorderDlg.Border & Gscr.CellBorderStyle.TwoDiagonal) == Gscr.CellBorderStyle.TwoDiagonal)
                                    {
                                        if (!((cellStyle & Gscr.CellBorderStyle.TwoDiagonal) == Gscr.CellBorderStyle.TwoDiagonal))
                                        {
                                            cellStyle = cellStyle | Gscr.CellBorderStyle.TwoDiagonal;
                                        }
                                    }

                                    cell.BorderStyle = cellStyle;
                                }
                            }
                        }

                        return;
                    }
                    else
                    {
                        Collection<Range> list = report1.GetSeletionRectangleList();
                        foreach (Range r in list)
                        {
                            report1.SetCellBorderStyle(r, frmCellBorderDlg.Border);
                        }
                        propertyGridCell.Refresh();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message,
                        "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        //颜色
        private void foreColorToolStripButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.FullOpen = true;
                dlg.Color = (report1.CurrentCell == null) ? Color.White : report1.CurrentCell.ForeColor;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    Color color = dlg.Color;
                    foreach (Cell cell in report1.SelectedCells)
                    {
                        cell.ForeColor = color;
                    }
                    propertyGridCell.Refresh();
                }
            }
        }

        private void backColorToolStripButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.FullOpen = true;
                dlg.Color = (report1.CurrentCell == null) ? Color.White : report1.CurrentCell.BackColor;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    Color color = dlg.Color;
                    foreach (Cell cell in report1.SelectedCells)
                    {
                        cell.BackColor = color;
                    }
                    propertyGridCell.Refresh();
                }
            }
        }

        //求和等
        private void sumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (report1.ColumnCount == 0)
            {
                MessageBox.Show("列数为零，不能写入求和公式。",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (report1.SummaryRows.Count == 0)
            {
                //加入一行
                report1.AddRow(Band.Summary);
            }

            if (report1.CurrentCell != null)
            {
                Cell cell;
                int rowIndex = report1.Rows.IndexOf(report1.SummaryRows[0]);
                foreach (Cell c in report1.SelectedCells)
                {
                    cell = report1.GetCell(rowIndex, c.ColumnIndex);
                    cell.FormulaExpression = "=Sum([" + report1.Columns[c.ColumnIndex].ColumnName + "])";
                }
                propertyGridCell.Refresh();
            }
        }

        private void avgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (report1.ColumnCount == 0)
            {
                MessageBox.Show("列数为零，不能写入求平均值公式。",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (report1.SummaryRows.Count == 0)
            {
                //加入一行
                report1.AddRow(Band.Summary);
            }

            if (report1.CurrentCell != null)
            {
                Cell cell;
                int rowIndex = report1.Rows.IndexOf(report1.SummaryRows[0]);
                foreach (Cell c in report1.SelectedCells)
                {
                    cell = report1.GetCell(rowIndex, c.ColumnIndex);
                    cell.FormulaExpression = "=Avg([" + report1.Columns[c.ColumnIndex].ColumnName + "])";
                }
                propertyGridCell.Refresh();
            }
        }

        private void countToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (report1.ColumnCount == 0)
            {
                MessageBox.Show("列数为零，不能写入求计数公式。",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (report1.SummaryRows.Count == 0)
            {
                //加入一行
                report1.AddRow(Band.Summary);
            }

            if (report1.CurrentCell != null)
            {
                Cell cell;
                int rowIndex = report1.Rows.IndexOf(report1.SummaryRows[0]);
                foreach (Cell c in report1.SelectedCells)
                {
                    cell = report1.GetCell(rowIndex, c.ColumnIndex);
                    cell.FormulaExpression = "=Count([" + report1.Columns[c.ColumnIndex].ColumnName + "])";
                }
                propertyGridCell.Refresh();
            }
        }

        private void maxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (report1.ColumnCount == 0)
            {
                MessageBox.Show("列数为零，不能写入求最大值公式。",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (report1.SummaryRows.Count == 0)
            {
                //加入一行
                report1.AddRow(Band.Summary);
            }

            if (report1.CurrentCell != null)
            {
                Cell cell;
                int rowIndex = report1.Rows.IndexOf(report1.SummaryRows[0]);
                foreach (Cell c in report1.SelectedCells)
                {
                    cell = report1.GetCell(rowIndex, c.ColumnIndex);
                    cell.FormulaExpression = "=Max([" + report1.Columns[c.ColumnIndex].ColumnName + "])";
                }
                propertyGridCell.Refresh();
            }
        }

        private void minToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (report1.ColumnCount == 0)
            {
                MessageBox.Show("列数为零，不能写入求最小值公式。",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (report1.SummaryRows.Count == 0)
            {
                //加入一行
                report1.AddRow(Band.Summary);
            }

            if (report1.CurrentCell != null)
            {
                Cell cell;
                int rowIndex = report1.Rows.IndexOf(report1.SummaryRows[0]);
                foreach (Cell c in report1.SelectedCells)
                {
                    cell = report1.GetCell(rowIndex, c.ColumnIndex);
                    cell.FormulaExpression = "=Min([" + report1.Columns[c.ColumnIndex].ColumnName + "])";
                }
                propertyGridCell.Refresh();
            }
        }

        //公式
        private void formulaToolStripButton_Click(object sender, EventArgs e)
        {
            bool isSameFormula = true;
            string formula = null;
            if (report1.CurrentCell != null)
            {
                formula = report1.CurrentCell.FormulaExpression;
                foreach (Cell cell in report1.SelectedCells)
                {
                    if (!isSameFormula || formula != cell.FormulaExpression)
                        isSameFormula = false;
                }
            }

            using (Gscr.Formula.frmFormulaExpression dlg = (isSameFormula) ?
                new Gscr.Formula.frmFormulaExpression(formula) :
                new Gscr.Formula.frmFormulaExpression())
            {
                dlg.ContextReport = report1;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    foreach (Cell cell in report1.SelectedCells)
                    {
                        cell.FormulaExpression = dlg.Expression;
                    }
                    propertyGridCell.Refresh();
                }
            }
        }

        private void editTypeToolStripButton_Click(object sender, EventArgs e)
        {
            if (report1.CurrentCell == null)
                return;

            try
            {
                System.Type editType = report1.CurrentCell.EditType;

                Gscr.Designer.frmEditTypeDlg frmEditTypeDlg = new Gscr.Designer.frmEditTypeDlg();
                frmEditTypeDlg.EditType = editType;
                if (frmEditTypeDlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (Cell cell in report1.SelectedCells)
                    {
                        cell.EditType = frmEditTypeDlg.EditType;
                    }
                }
            }
            catch
            {
                MessageBox.Show("请选择单元格。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SQLToolStripButton_Click(object sender, EventArgs e)
        {
            Gscr.Designer.frmSQLEditor frmSQLEditor = new Gscr.Designer.frmSQLEditor(report1);
            if (frmSQLEditor.ShowDialog() == DialogResult.OK)
            {
                report1.SelectSQL = frmSQLEditor.syntaxRichTextBoxSQL.Text;
                propertyGridReport.Refresh();
            }
        }

        #endregion

        #region 工具栏菜单(合并，增加，插入，删除)

        //合并
        private void mergeToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Collection<Range> list = report1.GetSeletionRectangleList();
                foreach (Range r in list)
                {
                    if (r.Equals(Range.Empty))
                        continue;

                    report1.MergeCells(r.StartPosition.RowIndex, r.StartPosition.ColumnIndex, r.EndPosition.RowIndex, r.EndPosition.ColumnIndex);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelMergeToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                report1.CancelMergeCells(report1.CurrentCell);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //增加 
        private void titleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report1.AddRow(Band.Title);
        }

        private void headerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report1.AddRow(Band.Header);
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report1.AddRow(Band.Detail);
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report1.AddRow(Band.Summary);
        }

        private void footerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report1.AddRow(Band.Footer);
        }

        /// <summary>
        /// 增加列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addColumnToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                report1.AddColumn();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //插入
        /// <summary>
        /// 插入行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertRowToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (report1.RowCount == 0)
                {
                    report1.AddRow(Band.Detail);
                    return;
                }

                if (report1.CurrentCell == null)
                {
                    report1.AddRow(Band.Detail);
                    return;
                }
                else
                {
                    //转换成相对索引
                    Band band = Band.None;
                    int bandIndex = report1.RowsIndexToBandIndex(report1.CurrentCell.RowIndex, out band);
                    report1.InsertRow(band, bandIndex);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 插入列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertColumnToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (report1.ColumnCount == 0)
                {
                    report1.AddColumn();
                    return;
                }

                if (report1.CurrentCell == null)
                {
                    report1.AddColumn();
                    return;
                }
                else
                {
                    report1.InsertColumn(report1.CurrentCell.ColumnIndex);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //删除
        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteRowToolStripButton_Click(object sender, EventArgs e)
        {
            if (report1.RowCount == 0)
            {
                return;
            }

            if (report1.SelectedCells.Count == 0)
            {
                return;
            }

            try
            {
                Range range = report1.GetSeletionRange(report1.CurrentCell);
                if (range.StartPosition.RowIndex < 0 || range.EndPosition.RowIndex < 0)
                {
                    return;
                }

                if (MessageBox.Show(
                    ((range.StartPosition.RowIndex == range.EndPosition.RowIndex) ?
                    "确定删除第[" + range.StartPosition.RowIndex.ToString() + "]行？" :
                    "确定删除第[" + range.StartPosition.RowIndex.ToString() + "]-[" + range.EndPosition.RowIndex.ToString() + "]行？"),
                    "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Band band = Band.None;
                    for (int i = range.StartPosition.RowIndex; i <= range.EndPosition.RowIndex; i++)
                    {
                        band = Band.None;
                        int bandIndex = report1.RowsIndexToBandIndex(range.StartPosition.RowIndex, out band);
                        report1.DeleteRow(band, bandIndex);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        /// <summary>
        /// 删除列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteColumnToolStripButton_Click(object sender, EventArgs e)
        {
            if (report1.ColumnCount == 0)
            {
                return;
            }

            if (report1.SelectedCells.Count == 0)
            {
                return;
            }

            try
            {
                Range range = report1.GetSeletionRange(report1.CurrentCell);
                if (range.StartPosition.ColumnIndex < 0 || range.EndPosition.ColumnIndex < 0)
                {
                    return;
                }

                if (MessageBox.Show(
                    ((range.StartPosition.ColumnIndex == range.EndPosition.ColumnIndex) ?
                    "确定删除列 " + PublicFuntion.GetColumnName(range.StartPosition.ColumnIndex + 1) + " ？" :
                    "确定删除列 " + PublicFuntion.GetColumnName(range.StartPosition.ColumnIndex + 1) + " - 列 " + PublicFuntion.GetColumnName(range.EndPosition.ColumnIndex + 1) + " ？"),
                    "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    report1.DeleteColumn(range.StartPosition.ColumnIndex, range.ColumnsCount);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        #endregion

    }
}