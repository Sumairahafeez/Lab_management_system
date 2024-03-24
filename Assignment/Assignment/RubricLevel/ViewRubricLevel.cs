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

namespace Assignment.RubricLevel
{
    public partial class ViewRubricLevel : Form
    {
        public ViewRubricLevel()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query2 = "SELECT * FROM RubricLevel";
            DataTable dt = new DataTable();
            dt = CRUDQueries.ShowDataInTables(query2);
            try
            {
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM RubricLevel WHERE Id = @ID";
            using (SqlConnection conConn = new SqlConnection(CRUDQueries.connectionString))
            {

                SqlCommand cmd = new SqlCommand(query, conConn);
                conConn.Open();
                cmd.Parameters.AddWithValue("@ID", int.Parse(comboBox1.Text));
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox2.Text = reader["RubricId"].ToString();

                        richTextBox5.Text = reader["Details"].ToString();
                        richTextBox6.Text = reader["MeasurementLevel"].ToString();
                        richTextBox5.Show();
                        richTextBox6.Show();
                        comboBox2.Show();
                    }
                    string query2 = "SELECT * FROM RubricLevel";
                    DataTable dt = new DataTable();
                    dt = CRUDQueries.ShowDataInTables(query2);
                    try
                    {
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowMainRubricsLevel(this);
        }

        private void ViewRubricLevel_Load(object sender, EventArgs e)
        {
            string query3 = "SELECT * FROM RubricLevel";
            DataTable dt2 = new DataTable();
            dt2 = CRUDQueries.ShowDataInTables(query3);
            try
            {
                dataGridView1.DataSource = dt2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string q1 = "SELECT Id FROM Rubric";
            DataTable dt3 = new DataTable();
            dt3 = CRUDQueries.ShowDataInTables(q1);
            comboBox1.DataSource = dt3;
            comboBox1.DisplayMember = "Id";
            string q2 = "SELECT Id FROM RubricLevel";
            DataTable dt4 = new DataTable();
            dt4 = CRUDQueries.ShowDataInTables(q2);
            comboBox2.DataSource = dt4;
            comboBox2.DisplayMember = "Id";
        }
    }
}
