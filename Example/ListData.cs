using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;

namespace Example
{

    public class ListData
    {
        public static List<Bill> Select()
        {
            List<Bill> list = new List<Bill>();

            for (int i = 0; i < 20; i++)
            {
                Bill bill = new Bill();

                if (i < 3)
                {
                    bill.单据号 = "XSD000001";
                    bill.仓库 = "主仓库";
                    bill.供应商 = "000001";
                    bill.金额 = 10000;
                    bill.单位 = 1;
                }

                if (i >= 3 && i < 10)
                {
                    bill.单据号 = "XSD000002";
                    bill.仓库 = "主仓库";
                    bill.供应商 = "000002";
                    bill.金额 = 20000;
                    bill.单位 = 2;
                }

                if (i >= 10)
                {
                    bill.单据号 = "XSD000003";
                    bill.仓库 = "主仓库";
                    bill.供应商 = "000003";
                    bill.金额 = 30000;
                    bill.单位 = 3;
                }


                bill.商品编码 = (i + 1).ToString().PadLeft(6, '0');
                bill.商品名称 = "商品" + (i + 1).ToString();
                bill.数量 = i + 3;
                list.Add(bill);
            }

            return list;
        }
    }

    public class Bill
    {
        private string _单据号;
        public string 单据号
        {
            get { return _单据号; }
            set { _单据号 = value; }
        }

        private string _仓库;
        public string 仓库
        {
            get { return _仓库; }
            set { _仓库 = value; }
        }

        private string _供应商;
        public string 供应商
        {
            get { return _供应商; }
            set { _供应商 = value; }
        }

        private double _金额;
        public double 金额
        {
            get { return _金额; }
            set { _金额 = value; }
        }

        private string _商品编码;
        public string 商品编码
        {
            get { return _商品编码; }
            set { _商品编码 = value; }
        }

        private string _商品名称;
        public string 商品名称
        {
            get { return _商品名称; }
            set { _商品名称 = value; }
        }

        private int _单位;
        public int 单位
        {
            get { return _单位; }
            set { _单位 = value; }
        }

        private int _数量;
        public int 数量
        {
            get { return _数量; }
            set { _数量 = value; }
        }

        public Bill()
        {
        }

    }

    public class Unit
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _unitName;
        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; }
        }


        public Unit(int id, string unitName)
        {
            _id = id;
            _unitName = unitName;
        }

    }

}
