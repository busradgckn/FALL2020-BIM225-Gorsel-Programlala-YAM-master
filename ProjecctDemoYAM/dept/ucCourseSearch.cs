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

namespace ProjecctDemoYAM.dept
{
    public partial class ucCourseSearch : UserControl
    {
        public ucCourseSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string text = tbSearch.Text.Trim();
                BindCourseDGV(text);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }
        private void BindCourseDGV(string text="")
        {
            try
            {
                ResetMessageLabel();
                
                Course obj = new Course();
                dgvCourse.Columns.Clear();
                dgvCourse.DataSource = obj.GetCourseByName(text);

                DataGridViewImageColumn btn = new DataGridViewImageColumn();
                btn.HeaderText = "Del";
                btn.Name = "btnDelete";
                btn.Image = Properties.Resources.delete_16px;
                dgvCourse.Columns.Add(btn);

                DataGridViewImageColumn btn1 = new DataGridViewImageColumn();
                btn1.HeaderText = "Edit";
                btn1.Name = "btnEdit";
                btn1.Image = Properties.Resources.edit_16px;
                dgvCourse.Columns.Add(btn1);

                DataGridViewImageColumn btn2 = new DataGridViewImageColumn();
                btn2.HeaderText = "Add";
                btn2.Name = "btnAdd";
                btn2.Image = Properties.Resources.add_16px;
                dgvCourse.Columns.Add(btn2);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        private void ResetMessageLabel()
        {
            lblMessage.Text = "";
            lblMessage.ForeColor = Color.Black;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                BindCourseDGV();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void dgvCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ResetMessageLabel();

                if (e.RowIndex==-1 || e.ColumnIndex==-1)
                {
                    return;
                }

                if (e.ColumnIndex==3)
                {
                    var mb = MessageBox.Show("Are you sure to delete course?",
                        "Course Delete Dialog",
                        MessageBoxButtons.YesNo);

                    if (mb ==DialogResult.Yes)
                    {
                        int cID = int.Parse(dgvCourse.Rows[e.RowIndex].Cells["CourseID"].Value.ToString());
                        Course obj = new Course();
                        int result = obj.CourseDelete(cID);
                        if (result>0)
                        {
                            lblMessage.Text = "Course deleted from databse.";
                            lblMessage.ForeColor = Color.Green;
                            BindCourseDGV();
                        }
                        else
                        {
                            lblMessage.Text = "Course NOT deleted.";
                            lblMessage.ForeColor = Color.Black;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text =  ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}
