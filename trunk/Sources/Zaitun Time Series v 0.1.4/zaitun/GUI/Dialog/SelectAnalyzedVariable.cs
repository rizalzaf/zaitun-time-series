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
    public partial class SelectAnalyzedVariable : Form
    {
        public SelectAnalyzedVariable(SeriesVariables sourceVariables)
        {
            InitializeComponent();
            this.lstVariables.Items.Clear();
            foreach (SeriesVariable item in sourceVariables)
            {
                this.lstVariables.Items.Add(item);
            }     
        }

        public SeriesVariable SelectedVariable
        {
            get { return (SeriesVariable)this.lstVariables.SelectedItem; }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (this.lstVariables.SelectedIndex < 0)
            {
                MessageBox.Show("Please select variable", "Select Analyzed Variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }

        private void lstVariables_DoubleClick(object sender, EventArgs e)
        {
            if (this.lstVariables.SelectedIndex < 0)
            {
                MessageBox.Show("Please select variable", "Select Analyzed Variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else
            { this.DialogResult = DialogResult.OK; }
        }

        private void SelectAnalyzedVariable_Load(object sender, EventArgs e)
        {

        }   
    }
}