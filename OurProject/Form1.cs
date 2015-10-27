using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;



namespace OurProject
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private int next = -1;
        private int correct = 0;
        private float incorrect = 0;
        private string content = "";
        private float timeLeft = 0;
        private float min = 0;
        private float accuracy;
        private float netwpm;
        private float grosswpm;
        private int Minute = 0;
        private int Seconds = 0;
        private SoundPlayer sp = new SoundPlayer("shoot.wav");
        private Button t;
        public Form1()
        {
            InitializeComponent();
           
            
           this.Controls.Add(richTextBox1);
            richTextBox1.KeyPress += new KeyPressEventHandler(richTextBox1_KeyPress);
            
            //richTextBox1.BringToFront();
            
        }

        private String loadText(String filename)
        {
            FileStream fs;
            StreamReader fr;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                fr = new StreamReader(fs);
                content = fr.ReadToEnd();
                fs.Close();
            }
            catch (Exception e)
            {
                
            }

            return content;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = loadText("coding.txt");
            //this.ActiveControl = richTextBox1;
            //richTextBox1.Focus();
           // richTextBox1.Select();
           
            
        }
        private void resetText()
        {
            try
            {
                netwpm = 0;
                grosswpm = 0;
                accuracy = 0;
                incorrect = 0;
                next = -1;
                timeLeft = 0;
                timer1.Stop();
                t.BackColor = Color.WhiteSmoke;
                label5.Text = "GrossWPM : ";
                label6.Text = "Accuracy : ";
                label1.Text = "Errors : ";
                label2.Text = "NetWPM : ";
                label3.Text = "Time : " ;
                richTextBox1.Clear();
            }catch(Exception e)
            {

            }
        
        }   

        private void button82_Click(object sender, EventArgs e)
        {
           
        }
          
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           // e.Handled = false;
            //richTextBox1.Focus();

            char key = e.KeyChar;
            char[] c = richTextBox1.Text.ToCharArray();
            next++;
            if (next == 0)
            {
                timer1.Start();
            }
                
            
            //here we check number and chars and considering this colour char and button
            for (int i = 0; i < this.panel1.Controls.Count; i++)
            {
                if (this.panel1.Controls[i].Name.Substring(0, 4).ToLower().CompareTo("btn" + key.ToString().ToLower()) == 0 && this.panel1.Controls[i].Name.Length <= 4)
                    textAndButtonColour((Button)this.panel1.Controls[i], c, next, key);

            }

            //for checking  symbols                                                                                     

            if ((int)key == 33) textAndButtonColour(btn1, c, next, key);
            if ((int)key == 64) textAndButtonColour(btn2, c, next, key);
            if ((int)key == 35) textAndButtonColour(btn3, c, next, key);
            if ((int)key == 36) textAndButtonColour(btn4, c, next, key);
            if ((int)key == 37) textAndButtonColour(btn5, c, next, key);
            if ((int)key == 94) textAndButtonColour(btn6, c, next, key);
            if ((int)key == 38) textAndButtonColour(btn7, c, next, key);
            if ((int)key == 42) textAndButtonColour(btn8, c, next, key);
            if ((int)key == 40) textAndButtonColour(btn9, c, next, key);
            if ((int)key == 41) textAndButtonColour(btn0, c, next, key);


            

            if ((int)key == 123 || (int)key == 91) textAndButtonColour(btnopenbrace, c, next, key);
            if ((int)key == 125 || (int)key == 93) textAndButtonColour(btnclosebrace, c, next, key);
            if ((int)key == 58 || (int)key == 59) textAndButtonColour(btnsemi, c, next, key);
            if ((int)key == 34 || (int)key == 39) textAndButtonColour(btndouble, c, next, key);
            if ((int)key == 60 || (int)key == 44) textAndButtonColour(btncomma, c, next, key);
            if ((int)key == 62 || (int)key == 46) textAndButtonColour(btndot, c, next, key);
            if ((int)key == 63 || (int)key == 47) textAndButtonColour(btnbackslash, c, next, key);
            if ((int)key == 124 || (int)key == 92) textAndButtonColour(btnforwardslash, c, next, key);
            if ((int)key == 95 || (int)key == 45) textAndButtonColour(btnminus, c, next, key);
            if ((int)key == 43 || (int)key == 61) textAndButtonColour(btnequals, c, next, key);

            //check spacebar and enter keys
            if ((int)key == 32) textAndButtonColour(btnspacebar, c, next, key);
            if ((int)key == 13) textAndButtonColour(btnenter, c, next, key);

            //e.Handled = true;

            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                next--;
            }

            //stop timer when the number of keypesses equal to the number of letters displayed in the box
            if (c.Length == next + 1)
            {
                
                timer1.Stop();
                
                //richTextBox1.Text = loadText(fileName);
                //richTextBox1.SelectionStart = 0;
                //richTextBox1.SelectionLength = next;
                //richTextBox1.SelectionColor = Color.Black;
                //richTextBox1.SelectionBackColor = Color.White;
                
                //charCorrect.Text = correct.ToString();
                //charIncorrect.Text = incorrect.ToString();
            }
            
            
          


            e.Handled = true;
        }
        private void textAndButtonColour(Button con, char[] c, int next, char key)
        {
            try
            {
                //con.BackColor = Color.Black;
                //t = con;
                t.BackColor = Color.WhiteSmoke;
            }
            catch (Exception ex) {
                //next = -1;
                //timer1.Start();
                //richTextBox1.Focus();
            }
            

            try
            {

                if ((int)key == (int)c[next])
                {

                   
                    con.BackColor = Color.Green;
                    t = con;
                    
                    richTextBox1.SelectionStart = next;
                    richTextBox1.SelectionLength = 1;
                    richTextBox1.SelectionColor = Color.Green;
                    nextToType(next);
                    panel2.BackgroundImage = Properties.Resources.happy;
                    correct++;
                }
                else if ((int)key == 13 && (int)c[next] == 10)
                {
                    btnenter.BackColor = Color.Green;
                    t = btnenter;
                    correct++;
                }
                else if ((int)key != (int)c[next])
                {
                    //check(key, Color.Red);
                    con.BackColor = Color.Red;
                    t = con;
                    richTextBox1.SelectionStart = next;
                    richTextBox1.SelectionLength = 1;
                    richTextBox1.SelectionColor = Color.Red;
                    incorrect++;
                    nextToType(next);
                    panel2.BackgroundImage = Properties.Resources.grimace;
                    sp.Play();
                    
                }

            }
            catch (Exception e) { }

           // result();
            

        }
        private void nextToType(int next)
        {
            richTextBox1.SelectionStart = next + 1;
            richTextBox1.SelectionLength = 1;
            richTextBox1.SelectionColor = Color.Purple;
        }

        private void result()
        {
            try
            {
                min = (float)timeLeft / 60.0f;
                grosswpm = (next / 5.0f) / min;
                netwpm = grosswpm - ((incorrect/5.0f) / min);
                accuracy = (next - incorrect) / next;
                label5.Text = "GrossWPM : " + grosswpm;
                if (netwpm < 0)
                {
                    label2.Text = "NetWPM : 00";
                }
                else
                {
                    label2.Text = "NetWPM : " + netwpm;
                }
                
                label6.Text = "Accuracy : " + (accuracy * 100);
                label1.Text = "Errors : " + incorrect;


            }
            catch (Exception e)
            {

            }
        }
        

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft += 1;
            Seconds += 1;
            if (Seconds == 59)
            {
                Seconds = 0;
                Minute++;
            }
            label3.Text = "Time : " + Minute+":"+ Seconds ;
            result();
        }
        private void reloadText(String st)
        {
            resetText();
            richTextBox1.Text = loadText(st);

            //timer1.Start();
            timer1.Interval = 1000;
        }
             

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnclosebrace_Click(object sender, EventArgs e)
        {

        }

        private void matureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void accuracyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("Accuracy.txt");

            
        }

        private void middleRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("middleRow.txt");
            
        }
        private void richTextBox1_SelectionChanged(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            richTextBox1.SelectionLength = 0;
        
        }

        private void theShowQueen1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("The Show Queen-1.txt");
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void durationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void topuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aBCDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void eFGHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("EFGH.txt");
            
        }

        private void musicToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void iLMOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("ILMO.txt");
        }

        private void aBCDToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            reloadText("inter-1.txt");
        }

        private void eFGHToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            reloadText("EFGH.txt");
        }

        private void iLMOToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            reloadText("ILMO.txt");
        }

        private void pRSTUVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("PRSTUV.txt");
        }

        private void vmbnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("v m b n.txt");
        }

        private void fjdkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("f j d k.txt");
        }

        private void slaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("s l a ;.txt");
        }

        private void ghtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("g h t y.txt");
        }

        private void rUEIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("r u e i.txt");
        }

        private void wOQPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("w o q p.txt");
        }

        private void cXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("c , x ..txt");
        }

        private void shiftKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fJDKToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("shiftF J D K.txt");
        }

        private void sLAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("shiftS L A.txt");
        }

        private void gHTYToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("shiftG H T Y.txt");
        }

        private void vMBNToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("shiftV M B N.txt");
        }

        private void rUEIToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("shiftR U E I.txt");
        }

        private void wOQPToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("shiftW O Q P.txt");
        }

        private void cXToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("shiftC X.txt");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            reloadText("5 6 4 7 3.txt");
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            reloadText("2 8 1 9 0.txt");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            reloadText("symbol-1.txt");
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            reloadText("symbol-2.txt");
        }

        private void syllablesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void basicsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zas.txt");
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zbs.txt");
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zcs.txt");
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zds.txt");
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zes.txt");
        }

        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zfs.txt");
        }

        private void gToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zgs.txt");
        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zhs.txt");
        }

        private void iToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zis.txt");
        }

        private void jToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zjs.txt");
        }

        private void kToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zks.txt");
        }

        private void lToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zls.txt");
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zms.txt");
        }

        private void nToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zns.txt");
        }

        private void oToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zos.txt");
        }

        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zps.txt");
        }

        private void qToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zqs.txt");
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zrs.txt");
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zss.txt");
        }

        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zts.txt");
        }

        private void uToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zus.txt");
        }

        private void vToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zvs.txt");
        }

        private void wToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zws.txt");
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("zxs.txt");
        }

        private void aToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zaw.txt");
        }

        private void bToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zbw.txt");
        }

        private void cToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zcw.txt");
        }

        private void dToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zdw.txt");
        }

        private void eToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zew.txt");
        }

        private void fToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zfw.txt");
        }

        private void gToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zgw.txt");
        }

        private void hToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zhw.txt");
        }

        private void iToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("ziw.txt");
        }

        private void jToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zjw.txt");
        }

        private void kToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zkw.txt");
        }

        private void lToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zlw.txt");
        }

        private void mToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zmw.txt");
        }

        private void nToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("znw.txt");
        }

        private void oToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zow.txt");
        }

        private void pToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zpw.txt");
        }

        private void qToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            reloadText("zqw.txt");
        }

        private void rToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zrw.txt");
        }

        private void sToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zsw.txt");
        }

        private void tToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("ztw.txt");
        }

        private void uToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zuw.txt");
        }

        private void vToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zvw.txt");
        }

        private void wToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zww.txt");
        }

        private void xToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reloadText("zxw.txt");
        }

        private void storyTheFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("story1st.txt");
        }

        private void storyTheSecondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("story2nd.txt");
        }

        private void storyTheThirdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("story3rd.txt");
        }

        private void storyTheFourthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("story4th.txt");
        }

        private void storyTheFifthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("story5th.txt");
        }

        private void keepCodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadText("coding.txt");
        }

        private void btnq_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
           // String data = netwpm.ToString() + accuracy.ToString();
            string pagol = ((double)netwpm).ToString("F1");
            string sagol = ((double)accuracy).ToString("F1");
            String cse = Environment.NewLine + DateTime.Now.ToString("M/d/yyyy") + "\t"+ DateTime.Now.ToString("h:mm:ss tt") + "\t"   + pagol + "\t" + sagol;
            File.AppendAllText("record.txt", cse);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
            this.Hide();
        }

        private void btnw_Click(object sender, EventArgs e)
        {

        }
        

   
    }
}
