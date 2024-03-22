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
            string query = "UPDATE AssessmentComponent SET Name = @Name, RubricId = @RubricId, TotalMarks = @TotalMarks, DateCreated = @DateCreated, AssessmentId = @AssessmentId";
            using (SqlConnection conConn = new SqlConnection(CRUDQueries.connectionString))
            {
                conConn.Open();
                SqlCommand cmd = new SqlCommand(query, conConn);
                cmd.Parameters.AddWithValue("@Name", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@RubricId", richTextBox2.Text);
                cmd.Parameters.AddWithValue("@TotalMarks", richTextBox3.Text);
                cmd.Parameters.AddWithValue("@DateCreated", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@DateUpdated", dateTimePicker2.Text);
                cmd.Parameters.AddWithValue("@AssessmentId", richTextBox6.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Message Updated Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        
    }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 assessment = new Form1();
            assessment.Show();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM AssessmentComponent";
            DataTable dt = new DataTable();
            dt = CRUDQueries.ShowDataInTables(query);
            dataGridView1.DataSource = dt;
        }
    }
}
