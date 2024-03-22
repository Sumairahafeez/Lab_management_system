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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Assignment.STD
{
    public partial class ADD : Form
    {
        public ADD()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           // string URL_of_connection = "Data Source=DESKTOP-8GUTOUI\\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(CRUDQueries.connectionString);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string Query = "Insert into Student values(@FirstName,@LastName,@Contact,@Email,@RegistrationNumber,@Status)";
            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            cmd.Parameters.AddWithValue("@FirstName", textBox16.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox1.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
            cmd.Parameters.AddWithValue("@Email", textBox10.Text);
            cmd.Parameters.AddWithValue("@RegistrationNumber", textBox11.Text);
            int status = 0;
            if (comboBox1.Text == "Present")
            {
                status = 1;
            }
            if (comboBox1.Text == "Absent")
            {
                status = 2;
            }
            if (comboBox1.Text == "Leave")
            {
                status = 3;
            }
            if (comboBox1.Text == "Late")
            {
                status = 4;
            }
            if (comboBox1.Text == "Active")
            {
                status = 5;
            }
            if (comboBox1.Text == "Inactive")
            {
                status = 6;
            }
            cmd.Parameters.AddWithValue("@Status", status);
            try
            {
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Student Added Sucessfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlConnection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DELETE dELETE=new DELETE();
            dELETE.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainSTD mainSTD = new MainSTD();
            mainSTD.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UPDATE uPDATE = new UPDATE();
            uPDATE.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            VIEW view = new VIEW();
            view.Show();
        }
    }
}
