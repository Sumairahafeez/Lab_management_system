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
                cmd.Parameters.AddWithValue("@Title", maskedTextBox1.Text);
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
                cmd.Parameters.AddWithValue("@RubricId", maskedTextBox2.Text);
                cmd.Parameters.AddWithValue("@TotalMarks", maskedTextBox3.Text);
                cmd.Parameters.AddWithValue("@DateCreated", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@DateUpdated",dateTimePicker2.Text);
                cmd.Parameters.AddWithValue("@AssessmentId", maskedTextBox6.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Message Updated Successfully");
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
            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Rubric";
            DataTable dt = new DataTable();
            dt = CRUDQueries.ShowDataInTables(query);
            dataGridView2.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAssComp view = new ViewAssComp();
            view.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteAssComp del = new DeleteAssComp();
            del.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAssComp view = new ViewAssComp();
            view.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}
