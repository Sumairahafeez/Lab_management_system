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

namespace Assignment.Rubrics
{
    public partial class MainRubrics : Form
    {
        public MainRubrics()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            string query = "SELECT * FROM Rubric";
            DataTable db1 = new DataTable();
            db1 = CRUDQueries.ShowDataInTables(query);
            dataGridView1.DataSource = db1;
            
            chart1.DataSource = db1;
            chart1.Series.Clear();
            Series series = chart1.Series.Add("Rubrics");
            series.XValueMember = "Id";
            series.YValueMembers = "CloId";
            series.ChartType = SeriesChartType.Column;
            chart1.Titles.Add("Rubrics");
            chart1.ChartAreas[0].AxisX.Title = "Id";
            chart1.ChartAreas[0].AxisY.Title = "CloId";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowAddRubrics(this);
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
           CRUDQueries.ShowLandingPage(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowUpdateRubrics(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowDeleteRubrics(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowViewRubrics(this);
        }
    }
}
