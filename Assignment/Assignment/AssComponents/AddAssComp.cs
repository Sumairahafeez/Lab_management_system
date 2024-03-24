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
    public partial class AddAssComp : Form
    {
        public AddAssComp()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowDeleteAssComp(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            CRUDQueries.ShowUpdateAssComp(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Assessment";
            DataTable dataTable = new DataTable();
            dataTable = CRUDQueries.ShowDataInTables(query);
            try
            {
                dataGridView1.DataSource = dataTable;
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Rubric";
            DataTable dataTable = new DataTable();
            dataTable = CRUDQueries.ShowDataInTables(query);
            try
            {
                dataGridView2.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO  AssessmentComponent VALUES(@Name,@RubricId,@TotalMarks,@DateCreated,@DateUpdated,@AssessmentId)";
            using(SqlConnection conn = new SqlConnection(CRUDQueries.connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@Name", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@RubricId",int.Parse(comboBox1.Text));
                cmd.Parameters.AddWithValue("@TotalMarks",int.Parse(maskedTextBox3.Text));
                cmd.Parameters.AddWithValue("@DateCreated", DateTime.Parse(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@DateUpdated",DateTime.Parse(dateTimePicker2.Text));
                cmd.Parameters.AddWithValue("@AssessmentId",int.Parse(comboBox2.Text));
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Added Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowViewAssComp(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowAssessmentMainPage(this);
        }

        private void AddAssComp_Load(object sender, EventArgs e)
        {
            string query1 = "SELECT Id FROM Rubric";
            DataTable dt = new DataTable();
            dt = CRUDQueries.ShowDataInTables(query1);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Id";
            string query2 = "SELECT Id FROM Assessment";
            DataTable dt1 = new DataTable();
            dt1 = CRUDQueries.ShowDataInTables(query2);
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "Id";
            string query = "SELECT * FROM Rubric";
            DataTable dataTable = new DataTable();
            dataTable = CRUDQueries.ShowDataInTables(query);
            try
            {
                dataGridView2.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string query5 = "SELECT * FROM Assessment";
            DataTable dataTable2 = new DataTable();
            dataTable2 = CRUDQueries.ShowDataInTables(query5);
            try
            {
                dataGridView1.DataSource = dataTable2;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
