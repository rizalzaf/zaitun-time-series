using System;
using System.Collections.Generic;
using System.Windows.Forms;
using zaitun.GUI;

namespace zaitun
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            new SplashScreen().ShowDialog();
            MDIForm frm = new MDIForm();

            if (args.Length > 0)
            {
                frm.Show();
                frm.OpenFile(args[0]);
            }

            Application.Run(frm);

        }
    }
}