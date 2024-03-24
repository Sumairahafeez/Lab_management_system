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
    public partial class AddRubrics : Form
    {
        public AddRubrics()
        {
            InitializeComponent();
        }

        private void dgb1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            string query = "INSERT INTO Rubric VALUES (@Id,@Details, @CloId)";
            

            using (SqlConnection conConn = new SqlConnection(CRUDQueries.connectionString))
            {

                SqlCommand cmd = new SqlCommand(query, conConn);
                conConn.Open();
                cmd.Parameters.AddWithValue("@Id", int.Parse(richTextBox3.Text));
                cmd.Parameters.AddWithValue("@CloId", int.Parse(comboBox1.Text));
                cmd.Parameters.AddWithValue("@Details",richTextBox5.Text);
                
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Entered Successfully");
                    string query2 = "SELECT * FROM Clo";
                    DataTable dt = new DataTable();
                    dt = CRUDQueries.ShowDataInTables(query2);
                    dgb1.DataSource = dt;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conConn.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query2 = "SELECT * FROM Clo";
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowUpdateRubrics(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowDeleteRubrics(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowViewRubrics(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowMainRubrics(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void AddRubrics_Load(object sender, EventArgs e)
        {
            string query2 = "SELECT * FROM Clo";
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
            string query = "SELECT Id FROM Clo";
            DataTable dt2 = CRUDQueries.ShowDataInTables(query);
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "Id";
        }
    }
}
