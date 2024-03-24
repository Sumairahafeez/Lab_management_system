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
using Assignment.AssComponents;
using Assignment.Rubrics;
using Assignment.RubricLevel;

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
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(db1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
        public static void ShowAddAssComp(Form CallingPage)
        {
            CallingPage.Hide();
            AddAssComp addAssComp = new AddAssComp();
            addAssComp.Show();
        }
        public static void ShowUpdateAssComp(Form CallingPage)
        {
            CallingPage.Hide();
            UpdateAssComp updateAssComp = new UpdateAssComp();
            updateAssComp.Show();
        }
        public static void ShowDeleteAssComp(Form CallingPage)
        {
            CallingPage.Hide();
            DeleteAssComp del = new DeleteAssComp();
            del.Show();
        }
        public static void ShowViewAssComp(Form CallingPage)
        {
            CallingPage.Hide();
            ViewAssComp viewAssComp = new ViewAssComp();
            viewAssComp.Show();
        }
        public static void ShowAddRubrics(Form CallingPage)

        {
            CallingPage.Hide();
            AddRubrics add = new AddRubrics();
            add.Show();
        }
        public static void ShowUpdateRubrics(Form CallingPage)
        {
            CallingPage.Hide();
            UpdateRubrics updateRubrics = new UpdateRubrics();
            updateRubrics.Show();
        }
        public static void ShowDeleteRubrics(Form CallingPage)
        {
            CallingPage.Hide();
            DeleteRubrics deleteRubrics = new DeleteRubrics();
            deleteRubrics.Show();
        }
        public static void ShowViewRubrics(Form CallingPage)
        {
            CallingPage.Hide();
            ViewRubrics viewRubrics = new ViewRubrics();
            viewRubrics.Show();
        }
        public static void ShowMainRubrics(Form CallingPage)
        {
            CallingPage.Hide();
            MainRubrics mainRubrics = new MainRubrics();
            mainRubrics.Show();
        }
        public static void ShowAddRubricsLevel(Form CallingPage)
        {
            CallingPage.Hide();
            AddRubricLevel add = new AddRubricLevel();
            add.Show();
        }
        public static void ShowMainRubricsLevel(Form CallingPage)
        {
            CallingPage.Hide();
            MainRubricLevel main = new MainRubricLevel();
            main.Show();
        }
        public static void ShowUpdateRubricsLevel(Form CallingPage)
        {
            CallingPage.Hide();
            UpdateRubricLevel update = new UpdateRubricLevel();
            update.Show();
        }
        public static void ShowDeleteRubricsLevel(Form CallingPage)
        {
            CallingPage.Hide();
            DeleteRubricLevel del = new DeleteRubricLevel();
            del.Show();
        }
        public static void ShowViewRubricsLevel(Form CallingPage)
        {
            CallingPage.Hide();
            ViewRubricLevel view = new ViewRubricLevel();
            view.Show();
        }
        public static int GetStudentId(string name)
        {
            int id = 0;
            string query = string.Format("SELECT Id FROM Student WHERE FirstName = '{0}'", name);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return id;
            }
        }
    }
}
