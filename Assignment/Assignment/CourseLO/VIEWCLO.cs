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

namespace Assignment.CourseLO
{
    public partial class VIEWCLO : Form
    {
        public VIEWCLO()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string URL_of_connection = "Data Source=DESKTOP-8GUTOUI\\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True";
            try
            {
                string query = "SELECT * FROM Clo WHERE ID = @ID";
                using (SqlConnection conConn = new SqlConnection(URL_of_connection))
                {

                    SqlCommand cmd = new SqlCommand(query, conConn);
                    conConn.Open();
                    cmd.Parameters.AddWithValue("@ID", maskedTextBox1.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        maskedTextBox2.Text = reader["Name"].ToString();
                        dateTimePicker1.Text = reader["DateCreated"].ToString();
                        dateTimePicker2.Text = reader["DateUpdated"].ToString();
                        maskedTextBox2.Show();
                        dateTimePicker1.Show();
                        dateTimePicker2.Show();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-8GUTOUI\\SQLEXPRESS01;Database=master;trusted_connection=true";
            string query = "SELECT * From Clo";
            try
            {
                DataTable db1 = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(db1);
                    dataGridView1.DataSource = db1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainCLO mainCLO = new MainCLO();
            mainCLO.Show();
        }
    }
}
