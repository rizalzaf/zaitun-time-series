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
using zaitun.Data;

namespace zaitun.Correlogram
{
    /// <summary>
    /// Form Dialog Correlogram       
    /// </summary>
    public partial class CorrelogramForm : Form
    {
        private SeriesVariable variable;
        private double[] seriesVariable;
        private double[] data;
        private int lag;

        private bool whiteNoiseAcf = true;
        private CorrelogramSeries series = CorrelogramSeries.Level;

        public enum CorrelogramSeries
        {
            Level,
            FirstDifference,
            SecondDifference
        }

        /// <summary>
        /// mengeset nilai-nilai variabel
        /// mengeset nilai minimum untuk lag
        /// </summary>
        /// <param name="variable"> variabel yang digunakan untuk analisis
        /// </param>
        
        public void SetVariable(SeriesVariable variable)
        {
            this.variable = variable;
            this.seriesVariable = variable.SeriesValuesNoNaN.ToArray();
            this.numericlag.Text = (Math.Min(60, this.seriesVariable.Length / 4)).ToString(); 
            
        }


        public CorrelogramForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Mendapatkan data
        /// </summary>
        public double[] Data
        {
            get { return data; }
        }

        /// <summary>
        /// White noise ACF
        /// </summary>
        public bool WhiteNoiseAcf
        {
            get { return this.whiteNoiseAcf; }
        }

        /// <summary>
        /// Series type
        /// </summary>
        public CorrelogramSeries Series
        {
            get { return this.series; }
        }



        /// <summary>
        /// Hal-hal yang dilakukan ketika button OK pada form diklik
        /// </summary>
        private void OK_Click(object sender, EventArgs e)
        {
            Differencing dt;
            
            //tanpa menggunakan proses diferensi
            if (this.level.Checked) { 
                this.data = seriesVariable;
                this.series = CorrelogramSeries.Level;
            }

            //menggunakan diferensi tingkat pertama
            else if (this.firstdifference.Checked)
            {
                dt = new Differencing(seriesVariable, 1);
                this.data = dt.Data;
                this.series = CorrelogramSeries.FirstDifference;
            }

            //menggunakan diferensi tingkat kedua
            else if (this.seconddifference.Checked)
            {
                dt = new Differencing(seriesVariable, 2);
                this.data = dt.Data;
                this.series = CorrelogramSeries.SecondDifference;
            }

            // read whether use white nosise on ACF or no?
            this.whiteNoiseAcf = this.whiteNoiseCheckBox.Checked;

            //validasi untuk jumlah data yang kurang atau sama dengan 3
            if (this.data.Length <= 3)
            {
                MessageBox.Show("Insufficient number of observations", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }
                        
            int lag1;

           //User memasukkan nilai lag
            try { lag1 = int.Parse(numericlag.Text); }
            catch
            {                
                if (seriesVariable.Length <= 240) lag1 = data.Length / 4;
                else lag1 = (int)Math.Sqrt(seriesVariable.Length) + 45;
            }
            
            if (lag1 == 0)
            {
                if (seriesVariable.Length <= 240) this.lag = data.Length / 4;
                else this.lag = (int)Math.Sqrt(seriesVariable.Length) + 45;
            }
           
            else if (lag1 >= data.Length)
            {
                this.lag = data.Length - 1;
            }

            else this.lag = lag1;
           

        }

        /// <summary>
        /// mendapatkan nilai lag
        /// </summary>
        public int Lag
        {
            get { return lag; }
        }

        /// <summary>
        /// Menampilkan keterangan pada form
        /// </summary>
        private void correlogram_Load(object sender, EventArgs e)
        {
            //ToolTip toolTip1 = new ToolTip();

            //// Set up the delays for the ToolTip.
            //toolTip1.AutoPopDelay = 500000;
            //toolTip1.InitialDelay = 100;
            //toolTip1.ReshowDelay = 10;

            //// Force the ToolTip text to be displayed whether or not the form is active.
            //toolTip1.ShowAlways = true;


            //// Set up the ToolTip text for the Button and Checkbox.
            
            //toolTip1.SetToolTip(this.CorrelogramGroupBox1, "Pick Differencing Process\n" + "* level = Without Differencing Process\n" + "* 1st difference = First Differencing Process\n" + "* 2nd difference = Second Differencing Process");
            
            //toolTip1.SetToolTip(this.LagGroupBox, "Type the number of Lags");

        }

        

       
    }
}