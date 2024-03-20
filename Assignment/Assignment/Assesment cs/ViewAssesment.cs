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

namespace Assignment
{
    public partial class ViewAssesment : Form
    {
        public static Form1 firstPage = new Form1();
        public ViewAssesment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            string query = "SELECT * FROM Assessment";
            DataTable db1 = new DataTable();
            DataTable dt = CRUDQueries.ShowDataInTables(query);
            dgb1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "server= localhost\\SQLEXPRESS01; database= ProjectB; trusted_connection= true";
            string query = "SELECT * FROM Assessment WHERE Title = @Title";
            using (SqlConnection conConn = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand(query, conConn);
                conConn.Open();
                cmd.Parameters.AddWithValue("@Title", maskedTextBox1.Text);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        maskedTextBox2.Text = reader["DateCreated"].ToString();
                        maskedTextBox3.Text = reader["TotalMarks"].ToString();
                        maskedTextBox4.Text = reader["TotalWeightage"].ToString();
                        maskedTextBox2.Show();
                        maskedTextBox3.Show();
                        maskedTextBox4.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            firstPage.Show();
        }
    }
}
