using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void report1_CellClick(object sender, Gscr.CellEventArgs e)
        {
            if (e.Cell.RowIndex == 1 && e.Cell.ColumnIndex ==1)
            {
                frmExample1 frm1 = new frmExample1();
                frm1.Show();
            }

            if (e.Cell.RowIndex == 2 && e.Cell.ColumnIndex == 1)
            {
                frmExample2 frm2 = new frmExample2();
                frm2.Show();
            }

            if (e.Cell.RowIndex == 3 && e.Cell.ColumnIndex == 1)
            {
                frmExample3 frm3 = new frmExample3();
                frm3.Show();
            }

            if (e.Cell.RowIndex == 4 && e.Cell.ColumnIndex == 1)
            {
                frmExample4 frm4 = new frmExample4();
                frm4.Show();
            }

            if (e.Cell.RowIndex == 5 && e.Cell.ColumnIndex == 1)
            {
                frmExample5 frm5 = new frmExample5();
                frm5.Show();
            }

            if (e.Cell.RowIndex == 6 && e.Cell.ColumnIndex == 1)
            {
                frmExample6 frm6 = new frmExample6();
                frm6.Show();
            }

            if (e.Cell.RowIndex == 7 && e.Cell.ColumnIndex == 1)
            {
                frmExample7 frm7 = new frmExample7();
                frm7.Show();
            }

            if (e.Cell.RowIndex == 8 && e.Cell.ColumnIndex == 1)
            {
                frmReportDesigner frmRptDesigner = new frmReportDesigner();
                frmRptDesigner.Show();
            }

            if (e.Cell.RowIndex == 9 && e.Cell.ColumnIndex == 1)
            {
                frmExample9 frm9 = new frmExample9();
                frm9.Show();
            }

            if (e.Cell.RowIndex == 10 && e.Cell.ColumnIndex == 1)
            {
                frmExample10 frm10 = new frmExample10();
                frm10.Show();
            }

            if (e.Cell.RowIndex == 11 && e.Cell.ColumnIndex == 1)
            {
                frmExample11 frm11 = new frmExample11();
                frm11.Show();
            }

            if (e.Cell.RowIndex == 12 && e.Cell.ColumnIndex == 1)
            {
                frmExample12 frm12 = new frmExample12();
                frm12.Show();
            }

            if (e.Cell.RowIndex == 13 && e.Cell.ColumnIndex == 1)
            {
                frmExample13 frm13 = new frmExample13();
                frm13.Show();
            }

            if (e.Cell.RowIndex == 14 && e.Cell.ColumnIndex == 1)
            {
                frmExample14 frm14 = new frmExample14();
                frm14.Show();
            }

            if (e.Cell.RowIndex == 15 && e.Cell.ColumnIndex == 1)
            {
                frmExample15 frm15 = new frmExample15();
                frm15.Show();
            }

            if (e.Cell.RowIndex == 16 && e.Cell.ColumnIndex == 1)
            {
                frmExample16 frm16 = new frmExample16();
                frm16.Show();
            }

            if (e.Cell.RowIndex == 17 && e.Cell.ColumnIndex == 1)
            {
                frmExample17 frm17 = new frmExample17();
                frm17.Show();
            }

            if (e.Cell.RowIndex == 18 && e.Cell.ColumnIndex == 1)
            {
                frmExample18 frm18 = new frmExample18();
                frm18.Show();
            }

            if (e.Cell.RowIndex == 19 && e.Cell.ColumnIndex == 1)
            {
                frmExample19 frm19 = new frmExample19();
                frm19.Show();
            }

            if (e.Cell.RowIndex == 20 && e.Cell.ColumnIndex == 1)
            {
                frmExample20 frm20 = new frmExample20();
                frm20.Show();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(linkLabel1.Text);
            }
            catch { }
        }

    }
}
