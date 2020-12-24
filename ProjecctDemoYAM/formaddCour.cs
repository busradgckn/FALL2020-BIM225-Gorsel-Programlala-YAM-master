using ProjecctDemoYAM.Models;
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
    public partial class formaddCour : Form
    {
        public formaddCour()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                lblMessage.ForeColor = Color.Black;

                string name = tbName.Text.Trim();
                int credit = (int)nupCredit.Value;
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception("Course name is empty.");
                }
                if (credit < 0 && credit > 6)
                {
                    throw new Exception("Invalid Course credit.");
                }

                Course obj = new Course(0, name, credit);
                var result = obj.CourseAdd(obj);
                if (result > 0)
                {
                    lblMessage.Text = "Course Added.";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "Course was NOT Added.";
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}
