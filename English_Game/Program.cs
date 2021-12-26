using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace English_Game
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            if (Check_folders() == -1)
            {
                return;
            }



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static int Check_folders()
        {
            if (!Directory.Exists("english_prog_files\\") || !Directory.Exists("english_prog_files\\text\\") || !Directory.Exists("english_prog_files\\pictures"))
            {
                MessageBox.Show("File folders not found! Make sure you have proper folder 'english_prog_files' that has 'text' and 'pictures' subfolders in it.");
                return -1;
            }

            if (File.Exists("english_prog_files\\pictures\\1.jpg") == false || File.Exists("english_prog_files\\text\\1.txt") == false)
            {
                MessageBox.Show("No pictures or text files found! Make sure 'text' and 'pictures' folders contains at least 1 file.");
                return -1;
            }
            else
            {
                return 0;
            }

        }
    
    }


}
