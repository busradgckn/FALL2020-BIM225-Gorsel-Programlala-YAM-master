using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjecctDemoYAM.Models;

namespace ProjecctDemoYAM.dept
{
    public partial class ucCourseHome : UserControl
    {
        public ucCourseHome()
        {
            InitializeComponent();
        }

        private void ucCourseHome_Load(object sender, EventArgs e)
        {
            try
            {
                Student std = new Student();
                lblStudentCount.Text =  std.GetAllStudentCount().ToString();

                Course c = new Course();
                lblCourseCount.Text = c.GetAllCourseCount().ToString();

                lblEmployeeCount.Text = Employee.GetAllEmployeeCount().ToString();
                lblDepartmentCount.Text = Department.GetAllDepartmentCount().ToString();


                dgvCourse.DataSource = c.GetCourseN(10);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
