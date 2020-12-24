using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjecctDemoYAM
{
    public partial class FormHome : Form
    {
        // default constructor
        public FormHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this demek suandaki object.. FormHome
            //this.BackColor = Color.Green;
            BackColor = Color.Green;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BackColor = Color.Red;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BackColor = Color.Blue;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lblWelcome.ForeColor = Color.Green;
            if (this.BackColor==lblWelcome.ForeColor)
            {
                this.BackColor = Color.White;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            lblWelcome.ForeColor = Color.Red;
            if (this.BackColor == lblWelcome.ForeColor)
            {
                this.BackColor = Color.White;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lblWelcome.ForeColor = Color.Blue;
            if (this.BackColor == lblWelcome.ForeColor)
            {
                this.BackColor = Color.White;
            }

        }
    }
}
