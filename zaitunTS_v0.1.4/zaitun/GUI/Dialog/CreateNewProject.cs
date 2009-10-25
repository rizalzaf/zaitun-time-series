// Zaitun Time Series 
// http://www.zaitunsoftware.com/
// http://code.google.com/p/zaitun-time-series/
//
// Copyright ©  2008-2009, Zaitun Time Series Developer Team and individual contributors
//
// Core Programmer: Rizal Zaini Ahmad Fathony (rizalzaf@gmail.com)
// Programmer: Suryono Hadi Wibowo, Khaerul Anas, Almaratul Sholihah, Muhamad Fuad Hasan
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
using zaitun.Data;

namespace zaitun.GUI
{
    public partial class CreateNewProject : Form
    {

        private DateTime startDate = new DateTime();
        private DateTime endDate = new DateTime();
        private SeriesData.SeriesFrequency frequency = new SeriesData.SeriesFrequency();
        

        public CreateNewProject()
        {
            InitializeComponent();
        }

        public DateTime StartDate
        {
            get { return this.startDate; }
        }

        public DateTime EndDate
        {
            get { return this.endDate; }
        }

        public string DataName
        {
            get { return this.txtName.Text; }
        }

        public SeriesData.SeriesFrequency Frequency
        {
            get { return this.frequency; }
        }

        public int NumberObservations
        {
            get { return int.Parse(this.txtObsDisplay.Text); }
        }

        private void CreateNewProject_Load(object sender, EventArgs e)
        {            
            this.initializeDate();
            cmbTipe.SelectedIndex = 0;
        }

        private void initializeDate()
        {
            numYearStart.Value = DateTime.Now.Year;
            numYearEnd.Value = DateTime.Now.Year;
            numMonthStart.Value = 1;
            numMonthEnd.Value = 1;
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
            txtObservation.Text = "0";
        }

        private void cmbTipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.frequency = (SeriesData.SeriesFrequency)this.cmbTipe.SelectedIndex;            
            this.viewSpecificationPane((SeriesData.SeriesFrequency)this.cmbTipe.SelectedIndex);            
        }

        private void viewSpecificationPane(SeriesData.SeriesFrequency frequency)
        {
            switch (frequency)
            {
                case SeriesData.SeriesFrequency.Annual:
                    grpDate.Visible = false;
                    grpYear.Visible = true;
                    grpUndated.Visible = false;                    

                    txtMinor.Text = "Month: ";
                    numMonthStart.Enabled = false;
                    numMonthEnd.Enabled = false;

                    this.calculateStartDate();
                    this.calculateEndDate();

                    break;
                case SeriesData.SeriesFrequency.SemiAnnual:
                    grpDate.Visible = false;
                    grpYear.Visible = true;
                    grpUndated.Visible = false;

                    txtMinor.Text = "Half: ";
                    numMonthStart.Enabled = true;
                    numMonthEnd.Enabled = true;
                    numMonthStart.Maximum = 2;
                    numMonthEnd.Maximum = 2;

                    this.calculateStartDate();
                    this.calculateEndDate();

                    break;
                case SeriesData.SeriesFrequency.Quarterly:
                    grpDate.Visible = false;
                    grpYear.Visible = true;
                    grpUndated.Visible = false;

                    txtMinor.Text = "Quarter: ";
                    numMonthStart.Enabled = true;
                    numMonthEnd.Enabled = true;
                    numMonthStart.Maximum = 4;
                    numMonthEnd.Maximum = 4;

                    this.calculateStartDate();
                    this.calculateEndDate();

                    break;
                case SeriesData.SeriesFrequency.Monthly:
                    grpDate.Visible = false;
                    grpYear.Visible = true;
                    grpUndated.Visible = false;

                    txtMinor.Text = "Month: ";
                    numMonthStart.Enabled = true;
                    numMonthEnd.Enabled = true;
                    numMonthStart.Maximum = 12;
                    numMonthEnd.Maximum = 12;

                    this.calculateStartDate();
                    this.calculateEndDate();

                    break;
                case SeriesData.SeriesFrequency.Weekly:
                    grpDate.Visible = true;
                    grpYear.Visible = false;
                    grpUndated.Visible = false;

                    this.startDate = this.dtpStart.Value;
                    this.endDate = this.dtpEnd.Value;
                    this.displayNumberObservations();
                 
                    break;
                case SeriesData.SeriesFrequency.Daily:
                    grpDate.Visible = true;
                    grpYear.Visible = false;
                    grpUndated.Visible = false;

                    this.startDate = this.dtpStart.Value;
                    this.endDate = this.dtpEnd.Value;
                    this.displayNumberObservations();

                    break;
                case SeriesData.SeriesFrequency.Daily6:
                    grpDate.Visible = true;
                    grpYear.Visible = false;
                    grpUndated.Visible = false;

                    this.startDate = this.dtpStart.Value;
                    this.endDate = this.dtpEnd.Value;
                    this.displayNumberObservations();

                    break;
                case SeriesData.SeriesFrequency.Daily5:
                    grpDate.Visible = true;
                    grpYear.Visible = false;
                    grpUndated.Visible = false;

                    this.startDate = this.dtpStart.Value;
                    this.endDate = this.dtpEnd.Value;
                    this.displayNumberObservations();

                    break;
                case SeriesData.SeriesFrequency.Undated:
                    grpDate.Visible = false;
                    grpYear.Visible = false;
                    grpUndated.Visible = true;

                    try { this.setNumberObservations(int.Parse(txtObservation.Text)); }
                    catch { this.setNumberObservations(0); }

                    break;
            }
        }

