using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Assignment.Global_Function
{
    internal class CRUDQueries
    {
        public static string connectionString = "server= localhost\\SQLEXPRESS01; database= ProjectB; trusted_connection= true";
        public static DataTable ShowDataInTables(string query)
        {
            DataTable db1 = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(db1);
                return db1;
                
            }
        }
        
    }
}
