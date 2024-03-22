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
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Assessment";
            DataTable dataTable = new DataTable();
            dataTable = CRUDQueries.ShowDataInTables(query);
            dataGridView1.DataSource = dataTable;
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
            AddAssComp addAssComp = new AddAssComp();
            addAssComp.Show();
        }
    }
}
