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
    public partial class DELETE : Form
    {
        public DELETE()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string URL_of_connection = "Data Source=DESKTOP-8GUTOUI\\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True";
            try
            {
                string query = "SELECT * FROM Students WHERE ID = @ID";
                using (SqlConnection conConn = new SqlConnection(URL_of_connection))
                {

                    SqlCommand cmd = new SqlCommand(query, conConn);
                    conConn.Open();
                    cmd.Parameters.AddWithValue("@ID", maskedTextBox1.Text);
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
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=DESKTOP-8GUTOUI\\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            try
            {
                string query = "Delete from Students where Id=@Id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", int.Parse(maskedTextBox1.Text));
                try
                {
                    int count = sqlCommand.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("Student Deleted Sucessfully");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADD aDD = new ADD();
            aDD.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainSTD mainSTD = new MainSTD();
            mainSTD.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UPDATE uPDATE = new UPDATE();
            uPDATE.Show();
        }
    }
}
