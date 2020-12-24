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
    public partial class formEditDepartment : Form
    {
        int courseID = -1;
        public formEditDepartment(int cID)
        {
            InitializeComponent();
            courseID = cID;
        }

        private void formEditDepartment_Load(object sender, EventArgs e)
        {
            try
            {
                Course obj = new Course();
                var course =  obj.GetCourseByID(courseID);

                tbCourseID.Text = course.CourseID.ToString();
                tbName.Text = course.Name;
                nupCredit.Value = course.Credit;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if (credit<0 && credit>6)
                {
                    throw new Exception("Invalid Course credit.");
                }

                Course obj = new Course(courseID, name, credit);
                var result =obj.CourseUpdate(obj);
                if (result>0)
                {
                    lblMessage.Text = "Course Updated.";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "Course was NOT Updated.";
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
