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

namespace Assignment.Evaluation
{
    public partial class Evaluate : Form
    {
        public Evaluate()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowLandingPage(this);
        }

        private void Evaluate_Load(object sender, EventArgs e)
        {
            using(SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
            {
                con.Open();
                string query1 = "SELECT FirstName FROM Student";
                DataTable dt1 = new DataTable();
                dt1= CRUDQueries.ShowDataInTables(query1);
                comboBox1.DataSource = dt1;
                comboBox1.DisplayMember = "FirstName";
                string query2 = "SELECT Id FROM AssessmentComponent";
                DataTable dt2 = new DataTable();
                dt2 = CRUDQueries.ShowDataInTables(query2);
                comboBox2.DataSource = dt2;
                comboBox2.DisplayMember = "Id";
                string query3 = "SELECT TotalMarks FROM AssessmentComponent";
                DataTable dt3 = new DataTable();
                dt3 = CRUDQueries.ShowDataInTables(query3);
                comboBox3.DataSource = dt3;
                comboBox3.DisplayMember = "TotalMarks";
                string query4 = "SELECT Details FROM RubricLevel";
                DataTable dt4 = new DataTable();
                dt4 = CRUDQueries.ShowDataInTables(query4);
                comboBox5.DataSource = dt4;
                comboBox5.DisplayMember = "Details";
                string query5 = "SELECT MeasurementLevel FROM RubricLevel";
                DataTable dt5 = new DataTable();
                dt5 = CRUDQueries.ShowDataInTables(query5);
                comboBox4.DataSource = dt5;
                comboBox4.DisplayMember = "MeasurementLevel";
                string query6 = "SELECT Id From RubricLevel";
                DataTable dt6 = new DataTable();
                dt6 = CRUDQueries.ShowDataInTables(query6);
                comboBox6.DataSource = dt6;
                comboBox6.DisplayMember = "Id";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float obtainMarks;
            float MaxRubricLevel;
            float ObtainRubricLevel;
            int CompMarks;
            MaxRubricLevel = 4;
            ObtainRubricLevel = float.Parse(comboBox4.Text);

            CompMarks = int.Parse((comboBox3.Text));

            obtainMarks = (ObtainRubricLevel / MaxRubricLevel) * CompMarks;
            string name = comboBox1.Text;
           
            //int id = CRUDQueries.GetStudentId(name);
            MessageBox.Show(name + " got " + obtainMarks + " marks");

            string query2 = "SELECT s.FirstName,r.Details,a.TotalMarks,a.Name,r.MeasurementLevel,(r.MeasurementLevel*CAST(a.TotalMarks as float)/4)  ObtainMarks\r\nFROM Student as s, AssessmentComponent as a, RubricLevel as r,StudentResult as sr \r\nWHERE sr.StudentId = s.Id AND sr.AssessmentComponentId=a.Id AND sr.RubricMeasurementId = r.Id";
            DataTable dt = new DataTable();
            dt = CRUDQueries.ShowDataInTables(query2);
            dataGridView1.DataSource = dt;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = comboBox1.Text;

            int id = CRUDQueries.GetStudentId(name);
            string query = "INSERT INTO StudentResult VALUES(@StudentId,@AssessmentComponentId,@RubricLevelId,@EvaluationDate)";
            using (SqlConnection con = new SqlConnection(CRUDQueries.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentId", id);
                cmd.Parameters.AddWithValue("@AssessmentComponentId", int.Parse(comboBox2.Text));
                cmd.Parameters.AddWithValue("@RubricLevelId", int.Parse(comboBox6.Text));
                cmd.Parameters.AddWithValue("@EvaluationDate", DateTime.Parse(dateTimePicker1.Text));
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
    }
}
