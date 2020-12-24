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
namespace ProjecctDemoYAM
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateEmail(string email)
        {
            try
            {
                var emailAddress = new System.Net.Mail.MailAddress(email);
                return emailAddress.Address == email;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                lblMessage.Text = "";
                lblMessage.ForeColor = Color.Black;


                string email = tbEmail.Text.Trim();
                string password = tbPassword.Text.Trim();

                if (string.IsNullOrWhiteSpace(email))
                {
                    lblMessage.Text = "Enter email address";
                    tbEmail.Focus();
                    lblMessage.ForeColor = Color.Red;
                    return;
                }

                if (!ValidateEmail(email))
                {
                    lblMessage.Text = "Email formate is incorrect";
                    tbEmail.Focus();
                    lblMessage.ForeColor = Color.Red;
                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    lblMessage.Text = "Enter password address";
                    tbPassword.Focus();
                    lblMessage.ForeColor = Color.Red;
                    return;
                }

                Employee emp = new Employee();
                var employee = emp.Login(email, password);
                if (employee != null)
                {
                    formEmpHome home = new formEmpHome(employee);
                    home.WindowState = FormWindowState.Maximized;
                    this.Hide();
                    home.ShowDialog();

                    this.Show();
                }
                else
                {
                    lblMessage.Text = "Email or Password is incorrect.";
                    lblMessage.ForeColor = Color.Red;
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            tbEmail.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
