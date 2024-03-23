using Assignment.AssComponents;
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

namespace Assignment.Assesment_cs
{
    public partial class UpdateAssComp : Form
    {
        public UpdateAssComp()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM AssessmentComponent WHERE Name = @Name";
            using (SqlConnection conConn = new SqlConnection(CRUDQueries.connectionString))
            {

                SqlCommand cmd = new SqlCommand(query, conConn);
                conConn.Open();
                cmd.Parameters.AddWithValue("@Name", maskedTextBox1.Text);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        maskedTextBox2.Text = reader["RubricId"].ToString();
                        maskedTextBox3.Text = reader["TotalMarks"].ToString();
                        dateTimePicker1.Text = reader["DateCreated"].ToString();
                        dateTimePicker2.Text = reader["DateUpdated"].ToString();
                        maskedTextBox6.Text = reader["AssessmentId"].ToString();
                        maskedTextBox2.Show();
                        maskedTextBox3.Show();
                        dateTimePicker1.Show();
                        dateTimePicker2.Show();
                        maskedTextBox6.Show();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "UPDATE AssessmentComponent SET Name = @Name, RubricId = @RubricId, TotalMarks = @TotalMarks, DateCreated = @DateCreated, AssessmentId = @AssessmentId";
            using(SqlConnection conConn = new SqlConnection(CRUDQueries.connectionString))
            {
                conConn.Open();
                SqlCommand cmd = new SqlCommand(query,conConn);
                cmd.Parameters.AddWithValue("@Name", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@RubricId", int.Parse(maskedTextBox2.Text));
                cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(maskedTextBox3.Text));
                cmd.Parameters.AddWithValue("@DateCreated", DateTime.Parse(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@DateUpdated",DateTime.Parse(dateTimePicker2.Text));
                cmd.Parameters.AddWithValue("@AssessmentId", int.Parse(maskedTextBox6.Text));
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Assessment";
            DataTable dt = new DataTable();
            dt = CRUDQueries.ShowDataInTables(query);
            try
            {
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Rubric";
            DataTable dt = new DataTable();
            dt = CRUDQueries.ShowDataInTables(query);
            try
            {
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowViewAssComp(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowDeleteAssComp(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowViewAssComp(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowAssessmentMainPage(this);
        }
    }
}
