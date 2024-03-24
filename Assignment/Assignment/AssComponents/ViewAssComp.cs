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

namespace Assignment.AssComponents
{
    public partial class ViewAssComp : Form
    {
        public ViewAssComp()
        {
            InitializeComponent();
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM AssessmentComponent WHERE Id = @ID";
            using (SqlConnection conConn = new SqlConnection(CRUDQueries.connectionString))
            {
                conConn.Open();
                SqlCommand cmd = new SqlCommand(query, conConn);
                cmd.Parameters.AddWithValue("@ID", int.Parse(comboBox1.Text));
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        richTextBox9.Text = reader["Name"].ToString();
                        comboBox2.Text = reader["RubricId"].ToString();
                        richTextBox11.Text = reader["TotalMarks"].ToString();
                        dateTimePicker1.Text = reader["DateCreated"].ToString();
                        dateTimePicker2.Text = reader["DateUpdated"].ToString();
                        comboBox3.Text = reader["AssessmentId"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowAssessmentMainPage(this);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM AssessmentComponent";
            DataTable dt = new DataTable();
            dt = CRUDQueries.ShowDataInTables(query);
            try
            {
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void richTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewAssComp_Load(object sender, EventArgs e)
        {
            
            string query2 = "SELECT * FROM AssessmentComponent";
            DataTable dt2 = new DataTable();
            dt2 = CRUDQueries.ShowDataInTables(query2);
            try
            {
                dataGridView1.DataSource = dt2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string query3 = "SELECT Id FROM AssessmentComponent";
            DataTable dt3 = new DataTable();
            dt3 = CRUDQueries.ShowDataInTables(query3);
            comboBox1.DataSource = dt3;
            comboBox1.DisplayMember = "Id";
            string query1 = "SELECT Id FROM Rubric";
            DataTable dt4 = new DataTable();
            dt4 = CRUDQueries.ShowDataInTables(query1);
            comboBox1.DataSource = dt4;
            comboBox1.DisplayMember = "Id";
            string query4 = "SELECT Id FROM Assessment";
            DataTable dt1 = new DataTable();
            dt1 = CRUDQueries.ShowDataInTables(query4);
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "Id";
        }
    
    
}
}
