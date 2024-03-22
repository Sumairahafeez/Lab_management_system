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
            CRUDQueries.ShowAssessmentMainPage(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string query = "UPDATE Assessment SET DateCreated=@DateCreated, TotalMarks=@TotalMarks, TotalWeightage=@TotalWeightage";

            using (SqlConnection conConn = new SqlConnection(CRUDQueries.connectionString))
            {

                SqlCommand cmd = new SqlCommand(query, conConn);
                conConn.Open();
                cmd.Parameters.AddWithValue("@Title", richTextBox4.Text);
                cmd.Parameters.AddWithValue("@DateCreated", DateTime.Parse(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(richTextBox8.Text));
                cmd.Parameters.AddWithValue("@TotalWeightage", int.Parse(richTextBox5.Text));
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
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
            
            string query = "SELECT * FROM Assessment WHERE Id = @ID";
            using (SqlConnection conConn = new SqlConnection(CRUDQueries.connectionString))
            {

                SqlCommand cmd = new SqlCommand(query, conConn);
                conConn.Open();
                cmd.Parameters.AddWithValue("@ID",int.Parse(richTextBox9.Text));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    richTextBox4.Text = reader["Title"].ToString();
                    dateTimePicker1.Text = reader["DateCreated"].ToString();
                    richTextBox5.Text = reader["TotalMarks"].ToString() ;
                    richTextBox8.Text = reader["TotalWeightage"].ToString();
                    richTextBox5.Show();
                    richTextBox8.Show();
                    richTextBox4.Show();
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowAddAssignment(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowDeleteAssignment(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowViewAssignment(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Assessment";
            DataTable dt = CRUDQueries.ShowDataInTables(query);
            dgb1.DataSource = dt;
        }
    }
}
