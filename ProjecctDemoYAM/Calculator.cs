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
    public partial class Calculator : Form
    {
        double num1 = 0;
        char op = ' ';

        public Calculator()
        {
            InitializeComponent();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //tbMain.Text = tbMain.Text +  "0";
            tbMain.Text += "0";

            //string str = tbMain.Text;
            //if (str.Length>1 && str[1]!=',' )
            //{
            //    tbMain.Text = "";
            //}else
            //{ 
            //tbMain.Text += "0";
            //}
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tbMain.Text += "1";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tbMain.Text += "2";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tbMain.Text += "3";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            tbMain.Text += "4";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            tbMain.Text += "5";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            tbMain.Text += "6";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbMain.Text += "7";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbMain.Text += "8";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbMain.Text += "9";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (tbMain.Text=="")
            {
                tbMain.Text = "0,";
            }
            if (!tbMain.Text.Contains(","))
            {
                tbMain.Text += ",";
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tbMain.Text = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string str = tbMain.Text;

            if (str.Length>0)
            {
                tbMain.Text = str.Substring(0, str.Length - 1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            op = '+';
            // casting: string -> double
            num1 = double.Parse(tbMain.Text);
            tbMain.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            op = '-';
            num1 = double.Parse(tbMain.Text);
            tbMain.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            op = '/';
            num1 = double.Parse(tbMain.Text);
            tbMain.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            op = 'x';
            num1 = double.Parse(tbMain.Text);
            tbMain.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (op==' ')
            {
                return;
            }

            if (tbMain.Text=="")
            {
                MessageBox.Show("Enter a number.");
                return;
            }

            double num2 = double.Parse(tbMain.Text);

            switch (op)
            {
                case '+':
                    tbMain.Text= (num1 + num2).ToString();
                    break;
                case '-':
                    tbMain.Text = (num1 - num2).ToString();
                    break;
                case '/':
                    if (num2==0)
                    {
                        MessageBox.Show("Error: Canot divide by Zero.");
                        tbMain.Text = "";
                    }
                    else
                    {
                        tbMain.Text = (num1 / num2).ToString();
                    }
                    break;
                case 'x':
                    tbMain.Text = (num1 * num2).ToString();
                    break;
                case 'n':

                    int r = CalFactorial(int.Parse(tbMain.Text));
                    if (r==-1)
                    {
                        MessageBox.Show("Number cannot be negative.");
                    }
                    else
                    {
                        tbMain.Text = r.ToString();
                    }
                    break;

                default:
                    break;
            }

            num1 = 0;
            op = ' ';
        }

        private int CalFactorial(int n)
        {
            if (n<0)
            {
                return -1;
            }
            else
            {
                if (n<=1)
                {
                    return 1;
                }
                else
                {
                    int result = 1;
                    for (int i = n; i >1; i--)
                    {
                        //result = result * i;
                        result *=  i;

                    }
                    return result;
                }
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            op = 'n';
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (tbMain.Text=="")
            {
                return;
            }

            int num = int.Parse(tbMain.Text)*-1;
            tbMain.Text = num.ToString();

        }
    }
}
