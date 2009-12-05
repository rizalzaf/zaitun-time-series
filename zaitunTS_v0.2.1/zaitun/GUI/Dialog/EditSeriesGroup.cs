// Zaitun Time Series 
// http://www.zaitunsoftware.com/
// http://code.google.com/p/zaitun-time-series/
//
// Copyright ©  2008-2009, Zaitun Time Series Developer Team and individual contributors
//
// Leader: Rizal Zaini Ahmad Fathony (rizalzaf@gmail.com)
// Members: Suryono Hadi Wibowo (ryonoha@gmail.com), Khaerul Anas (anasikova@gmail.com), 
//          Lia Amelia (afifahlia@gmail.com), Almaratul Sholihah, Muhamad Fuad Hasan
//
// This is free software; you can redistribute it and/or modify it
// under the terms of the GNU General Public License as
// published by the Free Software Foundation; either version 3 of
// the License, or (at your option) any later version.
//
// This software is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// General Public License for more details.
//
// You should have received a copy of the GNU General Public
// License along with this software; if not, write to the Free
// Software Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
// 02110-1301 USA, or see the FSF site: http://www.fsf.org.

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
    public partial class EditSeriesGroup : Form
    {
        private SeriesVariables sourceVariables;
        private SeriesVariables groupList;

        private SeriesGroup group;

        public EditSeriesGroup(SeriesVariables sourceVariables)
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

        public void SetGroup(SeriesGroup group)
        {
            this.group = group;
            this.txtName.Text = group.GroupName;
            foreach (SeriesVariable item in this.sourceVariables)
            {
                if (group.GroupList.Contains(item)) lstVariables.SelectedItems.Add(item);
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
                MessageBox.Show("Type group name", "Edit Series Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else if (this.lstVariables.SelectedItems.Count < 1)
            {
                MessageBox.Show("Select two or more variables belong to this group", "Edit Series Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else if (this.lstVariables.SelectedItems.Count < 2)
            {
                MessageBox.Show("Select two or more variables belong to this group", "Edit Series Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}