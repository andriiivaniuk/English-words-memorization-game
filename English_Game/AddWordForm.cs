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

namespace English_Game
{
    public partial class Form2 : Form
    {
        OpenFileDialog NewPic = new OpenFileDialog();
        public Form2()
        {
            InitializeComponent();
            label1.Text = "Picture not selected";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            NewPic.Filter = "Images | *.jpeg; *.gif; *.jpg; *.png;  ";

            if (NewPic.ShowDialog() == DialogResult.OK)
            {
                checkBox1.Checked = true;
                label1.Text = NewPic.FileName;
                Check();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Pic_path = NewPic.FileName.ToString();
            
            string[] current_text = Directory.GetFiles("english_prog_files\\text\\");
            int current_text_max = current_text.Length;

            string[] current_pictures = Directory.GetFiles("english_prog_files\\pictures");
            int current_pic_max = current_pictures.Length;

            File.Copy(Pic_path, "english_prog_files\\pictures\\" + (current_pic_max + 1).ToString() + ".jpg");
            //File.Create("english_prog_files\\text\\" + (current_text_max + 1).ToString() + ".txt");

            StreamWriter new_text_writer = File.CreateText("english_prog_files\\text\\" + (current_text_max + 1).ToString() + ".txt");

            string[] new_lines = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text };

            for (int i = 0; i < 5; i++)
            {
                new_text_writer.Write(new_lines[i]);
                new_text_writer.Write("\n");
            }

                new_text_writer.Close();
                MessageBox.Show("Word added!");
                this.Hide();

                
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Check();
        }

        void Check()
        {
            if (checkBox1.Checked == true && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }
    }
}
