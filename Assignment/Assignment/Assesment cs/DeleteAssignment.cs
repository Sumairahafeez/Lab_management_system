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
    public partial class DeleteAssignment : Form
    {
        public DeleteAssignment()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // string connectionString = "server= localhost\\SQLEXPRESS01; database= ProjectB; trusted_connection= true";
            string query = "SELECT * FROM Assessment WHERE Id = @ID";
            using (SqlConnection conConn = new SqlConnection(CRUDQueries.connectionString))
            {

                SqlCommand cmd = new SqlCommand(query, conConn);
                conConn.Open();
                cmd.Parameters.AddWithValue("@ID", int.Parse(comboBox1.Text));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    richTextBox8.Text = reader["Title"].ToString();
                    dateTimePicker1.Text = reader["DateCreated"].ToString();
                    richTextBox4.Text = reader["TotalMarks"].ToString();
                    richTextBox5.Text = reader["TotalWeightage"].ToString();
                    richTextBox8.Show();
                    dateTimePicker1.Show();
                    richTextBox4.Show();
                    richTextBox5.Show();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            string query = "DELETE  FROM Assessment WHERE Id = @ID";
            using(SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@ID", int.Parse(comboBox1.Text));
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
            CRUDQueries.ShowAddAssignment(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowUpdateAssignment(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowViewAssignment(this);
        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowAssessmentMainPage(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Assessment";
            DataTable dt = CRUDQueries.ShowDataInTables(query);
            dgb1.DataSource = dt;
        }

        private void DeleteAssignment_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Assessment";
            DataTable dt = CRUDQueries.ShowDataInTables(query);
            dgb1.DataSource = dt;
            string query2 = "SELECT Id FROM Assessment";
            DataTable dt2 = CRUDQueries.ShowDataInTables(query2);
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "Id";
        }
    }
}
