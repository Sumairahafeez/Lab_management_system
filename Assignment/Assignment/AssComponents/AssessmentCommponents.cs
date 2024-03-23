using Assignment.AssComponents;
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

namespace Assignment.Assesment_cs
{
    public partial class AssessmentCommponents : Form
    {
        public AssessmentCommponents()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowAssessmentMainPage(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Assessment";
            DataTable dataTable = new DataTable();
            dataTable = CRUDQueries.ShowDataInTables(query);
            try
            {
                dataGridView1.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string query2 = "SELECT * FROM Rubric";
            DataTable dataTable2 = new DataTable();
            dataTable2 = CRUDQueries.ShowDataInTables(query2);
            try
            {
                dataGridView2.DataSource = dataTable2;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowAddAssComp(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowUpdateAssComp(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowDeleteAssComp(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CRUDQueries.ShowViewAssComp(this);
        }
    }
}
