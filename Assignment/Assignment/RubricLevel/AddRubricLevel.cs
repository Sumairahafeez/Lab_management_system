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
    public partial class AddRubricLevel : Form
    {
        public AddRubricLevel()
        {
            InitializeComponent();
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

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO RubricLevel VALUES(@RubricId,@Details,@MeasurementLevel)";
            using (SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RubricId", int.Parse(comboBox1.Text));
                cmd.Parameters.AddWithValue("@Details",richTextBox5.Text);
                cmd.Parameters.AddWithValue("@MeasurementLevel",int.Parse(richTextBox6.Text));
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Added Successfully");
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
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowUpdateRubricsLevel(this);
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void AddRubricLevel_Load(object sender, EventArgs e)
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
            string query = "SELECT * FROM Rubric";
            DataTable dt1 = new DataTable();
            dt1 = CRUDQueries.ShowDataInTables(query);
            try
            {
                dgb1.DataSource = dt1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string q1 = "SELECT Id FROM Rubric";
            DataTable dt2 = new DataTable();
            dt2 = CRUDQueries.ShowDataInTables(q1);
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "Id";
        }
    }
}
