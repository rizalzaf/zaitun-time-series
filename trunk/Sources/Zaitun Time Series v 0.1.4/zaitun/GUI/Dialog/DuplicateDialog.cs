using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using zaitun.Data;

namespace zaitun.GUI
{
    public partial class DuplicateDialog : Form
    {        

        public DuplicateDialog()
        {
            InitializeComponent();            
        }

        public void SetVariable(SeriesVariable variable)
        {
            this.Text = "Duplicate Variable : " + variable.VariableName;
            this.lblName.Text = "New Variable Name";
        }

        public void SetGroup(SeriesGroup group)
        {
            this.Text = "Duplicate Group : " + group.GroupName;
            this.lblName.Text = "New Group Name";  
        }

        public string NewName
        {
            get { return this.txtName.Text.Trim(); }
        }        

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1)
            {
                MessageBox.Show("Type new name", "Duplicate Dialog", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtName.Focus();
            }           

        }
    }
}