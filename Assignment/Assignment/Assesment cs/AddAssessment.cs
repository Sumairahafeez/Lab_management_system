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
    public partial class AddAssessment : Form
    {
        public AddAssessment()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowViewAssignment(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowUpdateAssignment(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           CRUDQueries.ShowDeleteAssignment(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowAssessmentMainPage(this);

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Assessment VALUES(@Title,@DateCreated,@TotalMarks,@TotalWeightage)";
            using(SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@DateCreated",DateTime.Parse(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(richTextBox5.Text));
                cmd.Parameters.AddWithValue("@TotalWeightage", int.Parse(richTextBox6.Text));
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Assessment Added Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
