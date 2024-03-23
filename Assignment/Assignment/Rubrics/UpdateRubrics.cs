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
    public partial class UpdateRubrics : Form
    {
        public UpdateRubrics()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowAddRubrics(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowDeleteRubrics(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowViewRubrics(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowMainRubrics(this);
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

        private void button9_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Rubric WHERE Id = @ID";
            using(SqlConnection con  = new SqlConnection(CRUDQueries.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(richTextBox3.Text));
                try
                {
                   
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        richTextBox4.Text = reader["CloId"].ToString();
                        richTextBox5.Text = reader["Details"].ToString();
                        richTextBox4.Show();
                        richTextBox5.Show();
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
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Rubric SET  CloId = @CLOID, Details = @Description";
            using(SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query,con);
                
                cmd.Parameters.AddWithValue("@CLOID", int.Parse(richTextBox4.Text));
                cmd.Parameters.AddWithValue("@Description",richTextBox5.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
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
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query2 = "SELECT * FROM Clo";
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
    }
}
