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
    public partial class UpdateRubricLevel : Form
    {
        public UpdateRubricLevel()
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

        private void button7_Click(object sender, EventArgs e)
        {
            string query2 = "SELECT * FROM Rubric";
            DataTable dt = new DataTable();
            dt = CRUDQueries.ShowDataInTables(query2);
            try
            {
                dgb1.DataSource = dt;
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
                cmd.Parameters.AddWithValue("@ID", int.Parse(richTextBox8.Text));
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        richTextBox4.Text = reader["RubricId"].ToString();

                        richTextBox5.Text = reader["Details"].ToString();
                        richTextBox6.Text = reader["MeasurementLevel"].ToString();
                        richTextBox5.Show();
                        richTextBox6.Show();
                        richTextBox4.Show();
                    }
                    string query2 = "SELECT * FROM Rubric";
                    DataTable dt = new DataTable();
                    dt = CRUDQueries.ShowDataInTables(query2);
                    try
                    {
                        dgb1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowAddRubricsLevel(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowDeleteRubricsLevel(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowViewRubricsLevel(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowMainRubricsLevel(this);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string query = "UPDATE RubricLevel SET RubricId = @RubricID, Details = @Detail, MeasurementLevel = @MeasurementLevel";
            using(SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RubricID", int.Parse(richTextBox4.Text));
                cmd.Parameters.AddWithValue("@Detail",richTextBox5.Text);
                cmd.Parameters.AddWithValue("@MeasurementLevel",int.Parse(richTextBox6.Text));
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
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
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }
    }
}