        private void txtObservation_TextChanged(object sender, EventArgs e)
        {
            try { this.setNumberObservations(int.Parse(txtObservation.Text)); }
            catch { this.setNumberObservations(0); }
        }

        private void setNumberObservations(int value)
        {
            txtObsDisplay.Text = value.ToString();
        }

        private void displayNumberObservations()
        {
            int count = SeriesData.NumberObservation(this.startDate, this.endDate, this.frequency);
            this.setNumberObservations(count);
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            this.startDate = this.dtpStart.Value;
            this.displayNumberObservations();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            this.endDate = this.dtpEnd.Value;
            this.displayNumberObservations();
        }

        private void numYearStart_ValueChanged(object sender, EventArgs e)
        {
            this.calculateStartDate();
        }

        private void numMonthStart_ValueChanged(object sender, EventArgs e)
        {
            this.calculateStartDate();
        }

        private void calculateStartDate()
        {
            int year = (int)this.numYearStart.Value;
            int month = 1;
            switch (this.frequency)
            {
                case SeriesData.SeriesFrequency.Annual:
                    month = 1;
                    break;
                case SeriesData.SeriesFrequency.SemiAnnual:
                    month = (int)this.numMonthStart.Value * 6;
                    break;
                case SeriesData.SeriesFrequency.Quarterly:
                    month = (int)this.numMonthStart.Value * 3;
                    break;
                case SeriesData.SeriesFrequency.Monthly:
                    month = (int)this.numMonthStart.Value;
                    break;
            }

            DateTime tmp = new DateTime(year, month, 1);
            this.startDate = tmp;

            this.displayNumberObservations();
        }

        private void numYearEnd_ValueChanged(object sender, EventArgs e)
        {
            this.calculateEndDate();
        }

        private void numMonthEnd_ValueChanged(object sender, EventArgs e)
        {
            this.calculateEndDate();
        }

        private void calculateEndDate()
        {
            int year = (int)this.numYearEnd.Value;
            int month = 1;
            switch (this.frequency)
            {
                case SeriesData.SeriesFrequency.Annual:
                    month = 1;
                    break;
                case SeriesData.SeriesFrequency.SemiAnnual:
                    month = (int)this.numMonthEnd.Value * 6;
                    break;
                case SeriesData.SeriesFrequency.Quarterly:
                    month = (int)this.numMonthEnd.Value * 3;
                    break;
                case SeriesData.SeriesFrequency.Monthly:
                    month = (int)this.numMonthEnd.Value;
                    break;
            }

            DateTime tmp = new DateTime(year, month, 1);
            this.endDate = tmp;

            this.displayNumberObservations();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1)
            {
                MessageBox.Show("Type project name", "Create New Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else if (this.frequency != SeriesData.SeriesFrequency.Undated && this.startDate >= this.endDate)
            {
                MessageBox.Show("Set the correct time", "Create New Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}