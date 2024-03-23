using Assignment.CourseLO;
using Assignment.Global_Function;
using Assignment.Rubrics;
using Assignment.STD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           CRUDQueries.ShowAssessmentMainPage(this);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CRUDQueries.ShowMainRubrics(this);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainSTD mainSTD = new MainSTD();
            mainSTD.ShowDialog();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CRUDQueries.ShowMainRubricsLevel(this);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainCLO mainCLO = new MainCLO();
            mainCLO.ShowDialog();
        }
    }
}
