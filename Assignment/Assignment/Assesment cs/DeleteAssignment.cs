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
    public partial class DeleteAssignment : Form
    {
        public DeleteAssignment()
        {
            InitializeComponent();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connectionString = "server= localhost\\SQLEXPRESS01; database= ProjectB; trusted_connection= true";
            string query = "DELETE  FROM Assessment WHERE Title = @Title";
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@Title", maskedTextBox1.Text);
                try 
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted Successfully");
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
               
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddAssignment addAssignment = new AddAssignment();
            addAssignment.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateAssignment updateAssignment = new UpdateAssignment();
            updateAssignment.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAssesment form = new ViewAssesment();
            form.Show();
        }
    }
}
