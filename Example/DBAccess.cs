using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;

namespace Example
{
    public static class DBAccess
    {

        public static DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(DBConfig.ConnectionString);

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, conn);
                //填充DataSet
                dataAdapter.Fill(dt);
                dataAdapter.Dispose();
            }
            catch (Exception err)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Dispose();
            }

            return dt;
        }


    }
}
