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
using System.Data.OleDb;
namespace OurProject
{
    public partial class Progress : MetroFramework.Forms.MetroForm
    {
       // String content;
        String[] st = new String[12];
        char[] ara = { '\t' };
        private OleDbConnection connection = new OleDbConnection();

        public Progress()
        {
            InitializeComponent();
            this.ControlBox = false;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= record.accdb;
            Persist Security Info=False;";
            putdataDV();

            /*dataGridView1.RowCount = 20;
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
               

            }*/
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void putdataDV()
        {
            try
            {
                //OleDbConnection connection = new OleDbConnection();
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from typingInfo";
                //command.CommandText = "insert into typingData (user, mobile, sex, email) values(' " + textBox1.Text + " ',' " + textBox2.Text + " ',' " + textBox3.Text + " ',' " + textBox4.Text + " ')";
                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView1.DataSource = dt;

                //command.ExecuteNonQuery();
                //MessageBox.Show("Data saved");
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand ac = new OleDbCommand("delete from typingInfo", connection);
                ac.ExecuteNonQuery();
                
                connection.Close();
                putdataDV();
            }
            catch(Exception ex)
            {
            }
        }

    }
}
