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
    public partial class AddAssignment : Form
    {
        public AddAssignment()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server= localhost\\SQLEXPRESS01; database= ProjectB; trusted_connection= true";
            string query = "INSERT INTO Assessment VALUES(@Title, @DateCreated, @TotalMarks, @TotalWeightage)";
            
            using(SqlConnection conConn = new SqlConnection(connectionString))
            {
               
                SqlCommand cmd = new SqlCommand(query, conConn);
                conConn.Open();
                cmd.Parameters.AddWithValue("@Title", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@DateCreated", DateTime.Parse(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@TotalMarks",int.Parse(maskedTextBox3.Text));
                cmd.Parameters.AddWithValue("@TotalWeightage",int.Parse(maskedTextBox4.Text));
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Entered Successfully");
                }
                   
                    catch(Exception ex)
                {
                    MessageBox.Show("INVALID INPUT");
                }
                conConn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 from = new Form1();
            from.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateAssignment updateAssignment = new UpdateAssignment();
            updateAssignment.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteAssignment deleteAssignment = new DeleteAssignment();
            deleteAssignment.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAssesment viewAssesment = new ViewAssesment();
            viewAssesment.Show();
        }
    }
}
