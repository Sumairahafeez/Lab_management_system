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
    public partial class UpdateAssignment : Form
    {
        public UpdateAssignment()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server= localhost\\SQLEXPRESS01; database= ProjectB; trusted_connection= true";
            string query = "UPDATE Assessment SET DateCreated=@DateCreated, TotalMarks=@TotalMarks, TotalWeightage=@TotalWeightage";

            using (SqlConnection conConn = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand(query, conConn);
                conConn.Open();
                cmd.Parameters.AddWithValue("@Title", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@DateCreated", DateTime.Parse(maskedTextBox2.Text));
                cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(maskedTextBox3.Text));
                cmd.Parameters.AddWithValue("@TotalWeightage", int.Parse(maskedTextBox4.Text));
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
                    maskedTextBox3.Text = reader["TotalMarks"].ToString() ;
                    maskedTextBox4.Text = reader["TotalWeightage"].ToString();
                    maskedTextBox2.Show();
                    maskedTextBox3.Show();
                    maskedTextBox4.Show();
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            //AddAssignment addAssignment = new AddAssignment();
            //addAssignment.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteAssignment deleteAssignment = new DeleteAssignment();
            deleteAssignment.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAssesment viewAssesment = new ViewAssesment();
            viewAssesment.Show();
        }
    }
}
