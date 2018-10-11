using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Example
{
    public static class DBConfig 
    {

        public static string ProviderName = "System.Data.OleDb";
        public static string ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + Application.StartupPath + "\\Data.mdb";

    }

}
