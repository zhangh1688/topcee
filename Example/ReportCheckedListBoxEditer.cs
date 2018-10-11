using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace Example
{
    /// <summary>
    /// Cell编辑的CheckedListBox(单选项)
    /// </summary>
    [ToolboxItem(false)]
    public class ReportCheckedListBoxEditer : System.Windows.Forms.CheckedListBox, Gscr.Editer.IReportEditer
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;


        #region IReportEditer接口

        private Gscr.ReportBase _contextReport;
        /// <summary>
        /// 获取与此元素关联的 Report 组件。
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Gscr.ReportBase ContextReport
        {
            get { return _contextReport; }
            set
            {
                if (_contextReport != value)
                {
                    _contextReport = value;
                }
            }
        }


        /// <summary>
        /// 编辑控件的值是否改变
        /// </summary>
        public bool ValueIsChanged
        {
            get
            {
                object value = null;
                for (int j = 0; j < this.Items.Count; j++)
                {
                    if (this.GetItemChecked(j))
                    {
                        if (value == null)
                        {
                            value = this.Items[j].ToString();
                        }
                        else
                        {
                            value += ";" + this.Items[j].ToString();
                        }
                    }
                }

                return (value != this.CellOldValue);
            }
        }

        private object _oldValue;
        /// <summary>
        /// 编辑控件旧的值
        /// </summary>
        public object CellOldValue
        {
            get { return _oldValue; }
        }


        /// <summary>
        /// 编辑控件新输入的值
        /// </summary>
        public object CellNewValue
        {
            get
            {
                object value = null;
                if (this.ValueIsChanged)
                {
                    for (int j = 0; j < this.Items.Count; j++)
                    {
                        if (this.GetItemChecked(j))
                        {
                            if (value == null)
                            {
                                value = this.Items[j].ToString();
                            }
                            else
                            {
                                value += ";" + this.Items[j].ToString();
                            }
                        }
                    }

                    return value;
                }
                else
                {
                    return this.CellOldValue;
                }
            }
        }


        /// <summary>
        /// 编辑控件的位置
        /// </summary>
        /// <param name="cellBounds"></param>
        public virtual void PositionEditControl(Rectangle cellBounds)
        {
            cellBounds.X += 1;
            cellBounds.Y += 1;
            cellBounds.Width -= 1;
            cellBounds.Height -= 1;
            this.Bounds = cellBounds;
        }


        /// <summary>
        /// 初始化编辑控件的值
        /// </summary>
        /// <param name="cell"></param>
        public virtual void InitEditControlValue(Gscr.Cell cell)
        {
            //Items项中选定与Cell相同的值，各个项目间使用;分割
            object obj = cell.Value;
            if (!(obj == null || obj == DBNull.Value))
            {
                _oldValue = obj.ToString();

                string[] strArrResult = obj.ToString().Split(';');
                for (int i = 0; i < strArrResult.Length; i++)
                {
                    for (int j = 0; j < this.Items.Count; j++)
                    {
                        if (this.Items[j].ToString().CompareTo(strArrResult[i]) == 0)
                        {
                            this.SetItemCheckState(j, CheckState.Checked);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 通知报表控件编辑完成
        /// </summary>
        /// <returns></returns>
        public virtual bool NotifyReportEndEdit()
        {
            return this.ContextReport.CommitEdit();
        }

        /// <summary>
        /// 确定哪些键由当前编辑组件处理
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        public virtual bool EditingControlWantsInputKey(Keys keyData)
        {
            //switch ((keyData & Keys.KeyCode))
            //{
            //    case Keys.Prior:
            //    case Keys.Next:
            //    case Keys.End:
            //    case Keys.Home:
            //    case Keys.Up:
            //    case Keys.Down:
            //        return !this.ContextReport.CommitEdit();

            //    case Keys.Left:
            //    case Keys.Right:
            //            //交付 Report 处理
            //            return false;
            //}

            return true;
        }

        #endregion


        /// <summary>
        /// 构造函数
        /// </summary>
        public ReportCheckedListBoxEditer()
        {
            this.TabStop = false;
            this.BorderStyle = BorderStyle.None;

            this.CheckOnClick = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!e.Handled)
            {
                SendMessage(this.ContextReport.Handle, WM_KEYDOWN, (int)e.KeyCode, (int)e.KeyCode);
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (!e.Handled)
            {
                SendMessage(this.ContextReport.Handle, WM_KEYUP, (int)e.KeyCode, (int)e.KeyCode);
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Return:
                    {
                        //交付 Report 处理
                        SendMessage(this.ContextReport.Handle,WM_KEYDOWN, 13, 13);
                    }
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}
