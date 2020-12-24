using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjecctDemoYAM.dept;
using ProjecctDemoYAM.Models;

namespace ProjecctDemoYAM
{
    public partial class formEmpHome : Form
    {
        Person person = null;
        int ID = -1;
        public formEmpHome(Person p)
        {
            InitializeComponent();

            person = p;
        }

        private void formEmpHome_Load(object sender, EventArgs e)
        {
            try
            {
                if (person!=null)
                {
                    lblWelcome.Text = "Welcome, " + person.FirstName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
              var result =  MessageBox.Show("Are you sure your wan to close application?",
                  "System Message",MessageBoxButtons.YesNo);
                if (result==DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();
                dgvData.DataSource= emp.GetAllEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                UpdateBorders(((Button)sender).Name);
            }
            catch (Exception ex)
            {

            }
        }

        private void UpdateBorders(string name)
        {
            try
            {
                foreach (var control in splitContainer1.Panel1.Controls)
                {

                    if (control is Button)
                    {
                        var btn = (Button)control;
                        if (btn.Name == name)
                        {
                            // btn.FlatAppearance.BorderColor = Color.Yellow;
                            btn.BackColor = Color.DarkViolet;
                        }
                        else
                        {
                            btn.BackColor = Color.MidnightBlue;

                            //btn.FlatAppearance.BorderColor = Color.RoyalBlue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnManageEmployye_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBorders(((Button)sender).Name);
            }
            catch (Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBorders(((Button)sender).Name);
            }
            catch (Exception ex)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBorders(((Button)sender).Name);
            }
            catch (Exception ex)
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBorders(((Button)sender).Name);

                formdeptHome form = new formdeptHome();
                form.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBorders(((Button)sender).Name);
            }
            catch (Exception ex)
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBorders(((Button)sender).Name);
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Employee Details";
                Employee emp = new Employee();
                dgvData.DataSource = emp.GetAllEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Student Details";
                Student obj = new Student();
                dgvData.DataSource = obj.GetAllStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Course Details";
                Course obj = new Course();
                dgvData.DataSource = obj.GetAllCourse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Department Details";
                Department obj = new Department();
                dgvData.DataSource = obj.GetAllDeparments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvData_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dgvData.ClearSelection();
                if (e.RowIndex!=-1 && e.ColumnIndex!=-1)
                {
                    if (e.Button==MouseButtons.Right)
                    {
                        dgvData.Rows[e.RowIndex].Selected = true;

                        ID = int.Parse(dgvData.Rows[e.RowIndex].Cells[0].Value.ToString());
                        var relativePositivtion = dgvData.PointToClient(Cursor.Position);
                        contextMenuStrip1.Show(dgvData, relativePositivtion);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID==-1)
                {
                    return;
                }

                if (lblTitle.Text.ToLower().Contains("course"))
                {
                    formEditDepartment form = new formEditDepartment(ID);
                    form.ShowDialog();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID == -1)
                {
                    return;
                }

                if (lblTitle.Text.ToLower().Contains("course"))
                {
                   var dresult =  MessageBox.Show("Are you sure?","System Message",MessageBoxButtons.YesNo);

                    if (dresult==DialogResult.Yes)
                    {
                        Course obj = new Course();
                        var result =  obj.CourseDelete(ID);
                        if (result>0)
                        {
                            MessageBox.Show("Course Deleted.");

                            dgvData.DataSource = obj.GetAllCourse();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                formaddCour form = new formaddCour();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
