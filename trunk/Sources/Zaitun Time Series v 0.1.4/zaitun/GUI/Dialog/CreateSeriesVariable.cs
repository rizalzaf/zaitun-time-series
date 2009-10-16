using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zaitun.GUI
{
    public partial class CreateSeriesVariable : Form
    {
        public CreateSeriesVariable()
        {
            InitializeComponent();            
        }

        public string VariableName
        {
            get { return this.txtName.Text.Trim(); }
        }

        public string VariableDescription
        {
            get { return this.txtDescription.Text.Trim(); }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1)
            {
                MessageBox.Show("Type variable name", "Create Series Variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtName.Focus();
            }
            else if (txtDescription.Text.Length < 1)
            {
                this.txtDescription.Text = this.txtName.Text;
            }

        }
    }
}