using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zaitun.TrendAnalysis
{
    public partial class TrendAnalysisStorageForm : Form
    {
        public TrendAnalysisStorageForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Menentukan apakah prediksi akan ditambahkan sebagai variabel baru
        /// </summary>
        public bool IsStorePredicted
        {
            get { return this.isStorePredictedCheckBox.Checked; }
            set { this.isStorePredictedCheckBox.Checked = value; }
        }

        /// <summary>
        /// Menentukan apakah residual akan ditambahkan sebagai variabel baru
        /// </summary>
        public bool IsStoreResidual
        {
            get { return this.isStoreResidualCheckBox.Checked; }
            set { this.isStoreResidualCheckBox.Checked = value; }
        }

        /// <summary>
        /// Mendapatkan nama variabel baru prediksi
        /// </summary>
        public string PredictedName
        {
            get { return this.predictedNameBox.Text; }
            set { this.predictedNameBox.Text = value; }
        }

        /// <summary>
        /// Mendapatkan nama variabel baru residual
        /// </summary>
        public string ResidualName
        {
            get { return this.residualNameBox.Text; }
            set { this.residualNameBox.Text = value; }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.isStorePredictedCheckBox.Checked && this.predictedNameBox.Text == "")
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

    }
}