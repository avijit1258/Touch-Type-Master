using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace OurProject
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        String content;
        String[] st = new String[12];
        char[] ara = { '\t' };


        public Form2()
        {
            InitializeComponent();
            dataGridView1.RowCount = 12;
            //dataGridView1.Rows[0].Cells[1].Value = "Avijit";
            //dataGridView1.Rows[1].Cells[1].Value = "Avijit";
            loadText("record.txt");
            for (int i = 0; i < st.Length; i++)
            {
                
                //s[0] = "adjs";
                //s[1] = "ddwf";
                //s[2] = "3dfei";
                //s[3] = "euhe";
                //String[] s  = st[i].Split(ara);
                try
                {
                    String[] s = st[i].Split(ara);
                    dataGridView1.Rows[i].Cells[0].Value = s[0];
                    dataGridView1.Rows[i].Cells[1].Value = s[1];
                    dataGridView1.Rows[i].Cells[2].Value = s[2];
                    dataGridView1.Rows[i].Cells[3].Value = s[3];
                }
                catch (Exception e)
                {
                }
               

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           //richTextBox1.Text= loadText("record.txt");
        }

        private void loadText(String filename)
        {
            FileStream fs;
            StreamReader fr;
            int i = 0;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                fr = new StreamReader(fs);
                while(!fr.EndOfStream)
                {
                    //content = fr.ReadToEnd();
                    st[i++] = fr.ReadLine();
                }
                i = 0;
                    
                fs.Close();
            }
            catch (Exception e)
            {

            }

            //return content;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

    }
}
