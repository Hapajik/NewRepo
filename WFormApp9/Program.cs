using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFormApp9
{
    static class Data
    {
        public static string Glob_connection_string = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hapajik\Desktop\WFormApp9\WFormApp9\AVTO_BASE.mdf;Integrated Security = True; Connect Timeout = 30";

    }
    static class Program
    {
        /// <summary>
     
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
