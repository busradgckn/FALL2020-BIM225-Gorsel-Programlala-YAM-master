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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count>0)
            {
               tbID.Text =  listView1.SelectedItems[0].SubItems[0].Text;
               tbName.Text = listView1.SelectedItems[0].SubItems[1].Text;
               tbAddress.Text = listView1.SelectedItems[0].SubItems[2].Text;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.SelectedItems[0].SubItems[1].Text = tbName.Text;
            listView1.SelectedItems[0].SubItems[2].Text = tbAddress.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] s1 = new string[] {"1","Ali Hamza","Zaim University." };
            string[] s2 = new string[] { "2", "Husayn", "Zaim University." };
            string[] s3 = new string[] { "3", "Anila Bolani", "Zaim University." };
            string[] s4 = new string[] { "4", "Nooren Aslam", "Zaim University." };
            string[] s5 = new string[] { "5", "Karim Tahir", "Zaim University." };

            //ListViewItem viewItem1 = new ListViewItem(s1);
            listView1.Items.Add(new ListViewItem(s1));
            listView1.Items.Add(new ListViewItem(s2));
            listView1.Items.Add(new ListViewItem(s3));
            listView1.Items.Add(new ListViewItem(s4));
            listView1.Items.Add(new ListViewItem(s5));

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // \n  \t \\
            // Escape Sequence Kacisis dizisi
            //string path = @"F:\AJ Data\img\ambulance2.jpg";
            //Bitmap img = new Bitmap(path);
            //pictureBox1.Image = img;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.jpg,*.png,*.bim)|*.jpg;*.png;*.bim";
           var result =  dialog.ShowDialog();
            if (result==DialogResult.OK)
            {
                Bitmap img = new Bitmap(dialog.FileName);
                pictureBox1.Image = img;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value>0)
            {
                progressBar1.Value -= 1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value < 10)
            {
                progressBar1.Value += 1;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label7.Text = trackBar1.Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(richTextBox1.Text);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            label8.Text = treeView1.SelectedNode.Text;
        }
    }
}
