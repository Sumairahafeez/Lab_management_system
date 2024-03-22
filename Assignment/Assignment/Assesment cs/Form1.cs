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
           CRUDQueries.ShowAddAssignment(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowUpdateAssignment(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {   CRUDQueries.ShowDeleteAssignment(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           CRUDQueries.ShowViewAssignment(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
           
            string query = "SELECT * FROM Assessment";
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
            CRUDQueries.ShowLandingPage(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowAssCompMainPage(this);
        }
    }
}
