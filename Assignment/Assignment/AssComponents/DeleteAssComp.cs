using Assignment.Assesment_cs;
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
    public partial class DeleteAssComp : Form
    {
        public DeleteAssComp()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM AssessmentComponent";
            DataTable dt = new DataTable();
            dt = CRUDQueries.ShowDataInTables(query);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddAssComp add = new AddAssComp();
            add.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateAssComp update = new UpdateAssComp();
            update.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "DELETE  FROM AssessmentComponent WHERE Id = @Id";
            using (SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@Id", maskedTextBox1.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAssComp view = new ViewAssComp();
            view.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
    }
}
