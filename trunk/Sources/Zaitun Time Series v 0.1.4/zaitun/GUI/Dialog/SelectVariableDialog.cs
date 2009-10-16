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
    public partial class SelectVariableDialog : Form
    {
        public SelectVariableDialog(SeriesData data)
        {
            InitializeComponent();
            lstSeriesData.SetData(data.SeriesVariables, data.SeriesGroups);
        }

        public SeriesDataList.Item SelectedItem
        {
            get { return lstSeriesData.SelectedItem; }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (this.lstSeriesData.SelectedItem.ListIndex < 0)
            {
                MessageBox.Show("Anda harus memilih salah satu variabel atau group", "Select Variable Dialog", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}