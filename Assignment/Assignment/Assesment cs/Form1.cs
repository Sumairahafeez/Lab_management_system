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
using System.Windows.Forms.DataVisualization.Charting;

namespace Assignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddAssignment addAssignment = new AddAssignment();
            addAssignment.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateAssignment updateAssignment = new UpdateAssignment();
            updateAssignment.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {   this.Hide();
            DeleteAssignment deleteAssignment = new DeleteAssignment();
            deleteAssignment.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAssesment viewAssesment = new ViewAssesment();
            viewAssesment.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
           
            string query = "SELECT * FROM Assessment";
            /*DataTable d1 = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                
                adapter.Fill(d1);
                dataGridView1.DataSource = d1;   

            }*/
            DataTable d1 = new DataTable();
            d1 = CRUDQueries.ShowDataInTables(query);
            dataGridView1.DataSource = d1;
            
            
            chart1.DataSource = d1;
            chart1.Series.Clear();
            Series series = chart1.Series.Add("Assessments");
            series.XValueMember = "TotalMarks";
            series.YValueMembers = "TotalWeightage";
            series.ChartType = SeriesChartType.Column;
            chart1.Titles.Add("TotalMarks vs TotalWeightage");
            chart1.ChartAreas[0].AxisX.Title = "Total Marks";
            chart1.ChartAreas[0].AxisY.Title = "Total Weightage";
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LandingPage land = new LandingPage();
            land.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            AssessmentCommponents assessmentCommponents = new AssessmentCommponents();
            assessmentCommponents.Show();
        }
    }
}
