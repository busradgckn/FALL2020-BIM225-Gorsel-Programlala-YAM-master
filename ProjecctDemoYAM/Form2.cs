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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblMenu.Text = "";

            if (checkBox1.Checked)
            {
                lblMenu.Text += checkBox1.Text +  " ";
            }
            if (checkBox2.Checked)
            {
                lblMenu.Text += checkBox2.Text + " ";
            }

            if (checkBox3.Checked)
            {
                lblMenu.Text += checkBox3.Text + " ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblGender.Text = "";
            lblGender.ForeColor = Color.Black;
            if (rbFemale.Checked)
            {
                lblGender.Text = "You are Female.";
            }
            else
            {
                if (rbMale.Checked)
                {
                    lblGender.Text = "You are Male.";
                }
                else
                {
                    lblGender.Text = "Ne apiyorsun?";
                    lblGender.ForeColor = Color.Red;
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblGroup.Text = "";

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    lblGroup.Text += checkedListBox1.Items[i].ToString() + ",";
                }
            }
            if (lblGroup.Text!=null)
            {
                //lblGroup.Text =  lblGroup.Text.Reverse().ToString()
                //    .Replace(',', '.').Reverse().ToString();
                lblGroup.Text = lblGroup.Text.Substring(0, lblGroup.Text.Length - 1);
                lblGroup.Text += ".";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //  label3.Text = dateTimePicker1.Value.ToShortDateString();
            //label3.Text = dateTimePicker1.Value.ToLongDateString();
            //label3.Text = dateTimePicker1.Value.ToShortTimeString();
            label3.Text = dateTimePicker1.Value.ToLongTimeString();



        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0)
            {
                //label4.Text = "Male";
                label4.Text = comboBox1.SelectedItem.ToString();
            }
            else
            {
                if (comboBox1.SelectedIndex==1)
                {
                    //label4.Text = "Female";
                    label4.Text = comboBox1.SelectedItem.ToString();

                }
                else
                {
                    label4.Text = "Please select Gender.";
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count>0)
            {
                foreach (var item in listBox1.SelectedItems)
                {
                    listBox2.Items.Add(item);
                }

                while (listBox1.SelectedItems.Count>0)
                {
                    listBox1.Items.Remove(listBox1.SelectedItems[0]);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count>0)
            {
                listBox2.Items.AddRange(listBox1.Items);
                listBox1.Items.Clear();
            }
        }
    }
}
