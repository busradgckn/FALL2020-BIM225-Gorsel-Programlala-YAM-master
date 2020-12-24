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
    public partial class Form1 : Form
    {
        // default constructor (parameter yoksa)
        // constructor has not return type
        // construtor has same name as class
        public  Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Welcome Yazlim Muhemdisler!");
            //tbEmail.Text = "Welcome Yazlim Muhemdisler!";
            //tbEmail.ForeColor = Color.DarkGreen;
            // C# is case-sensitive t T



            lblMessage.Text = "";

            string email = tbEmail.Text.Trim();
            string password = tbPassword.Text.Trim();

            // trim() son ve il bos character silecek
            if (string.IsNullOrEmpty( email))
            {
                lblMessage.Text = "Please enter your email.";
                lblMessage.ForeColor = Color.Red;
                tbEmail.Focus();
                return;
            }
            //""
            if (string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter your password.";
                lblMessage.ForeColor = Color.Red;
                tbPassword.Focus();// imlaç 
                return;
            }

            if (email=="admin" && password=="123")
            {
                //new: object creation
                FormHome form = new FormHome();
                form.ShowDialog();
                // concatination (Birliştirme) + 
                //lblMessage.Text = "Hoşgeldin," +email ;
                //lblMessage.ForeColor = Color.Green;
                //if (cbRemember.Checked==true)
                //{
                //    lblMessage.Text = "Hoşgeldin," + email + "(Remembered).";
                //}
            }
            else
            {
                lblMessage.Text = "Incorrect Email or password";
                lblMessage.ForeColor = Color.Red;
            }



            //if(email=="" || password=="")
            //{
            //    lblMessage.Text = "Please enter your email/password.";
            //    lblMessage.ForeColor = Color.Red;
            //}

            //ctrl + K + C
            //ctrl + K + U
            //if (email == "")
            //{
            //    lblMessage.Text = "Please enter your email.";
            //    lblMessage.ForeColor = Color.Red;
            //}
            //else
            //{
            //    if (password == "")
            //    {
            //        lblMessage.Text = "Please enter your password.";
            //        lblMessage.ForeColor = Color.Red;
            //    }
            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbEmail.Text = "";
            tbPassword.Text = "";
            lblMessage.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbEmail.Text = "";
            tbPassword.Text = "";
            lblMessage.Text = "";
        }
    }
}
