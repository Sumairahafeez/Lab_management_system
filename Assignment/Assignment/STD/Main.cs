using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment.STD
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ADD aDD = new ADD();
            aDD.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DELETE del = new DELETE();
            del.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UPDATE update = new UPDATE();
            update.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VIEW vIEW = new VIEW();
            vIEW.Show();
        }
    }
}
