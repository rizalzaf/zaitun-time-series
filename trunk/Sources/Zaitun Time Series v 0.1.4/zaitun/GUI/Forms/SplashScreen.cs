using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zaitun.GUI
{
    public partial class SplashScreen : Form
    {        
        
        public SplashScreen()
        {            
            InitializeComponent();
            timer.Enabled = true;
        }        

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}