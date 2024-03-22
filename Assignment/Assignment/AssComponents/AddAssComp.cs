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
            this.Hide();
            DeleteAssComp delete = new DeleteAssComp();
            delete.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateAssComp update = new UpdateAssComp();
            update.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Assessment";
            DataTable dataTable = new DataTable();
            dataTable = CRUDQueries.ShowDataInTables(query);
            dataGridView1.DataSource = dataTable;
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
                cmd.Parameters.AddWithValue("@RubricId",int.Parse(maskedTextBox2.Text));
                cmd.Parameters.AddWithValue("@TotalMarks",int.Parse(maskedTextBox3.Text));
                cmd.Parameters.AddWithValue("@DateCreated", DateTime.Parse(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@DateUpdated",DateTime.Parse(dateTimePicker2.Text));
                cmd.Parameters.AddWithValue("@AssessmentId",int.Parse(maskedTextBox6.Text));
                try
                {
                    cmd.ExecuteNonQuery();
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
            this.Hide();
            ViewAssComp view = new ViewAssComp();
            view.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
    }
}
