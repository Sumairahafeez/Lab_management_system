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
    public partial class MainCLO : Form
    {
        public MainCLO()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LandingPage landingPage = new LandingPage();
            landingPage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADDCLO aDDCLO = new ADDCLO();
            aDDCLO.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DELETECLO dELETECLO = new DELETECLO();
            dELETECLO.Show();
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
           VIEWCLO vIEWCLO = new VIEWCLO();
            vIEWCLO.Show();
        }
    }
}
