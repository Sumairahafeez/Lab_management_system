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

namespace Assignment.STD
{
    public partial class VIEW : Form
    {
        public VIEW()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //string URL_of_connection = "Data Source=DESKTOP-8GUTOUI\\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True";
            try
            {
                string query = "SELECT * FROM Student WHERE ID = @ID";
                using (SqlConnection conConn = new SqlConnection(CRUDQueries.connectionString))
                {

                    SqlCommand cmd = new SqlCommand(query, conConn);
                    conConn.Open();
                    cmd.Parameters.AddWithValue("@ID", maskedTextBox1.Text);
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            maskedTextBox2.Text = reader["FirstName"].ToString();
                            maskedTextBox3.Text = reader["LastName"].ToString();
                            maskedTextBox4.Text = reader["Contact"].ToString();
                            maskedTextBox5.Text = reader["Email"].ToString();
                            maskedTextBox6.Text = reader["RegistrationNumber"].ToString();
                            maskedTextBox7.Text = reader["Status"].ToString();
                            maskedTextBox2.Show();
                            maskedTextBox3.Show();
                            maskedTextBox4.Show();
                            maskedTextBox5.Show();
                            maskedTextBox6.Show();
                            maskedTextBox7.Show();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                   
                }
            }
            catch(Exception ex)
            {
            MessageBox .Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // string URL_of_connection = "Data Source=DESKTOP-8GUTOUI\\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True";
            try
            {
                string query = "SELECT * FROM Student";
                using (SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable db1 = new DataTable();
                    adapter.Fill(db1);
                    dgb1.DataSource = db1;
                }
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowLandingPage(this);
        }
    }
}
