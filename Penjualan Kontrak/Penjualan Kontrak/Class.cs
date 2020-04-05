using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Penjualan_Kontrak
{
    class Class
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static DataRow dr;
        public static SqlCommandBuilder cbl;

        public static void buatkoneksi()
        {
            con = new SqlConnection("data source= localhost; initial catalog=Penjualan_Database; integrated security=true");
            con.Open();
        }
    }
}
