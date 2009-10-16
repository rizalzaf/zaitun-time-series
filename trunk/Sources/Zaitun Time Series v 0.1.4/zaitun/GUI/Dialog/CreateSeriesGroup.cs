using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using zaitun.GUI;
using zaitun.Data;

namespace zaitun.GUI
{
    public partial class CreateSeriesGroup : Form
    {
        private SeriesVariables sourceVariables;
        private SeriesVariables groupList;

        public CreateSeriesGroup(SeriesVariables sourceVariables)
        {
            InitializeComponent();
            this.sourceVariables = sourceVariables;
            this.groupList = new SeriesVariables();
            this.lstVariables.Items.Clear();
            foreach (SeriesVariable item in sourceVariables)
            {
                this.lstVariables.Items.Add(item);
            }            
        }

        public string GroupName
        {
            get { return this.txtName.Text.Trim(); }
        }

        public SeriesVariables GroupList
        {
            get 
            {
                groupList.Clear();
                foreach (SeriesVariable item in this.lstVariables.SelectedItems)
                {
                    groupList.Add(item);
                }                
                return groupList;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1)
            {
                MessageBox.Show("Type group name", "Create Series Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else if (this.lstVariables.SelectedItems.Count < 1)
            {
                MessageBox.Show("Select two or more variables belong to this group", "Create Series Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else if (this.lstVariables.SelectedItems.Count < 2)
            {
                MessageBox.Show("Select two or more variables belong to this group", "Create Series Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}