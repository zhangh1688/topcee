using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Example
{
    public partial class frmSelectSex : Form
    {
        private string _sex;
        public string Sex
        {
            get { return _sex; }
            set
            {
                if (_sex != value)
                {
                    _sex = value;
                    if (_sex == "1")
                    {
                        radioButton1.Checked = true;
                    }
                    else if (_sex == "2")
                    {
                        radioButton2.Checked = true;
                    }
                }
            }
        }

        public frmSelectSex()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _sex = (radioButton1.Checked) ? "1" : "2";
        }
    }
}
