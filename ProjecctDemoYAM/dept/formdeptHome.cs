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
    public partial class formdeptHome : Form
    {
        public formdeptHome()
        {
            InitializeComponent();
        }

        private void btnManageEmployye_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBorders(((Button)sender).Name);

                ucCourseHome uc = new ucCourseHome();
                uc.Dock = DockStyle.Fill;
                panelContent.Controls.Clear();
                panelContent.Controls.Add(uc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBorders(((Button)sender).Name);
                ucCourseSearch uc = new ucCourseSearch();
                uc.Dock = DockStyle.Fill;

                panelContent.Controls.Clear();
                panelContent.Controls.Add(uc);

            }
            catch (Exception ex)
            {

            }
        }

        private void UpdateBorders(string name)
        {
            try
            {
                foreach (var control in panelLeftMenu.Controls)
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
    }
}
