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
            string query = "SELECT * FROM Assessment WHERE Id = @ID";
            using (SqlConnection conConn = new SqlConnection(CRUDQueries.connectionString))
            {

                SqlCommand cmd = new SqlCommand(query, conConn);
                conConn.Open();
                cmd.Parameters.AddWithValue("@ID", int.Parse(richTextBox9.Text));
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        richTextBox4.Text = reader["Title"].ToString();
                        dateTimePicker1.Text = reader["DateCreated"].ToString();
                        richTextBox5.Text = reader["TotalMarks"].ToString();
                        richTextBox8.Text = reader["TotalWeightage"].ToString();
                        richTextBox5.Show();
                        richTextBox8.Show();
                        richTextBox4.Show();
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
           CRUDQueries.ShowAssessmentMainPage(this);
        }
    }
}
