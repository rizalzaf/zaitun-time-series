using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zaitun.ExponentialSmoothing
{
    public partial class SingleESOptionsForm : Form
    {
        public SingleESOptionsForm()
        {
            InitializeComponent();
        }

        public int InitialSmoothed
        {
            get
            {
                int result; 
                try { result = int.Parse(this.initialSmoothedTextBox.Text); }
                catch { result = 6; } 
                return result;
            }
            set
            {
                this.initialSmoothedTextBox.Text = value.ToString();
            }
        }
    }
}