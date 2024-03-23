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
    public partial class DeleteRubricLevel : Form
    {
        public DeleteRubricLevel()
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

        private void button9_Click(object sender, EventArgs e)
        {
            string query = "DELETE  FROM RubricLevel WHERE Id = @ID";
            using (SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@ID", int.Parse(richTextBox8.Text));
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted Successfully");
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

        private void button1_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowAddRubricsLevel(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowUpdateRubricsLevel(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowViewRubricsLevel(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowMainRubricsLevel(this);
        }
    }
}
