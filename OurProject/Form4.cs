using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OurProject
{
    public partial class Form4 : Form
    {
        public static string tb;
        public Form4()
        {
            InitializeComponent();
            //this.ControlBox = false;
            this.FormClosing += new FormClosingEventHandler(Form4_FormClosing);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //tb = textBox1.Text;
            this.Hide();
            Form1 f4 = new Form1();
            f4.username = textBox1.Text;
            tb = textBox1.Text;
            f4.Show();
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
