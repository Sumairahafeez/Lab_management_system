using Assignment.Global_Function;
using Assignment.STD;
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

namespace Assignment.Attendance
{
    public partial class StdAttendance : Form
    {
        public StdAttendance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainSTD mainSTD = new MainSTD();
            mainSTD.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StdAttendance_Load(object sender, EventArgs e)
        {
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
        }
    }
}
