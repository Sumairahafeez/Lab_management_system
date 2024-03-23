using Assignment.Global_Function;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Assignment.RubricLevel
{
    public partial class MainRubricLevel : Form
    {
        public MainRubricLevel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowAddRubricsLevel(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowUpdateRubricsLevel(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowDeleteRubricsLevel(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowViewRubricsLevel(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowLandingPage(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM RubricLevel";
            DataTable db1 = new DataTable();
            db1 = CRUDQueries.ShowDataInTables(query);
            try
            {
                dataGridView1.DataSource = db1;
            }
           catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            chart1.DataSource = db1;
            chart1.Series.Clear();
            Series series = chart1.Series.Add("Rubrics Level");
            series.XValueMember = "RubricId";
            series.YValueMembers = "MeasurementLevel";
            series.ChartType = SeriesChartType.Column;
            chart1.Titles.Add("Rubrics Level");
            chart1.ChartAreas[0].AxisX.Title = "RubricId";
            chart1.ChartAreas[0].AxisY.Title = "MeasurementLevel";
        }
    }
}
