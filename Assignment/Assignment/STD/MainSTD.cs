using Assignment.Attendance;
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

namespace Assignment.STD
{
    public partial class MainSTD : Form
    {
        public MainSTD()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=DESKTOP-8GUTOUI\\SQLEXPRESS01;Database=master;trusted_connection=true";
            string query = "SELECT * From Student";
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADD aDD = new ADD();
            aDD.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UPDATE uPDATE = new UPDATE();
            uPDATE.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DELETE uDE = new DELETE();
            uDE.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            VIEW uVIEW = new VIEW();
            uVIEW.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LandingPage landing = new LandingPage();
            landing.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            StdAttendance stdAttendance= new StdAttendance();
            stdAttendance.Show();
        }
    }
}
