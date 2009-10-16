using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zaitun.Decomposition
{
    public partial class DecompositionStorageForm : Form
    {
        public DecompositionStorageForm()
        {
            InitializeComponent();
        }

        public bool IsStoreTrend
        {
            get { return this.isStoreTrendCheckBox.Checked; }
            set { this.isStoreTrendCheckBox.Checked = value; }
        }

        public bool IsStoreDetrend
        {
            get { return this.isStoreDetrendCheckBox.Checked; }
            set { this.isStoreDetrendCheckBox.Checked = value; }
        }

        public bool IsStoreDeseasonal
        {
            get { return this.isStoreDeseasonalCheckBox.Checked; }
            set { this.isStoreDeseasonalCheckBox.Checked = value; }
        }

        public bool IsStorePredicted
        {
            get { return this.isStorePredictedCheckBox.Checked; }
            set { this.isStorePredictedCheckBox.Checked = value; }
        }

        public bool IsStoreResidual
        {
            get { return this.isStoreResidualCheckBox.Checked; }
            set { this.isStoreResidualCheckBox.Checked = value; }
        }

        public string TrendName
        {
            get { return this.trendNameBox.Text; }
            set { this.trendNameBox.Text = value; }
        }

        public string DetrendName
        {
            get { return this.detrendNameBox.Text; }
            set { this.detrendNameBox.Text = value; }
        }

        public string DeseasonalName
        {
            get { return this.deseasonalNameBox.Text; }
            set { this.deseasonalNameBox.Text = value; }
        }

        public string PredictedName
        {
            get { return this.predictedNameBox.Text; }
            set { this.predictedNameBox.Text = value; }
        }

        public string ResidualName
        {
            get { return this.residualNameBox.Text; }
            set { this.residualNameBox.Text = value; }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.isStoreTrendCheckBox.Checked && this.trendNameBox.Text == "")
            {
                MessageBox.Show("Please type trend variable name!", "Store Variable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                this.trendNameBox.Focus();
            }
            else if (this.isStoreDetrendCheckBox.Checked && this.detrendNameBox.Text == "")
            {
                MessageBox.Show("Please type detrended variable name!", "Store Variable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                this.detrendNameBox.Focus();
            }
            else if (this.isStoreDeseasonalCheckBox.Checked && this.deseasonalNameBox.Text == "")
            {
                MessageBox.Show("Please type deseasonalized variable name!", "Store Variable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                this.deseasonalNameBox.Focus();
            }
            else if (this.isStorePredictedCheckBox.Checked && this.predictedNameBox.Text == "")
            {
                MessageBox.Show("Please type predicted variable name!", "Store Variable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                this.predictedNameBox.Focus();
            }
            else if (this.isStoreResidualCheckBox.Checked && this.residualNameBox.Text == "")
            {
                MessageBox.Show("Please type residual variable name!", "Store Variable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                this.residualNameBox.Focus();
            }
            
        }

        private void isStorePredictedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool checkedCheck = ((CheckBox)sender).Checked;
            this.predictedNameBox.Enabled = checkedCheck;
        }

        private void isStoreResidualCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool checkedCheck = ((CheckBox)sender).Checked;
            this.residualNameBox.Enabled = checkedCheck;
        }

        private void isStoreTrendCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool checkedCheck = ((CheckBox)sender).Checked;
            this.trendNameBox.Enabled = checkedCheck;
        }

        private void isStoreDetrendCheckBox_CheckedChanged(object sender, EventArgs e) 
        {
            bool checkedCheck = ((CheckBox)sender).Checked;
            this.detrendNameBox.Enabled = checkedCheck;
        }

        private void isStoreDeseasonalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool checkedCheck = ((CheckBox)sender).Checked;
            this.deseasonalNameBox.Enabled = checkedCheck;
        }

    }
}