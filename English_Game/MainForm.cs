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
using System.Diagnostics;



namespace English_Game
{
    public partial class Form1 : Form
    {
   
        FolderBrowserDialog pic_source = new FolderBrowserDialog();
        static string[] pictures = Directory.GetFiles("english_prog_files\\pictures\\");
        static string[] text = Directory.GetFiles("english_prog_files\\text\\");

        string[] lines;                     // used to keep all words and description
        string current_right_answer;

        Random newr = new Random();         // random object to serve randoming needs
        int actions;                        // means picture changes, increments after program receives right answer
        int wrong_answers;                  // just keeps info about amount of wrong answers, not used anywhere
        int tries;                          // increments after any button click with question variants
        int a;                              // variable for keeping random value 
        List<int> Taken = new List<int>();  // list for already taken pictures (words), serves to avoid repeats
        int max = pictures.Length;          // keeps info about amount of all words
        int right_answer = 0;               // keeps info about right answers, used in percent calculations
        

        public Form1()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;

            actions = 1;                       // set to one to mean that first shown pic is actually a first pic, not the action taken by user
            tries = 0;                         // set to 0 beacuse there were no tries yet  
            wrong_answers = 0;                 // same
            a = newr.Next(1, max+1);           // gets random picture between 1 and maximum, 1 since first pic if folder is always named 1.jpg
            Taken.Add(a);                      // adds first randomed picture to list of rolled pictures
  
            InitializeComponent(); //--------------------------                                                                                           
                                                                                                                        // all this code initilizes first picture and words, others are looped
            label2.Text = (actions).ToString() + " out of " + max.ToString();                                           // all this code initilizes first picture and words, others are looped
                                                                                                                        // all this code initilizes first picture and words, others are looped
            Reset_colors();                                                                                             // all this code initilizes first picture and words, others are looped
                                                                                                                        // all this code initilizes first picture and words, others are looped
            lines = File.ReadAllLines("english_prog_files\\text\\" + (a).ToString() + ".txt");                          // all this code initilizes first picture and words, others are looped
                                                                                                                        // all this code initilizes first picture and words, others are looped
            current_right_answer = lines[0];                                                                            // all this code initilizes first picture and words, others are looped
                                                                                                                        // all this code initilizes first picture and words, others are looped
            textBox1.Text = lines[4];                                                                                   // all this code initilizes first picture and words, others are looped
                                                                                                                        // all this code initilizes first picture and words, others are looped
            lines = Rand_and_fill();                                                                                    // all this code initilizes first picture and words, others are looped
            pictureBox1.Image = Image.FromFile("english_prog_files\\pictures\\" + a.ToString() + ".jpg");               // all this code initilizes first picture and words, others are looped
                                                                                                                        // all this code initilizes first picture and words, others are looped
            label1.Text = a.ToString() + " ";                                                                           // all this code initilizes first picture and words, others are looped
                                                                                                                        // all this code initilizes first picture and words, others are looped
            label3.Text = (((double)tries * 100) * (right_answer)).ToString();                                          // all this code initilizes first picture and words, others are looped
                                                                                                                        // all this code initilizes first picture and words, others are looped

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (actions < max)
            {
               
                while (true)
                {
                    a = newr.Next(1, max+1);
                    if (Taken.Contains(a))
                    {
                        continue;
                    }
                    else
                    {
                        Taken.Add(a); label1.Text += a.ToString() + " ";
                        
                        break;
                    }
                }

                pictureBox1.Image.Dispose();                                                                    
                pictureBox1.Image = Image.FromFile("english_prog_files\\pictures\\" + a.ToString() + ".jpg");
                
                lines = File.ReadAllLines("english_prog_files\\text\\" + (a).ToString() + ".txt");
                textBox1.Text = lines[4];

                current_right_answer = lines[0];

                lines = Rand_and_fill();

            }

            actions++;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        string [] Rand_and_fill()               // function to shuffle all variants and place them in random order, uses simple list with its 'contains' method
        {
            
            int counter = 0;
            string[] _lines = new string[5];

            //List<string> final_lines = new List<string>();
            List<int> already_in = new List<int>();
            
            Random r = new Random();

            while (true)
            {
                if (counter == 4)
                {
                    button2.Text = _lines[0];
                    button3.Text = _lines[1];
                    button4.Text = _lines[2];
                    button5.Text = _lines[3];

                    
                    return _lines;                  
                }

                int arg = r.Next(0, 4);
                if (already_in.Contains(arg))
                {
                    continue;
                }
                else
                {
                    _lines[counter] = lines[arg];
                    already_in.Add(arg);
                    counter++;
                }
            }

            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 Add = new Form2();
            Add.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Button incoming_value = sender as Button;

            if (incoming_value.Text == current_right_answer)
            {
                tries++;
                incoming_value.BackColor = Color.LightGreen;
                MessageBox.Show("Correct!", "good job");
                Reset_colors();
                button1_Click(sender, e);
                right_answer++;
                Update_lable();
                

            }
            else
            {
                tries++;
                incoming_value.BackColor = Color.IndianRed;
                wrong_answers++;
                incoming_value.Enabled = false;
                Update_lable();
            }

            if (actions == max + 1)
            {
                MessageBox.Show("All words looped");

                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;

                Update_lable();

                label2.Text = "Done!";

                button8.Enabled = true;
                button8.Visible = true;


            }



        }

        void Reset_colors() // More like reset buttons. Resets colors and enables status
        {
            button1.BackColor = Color.SkyBlue;
            button2.BackColor = Color.SkyBlue;
            button3.BackColor = Color.SkyBlue;
            button4.BackColor = Color.SkyBlue;
            button5.BackColor = Color.SkyBlue;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            

        }

        void Update_lable()
        {
            label2.Text = actions.ToString() + " out of " + max.ToString();

            double percent = (double)right_answer * 100 / tries;
            percent = Math.Round(percent, 2);

            string lox = percent.ToString();

            label3.Text = lox + "% correct answers";
            label3.Visible = true;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Delete_word delete_form = new Delete_word();
            pictureBox1.Image.Dispose();

            textBox1.ForeColor = Color.Red;
            textBox1.Text = "!!! Restart the program after you finished deleting words !!!";

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
           

            delete_form.Show();

            button8.Enabled = true;
            button8.Visible = true;

        }

        private void button8_Click(object sender, EventArgs e)
        {   
            Process.Start("Learn it!.exe");
            Process.GetCurrentProcess().Kill();
        }
    
    }


}

