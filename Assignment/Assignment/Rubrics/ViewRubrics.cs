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

namespace Assignment.Rubrics
{
    public partial class ViewRubrics : Form
    {
        public ViewRubrics()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowMainRubrics(this);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Rubric WHERE Id = @ID";
            using (SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(comboBox1.Text));
                try
                {

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox2.Text = reader["CloId"].ToString();
                        richTextBox5.Text = reader["Details"].ToString();
                        comboBox2.Show();
                        richTextBox5.Show();
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query2 = "SELECT * FROM Rubric";
            DataTable dt = new DataTable();
            dt = CRUDQueries.ShowDataInTables(query2);
            try
            {
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ViewRubrics_Load(object sender, EventArgs e)
        {
            string query2 = "SELECT * FROM Rubric";
            DataTable dt = new DataTable();
            dt = CRUDQueries.ShowDataInTables(query2);
            try
            {
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string query3 = "SELECT Id From Rubric";
            DataTable dt3 = new DataTable();
            dt3 = CRUDQueries.ShowDataInTables(query3);
            comboBox1.DataSource = dt3;
            comboBox1.DisplayMember = "Id";
        }
    }
}
