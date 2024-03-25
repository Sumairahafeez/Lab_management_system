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

namespace Assignment.CourseLO
{
    public partial class ADDCLO : Form
    {
        public ADDCLO()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime createdDate = dateTimePicker1.Value;
            DateTime updatedDate = dateTimePicker2.Value;
            //string URL_of_connection = "Data Source=DESKTOP-8GUTOUI\\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(CRUDQueries.connectionString);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string Query = "Insert into Clo values(@Name,@DateCreated,@DateUpdated)";
            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            cmd.Parameters.AddWithValue("@Name", richTextBox2.Text);
            cmd.Parameters.AddWithValue("@DateCreated",createdDate.ToString());
            cmd.Parameters.AddWithValue("@DateUpdated",updatedDate.ToString());
            try
            {
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("CLO Added Sucessfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlConnection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainCLO mainCLO = new MainCLO();
            mainCLO.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DELETECLO delCLO = new DELETECLO();   
            delCLO.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=DESKTOP-8GUTOUI\\SQLEXPRESS01;Database=master;trusted_connection=true";
            string query = "SELECT * From Clo";
            try
            {
                DataTable db1 = new DataTable();
                using (SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(db1);
                    dataGridView1.DataSource = db1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UPDATECLO uPDATECLO = new UPDATECLO();
            uPDATECLO.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            VIEWCLO viewCLO = new VIEWCLO();    
            viewCLO.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
