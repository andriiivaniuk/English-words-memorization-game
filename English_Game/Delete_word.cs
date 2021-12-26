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
    public partial class Delete_word : Form
    {

        int max;                    // maximum amount of words Program currantly has, variable used to form Lists
        string file_pathes_text;    //  Variables to hold current file path
        string file_pathes_pics;    //  Variables to hold current file path

        Dictionary<int, string> dat_list_text = new Dictionary<int, string>();
        Dictionary<int, string> dat_list_pics = new Dictionary<int, string>();

        public Delete_word()
        {
            InitializeComponent();
            file_pathes_text = "english_prog_files\\text\\";
            file_pathes_pics = "english_prog_files\\pictures\\";

            Init_lists();
        }

        private void Delete_word_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure about deleting " + listBox1.SelectedItem + "?", "care", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

            int deleted_index = listBox1.SelectedIndex + 1;
            File.Delete(dat_list_text[(listBox1.SelectedIndex + 1)]);
            File.Delete(dat_list_pics[(listBox1.SelectedIndex + 1)]);
            Update_names(deleted_index);
            Update_lists(deleted_index);
            this.Hide();  

            }
            else if (dialogResult == DialogResult.No)
            {
                
            }


        }

        void Update_names (int index)
        {
            for (int i = index+1; i <= max; i++)
            {
                File.Copy(file_pathes_text + i.ToString() + ".txt", file_pathes_text + (i - 1).ToString() + ".txt");
                File.Copy(file_pathes_pics + i.ToString() + ".jpg", file_pathes_pics + (i - 1).ToString() + ".jpg");

                File.Delete(file_pathes_text + i.ToString() + ".txt");
                File.Delete(file_pathes_pics + i.ToString() + ".jpg");
            }
        }

        void Init_lists()
        {
            string[] temp_to_know_how_many_files = Directory.GetFiles("english_prog_files\\text\\");
            max = temp_to_know_how_many_files.Length;


            for (int i = 0; i < max; i++)

            {
                string[] temp = File.ReadAllLines(file_pathes_text + (i + 1).ToString() + ".txt");

                listBox1.Items.Add((i + 1).ToString() + ". " + temp[0]);            // Filling List of words
                checkedListBox1.Items.Add((i + 1).ToString() + ". " + temp[0]);     // Filling Checkbox list to select multiple words

                dat_list_text.Add(i + 1, file_pathes_text + (i + 1).ToString() + ".txt");
                dat_list_pics.Add(i + 1, file_pathes_pics + (i + 1).ToString() + ".jpg");
            }



        }

        void Update_lists(int index)
        {
            dat_list_pics.Clear();
            dat_list_text.Clear();

            string[] temp_to_know_how_many_files = Directory.GetFiles("english_prog_files\\text\\");

            max = temp_to_know_how_many_files.Length;


            for (int i = index + 1; i <= max; i++)
            {
                string[] temp = File.ReadAllLines(file_pathes_text + i.ToString() + ".txt");
                listBox1.Items.Add(  i.ToString() + ". " + temp[0]);

                dat_list_text.Add(i, file_pathes_text + i.ToString() + ".txt");
                dat_list_pics.Add(i, file_pathes_pics + i.ToString() + ".jpg");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                
        }
    }
    }

