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

namespace Assignment.Class_Attendence
{
    public partial class classAttendence : Form
    {
        public classAttendence()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO ClassAttendance VALUES(@Date)";
            try
            {
                using(SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Parse(dateTimePicker1.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Date Added Succesfully");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void classAttendence_Load(object sender, EventArgs e)
        {
            try
            {
                string query1 = "SELECT RegistrationNumber FROM Student";
                DataTable dt1 = new DataTable();
                dt1 = CRUDQueries.ShowDataInTables(query1);
                comboBox1.DataSource = dt1;
                comboBox1.DisplayMember = "RegistrationNumber";
                string query2 = "SELECT Name FROM Lookup WHERE Category = 'ATTENDANCE_STATUS'";
                DataTable dt2 = new DataTable();
                dt2 = CRUDQueries.ShowDataInTables(query2);
                comboBox2.DataSource = dt2;
                comboBox2.DisplayMember = "Name";
                string query3 = "SELECT * FROM ClassAttendance";
                DataTable dt3 = new DataTable();
                dt3 = CRUDQueries.ShowDataInTables(query3);
                dataGridView1.DataSource = dt3;
                string query4 = "SELECT Id FROM ClassAttendance";
                DataTable dt4 = new DataTable();
                dt4 = CRUDQueries.ShowDataInTables(query4);
                comboBox3.DataSource = dt4;
                comboBox3.DisplayMember = "Id";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO StudentAttendance VALUES(@AttendanceId,@StudentId,@Status)";
            try
            {
                using(SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    DateTime date = dateTimePicker1.Value;
                    int AttendanceId = GetAttendanceId(date);
                    string regNO = comboBox1.Text;
                    int StudentId = GetStudentId(regNO);
                    string status = comboBox2.Text;
                    int statusId = GetStatus(status);
                    cmd.Parameters.AddWithValue("@AttendanceId", AttendanceId);
                    cmd.Parameters.AddWithValue("@StudentId", StudentId);
                    cmd.Parameters.AddWithValue("@Status", statusId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attendance Added Successfully");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public static int GetAttendanceId(DateTime date)
        {
            string query = string.Format("SELECT Id From ClassAttendance WHERE AttendanceDate = {0}", date);
            int id = 0;
            try
            {
                using(SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        id = Convert.ToInt32(reader["Id"]);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return id;
        }
        public static int GetStudentId(string registrationNO)
        {
            string query = String.Format("SELECT ID FROM Student WHERE RegistrationNumber = '{0}'",registrationNO);
            int Id=0;
            try
            {
                using (SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       Id  = Convert.ToInt32(reader["ID"]);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Id;

        }
        public static int GetStatus(string status)
        {
            string query = String.Format("SELECT LookupId FROM Lookup Where Name = '{0}'" , status);
            int Id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Id = Convert.ToInt32(reader["LookupId"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Id;
        }
    }
}
