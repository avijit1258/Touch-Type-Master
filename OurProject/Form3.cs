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
    public partial class Form3 : MetroFramework.Forms.MetroForm


    {
        public Form3()
        {
            InitializeComponent();
            //this.ControlBox = false;
            //this.AutoScrollPosition = new Point(0, 0);
            //panel1.VerticalScroll.Value = 0;
            //firstElement.select();
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fi = new Form1();
            fi.Show();
            this.Hide();
        }
    }
}
