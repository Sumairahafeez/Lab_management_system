using Assignment.Global_Function;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment.Rubrics
{
    public partial class AddRubrics : Form
    {
        public AddRubrics()
        {
            InitializeComponent();
        }

        private void dgb1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "server= localhost\\SQLEXPRESS01; database= ProjectB; trusted_connection= true";
            string query = "INSERT INTO Rubric VALUES (@CloId, @Details)";
            

            using (SqlConnection conConn = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand(query, conConn);
                conConn.Open();
                cmd.Parameters.AddWithValue("@CloId", int.Parse(maskedTextBox1.Text));
                cmd.Parameters.AddWithValue("@Details",richTextBox1.Text);
                
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Entered Successfully");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conConn.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Clo";
            DataTable dt = new DataTable();
            dt = CRUDQueries.ShowDataInTables(query);
            dgb1.DataSource = dt;
        }
    }
}
