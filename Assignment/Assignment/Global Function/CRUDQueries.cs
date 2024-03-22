using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.CompilerServices;
using Assignment.Assesment_cs;

namespace Assignment.Global_Function
{
    internal class CRUDQueries
    {
        public static string connectionString = "server= localhost\\SQLEXPRESS01; database= ProjectB; trusted_connection= true";
        public static DataTable ShowDataInTables(string query)
        {
            DataTable db1 = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(db1);
                return db1;

            }
        }
        public static void ShowLandingPage(Form CallingPage)
        {
            CallingPage.Hide();
            LandingPage lp = new LandingPage();
            lp.Show();
        }
        public static void ShowAssessmentMainPage(Form CallingPage)
        {
            CallingPage.Hide();
            Form1 form = new Form1();
            form.Show();
        }
        public static void ShowDeleteAssignment(Form CallingPage)
        {
            CallingPage.Hide();
            DeleteAssignment deleteAssignment = new DeleteAssignment();
            deleteAssignment.Show();
        }
        public static void ShowViewAssignment(Form CallingPage)
        {
            CallingPage.Hide();
            ViewAssesment viewAssesment = new ViewAssesment();
            viewAssesment.Show();
        }
        public static void ShowUpdateAssignment(Form CallingPage)
        {
            CallingPage.Hide();
            UpdateAssignment updateAssignment = new UpdateAssignment(); 
            updateAssignment.Show();
        }
        public static void ShowAddAssignment(Form CallingPage)
        {
            CallingPage.Hide();
            AddAssessment addAssessment = new AddAssessment();
            addAssessment.Show();
        }
        public static void ShowAssCompMainPage(Form CallingPage)
        {
            CallingPage.Hide();
            AssessmentCommponents assessmentCommponents = new AssessmentCommponents();
            assessmentCommponents.Show();
        }
    }
}
