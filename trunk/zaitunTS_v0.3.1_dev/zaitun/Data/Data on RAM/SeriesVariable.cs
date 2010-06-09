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
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace zaitun.Data
{
    /// <summary>
    /// Kelas yang menyimpan data sebuah variabel
    /// </summary>
    public class SeriesVariable : ICloneable
    {
        private string variableName;        
        private string variableDescription;
        private double minValue;
        private double maxValue;
        private double sumValue;
        private double meanValue;
        private double medianValue;
        private double q1Value;
        private double q3Value;
        private double sumSquareDevValue;
        private double sum4DevValue;
        private double stDevValue;
        private double variansValue;
        private double skewnessValue;
        private double kurtosisValue;

        private int observations;

        private bool isValueChanged;

        private ListWithOnChanged<double> seriesValues;  

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Nama Variabel</param>
        /// <param name="description">Deskripsi Variabel</param>
        public SeriesVariable(string name, string description)
        {
            this.initialize(name, description);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Nama Variabel</param>
        /// <param name="description">Deskripsi Variabel</param>
        /// <param name="numberObservations">Jumlah Observasi</param>
        public SeriesVariable(string name, string description, int numberObservations)
        {
            this.initialize(name, description);
            double[] temp = new double[numberObservations];          
            seriesValues.AddRange(temp);            
        }

        /// <summary>
        /// Inisialsisasi variabel
        /// </summary>
        /// <param name="name">nama variabel</param>
        /// <param name="description">deskripsi variabel</param>
        private void initialize(string name, string description)
        {
            this.variableName = name;
            this.variableDescription = description;            
            seriesValues = new ListWithOnChanged<double>();
            isValueChanged = false;
            sumValue = 0;
            this.seriesValues.Changed += new ChangedEventHandler(SeriesValues_Changed);
        }

        /// <summary>
        /// Inisialisasi nilai observasi dalam variabel dengan nilai 0
        /// </summary>
        /// <param name="numberObservations"></param>
        public void InitializeItem(int numberObservations)
        {
            double[] tmp = new double[numberObservations];
            this.SeriesValues.Clear();
            this.seriesValues.AddRange(tmp);
            isValueChanged = true;
        }

        /// <summary>
        /// Nama Variabel
        /// </summary>
        public string VariableName
        {
            get { return variableName; }
            set { variableName = value; OnChanged(System.EventArgs.Empty); }
        }

        /// <summary>
        /// Deskripsi variabel
        /// </summary>
        public string VariableDescription
        {
            get { return variableDescription; }
            set { variableDescription = value; OnChanged(System.EventArgs.Empty); }
        }

        /// <summary>
        /// List nilai-nilai dalam variabel
        /// </summary>
        public ListWithOnChanged<double> SeriesValues
        {
            get { return this.seriesValues; }
            //set { this.seriesValues = value; }
        }

        /// <summary>
        /// List nilai-nilai dalam variabel tanpa memasukkan nilai NaN
        /// </summary>
        public ListWithOnChanged<double> SeriesValuesNoNaN
        {
            get
            {
                ListWithOnChanged<double> tmpList = new ListWithOnChanged<double>();
                
                foreach (double item in this.seriesValues)
                    if (!double.IsNaN(item)) tmpList.Add(item);

                return tmpList;
            }
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>Nilai data pada variabel index tertentu</returns>
        public double this[int index]
        {
            get { return this.seriesValues[index]; }
            set { this.seriesValues[index] = value; }
        }

        /// <summary>
        /// Jumlah observasi
        /// </summary>
        public int Observations
        {
            get 
            {                
                if (isValueChanged) reCalculate();
                return this.observations; 
            }            
        }

        /// <summary>
        /// Nilai minimum variabel
        /// </summary>
        public double MinValue
        {
            get
            {
                if (this.observations > 0)
                {
                    if (isValueChanged) reCalculate();
                    return minValue;
                }
                else
                {
                    return System.Double.NaN ;
                }
            }
        }

        /// <summary>
        /// Nilai maksimum variabel
        /// </summary>
        public double MaxValue
        {
            get
            {
                if (this.observations > 0)
                {
                    if (isValueChanged) reCalculate();
                    return maxValue;
                }
                else
                {
                    return System.Double.NaN;
                }

            }
        }

        /// <summary>
        /// Jumlah nilai seluruh observasi dalam variabel
        /// </summary>
        public double SumValue
        {
            get
            {
                if (this.observations > 0)
                {
                    if (isValueChanged) reCalculate();
                    return sumValue;
                }
                else
                {
                    return System.Double.NaN;
                }
            }
        }

        /// <summary>
        /// Nilai rata-rata variabel
        /// </summary>
        public double MeanValue
        {
            get
            {
                if (this.observations > 0)
                {
                    if (isValueChanged) reCalculate();
                    return meanValue;
                }
                else
                {
                    return System.Double.NaN;
                }
            }
        }

        /// <summary>
        /// Nilai median variabel
        /// </summary>
        public double MedianValue
        {
            get
            {
                if (this.observations > 0)
                {
                    if (isValueChanged) reCalculate();
                    return medianValue;
                }
                else
                {
                    return System.Double.NaN;
                }
            }
        }

        /// <summary>
        /// Nilai kuartil 1 variabel
        /// </summary>
        public double Q1Value
        {
            get
            {
                if (this.observations > 0)
                {
                    if (isValueChanged) reCalculate();
                    return q1Value;
                }
                else
                {
                    return System.Double.NaN;
                }
            }
        }

        /// <summary>
        /// Nilai kuartil 3 variabel
        /// </summary>
        public double Q3Value
        {
            get
            {
                if (this.observations > 0)
                {
                    if (isValueChanged) reCalculate();
                    return q3Value;
                }
                else
                {
                    return System.Double.NaN;
                }
            }
        }

        /// <summary>
        /// Nilai jumlah kuadrat deviasi data
        /// </summary>
        public double SumSquareDevValue
        {
            get
            {
                if (this.observations > 0)
                {
                    if (isValueChanged) reCalculate();
                    return sumSquareDevValue;
                }
                else
                {
                    return System.Double.NaN;
                }
            }
        }

        /// <summary>
        /// Nilai jumlah pangkat empat deviasi data
        /// </summary>
        public double Sum4DevValue
        {
            get
            {
                if (this.observations > 0)
                {
                    if (isValueChanged) reCalculate();
                    return sum4DevValue;
                }
                else
                {
                    return System.Double.NaN;
                }
            }
        }

        /// <summary>
        /// Nilai standar deviasi variabel
        /// </summary>
        public double StDevValue
        {
            get
            {
                if (this.observations > 0)
                {
                    if (isValueChanged) reCalculate();
                    return stDevValue;
                }
                else
                {
                    return System.Double.NaN;
                }
            }
        }

        /// <summary>
        /// Nilai varians variabel
        /// </summary>
        public double VariansValue
        {
            get
            {
                if (this.observations > 0)
                {
                    if (isValueChanged) reCalculate();
                    return variansValue;
                }
                else
                {
                    return System.Double.NaN;
                }
            }
        }

        /// <summary>
        /// Nilai skewness variabel
        /// </summary>
        public double SkewnessValue
        {
            get
            {
                if (this.observations > 0)
                {
                    if (isValueChanged) reCalculate();
                    return skewnessValue;
                }
                else
                {
                    return System.Double.NaN;
                }
            }
        }

        /// <summary>
        /// Nilai kurtosis variabel
        /// </summary>
        public double KurtosisValue
        {
            get
            {
                if (this.observations > 0)
                {
                    if (isValueChanged) reCalculate();
                    return kurtosisValue;
                }
                else
                {
                    return System.Double.NaN;
                }
            }
        }
        
        /// <summary>
        /// Event handler ketika nilai observasi berubah
        /// </summary>
        private void SeriesValues_Changed(object sender, EventArgs e)
        {            
            isValueChanged = true;
            OnChanged(System.EventArgs.Empty);
        }

        /// <summary>
        /// Kalkulasi ulang nilai mean, median,skewness, dll
        /// </summary>
        private void reCalculate()
        {
            //this.observations = this.seriesValues.Count;

            List<double> tmpList = new List<double>();
            //tmpList.AddRange(seriesValues.ToArray());

            foreach (double item in this.seriesValues)            
                if (!double.IsNaN(item)) tmpList.Add(item);
            
            tmpList.Sort();

            this.observations = tmpList.Count;

            minValue = tmpList[0];
            maxValue = tmpList[this.observations - 1];

            sumValue = 0;
            foreach (double elemen in tmpList)
                sumValue += elemen;

            meanValue = sumValue / tmpList.Count;

            medianValue = this.observations % 2 == 0 ?
                (tmpList[this.observations / 2 - 1] + tmpList[this.observations / 2]) / 2 :
                tmpList[this.observations / 2];

            switch (this.observations % 4)
            {
                case 0:
                    q1Value = (tmpList[this.observations / 4] + tmpList[this.observations / 4 - 1]) / 2;
                    q3Value = (tmpList[3 * this.observations / 4] + tmpList[3 * this.observations / 4 - 1]) / 2;
                    break;
                case 1:
                    q1Value = (tmpList[this.observations / 4] + tmpList[this.observations / 4 - 1]) / 2;
                    q3Value = (tmpList[3 * this.observations / 4] + tmpList[3 * this.observations / 4 + 1]) / 2;
                    break;
                case 2:
                    q1Value = tmpList[this.observations / 4];
                    q3Value = tmpList[3 * this.observations / 4];
                    break;
                case 3:
                    q1Value = tmpList[this.observations / 4];
                    q3Value = tmpList[3 * this.observations / 4];
                    break;
            }


            sumSquareDevValue = 0;
            foreach (double elemen in tmpList)
                sumSquareDevValue += Math.Pow(elemen - meanValue, 2);

            variansValue = sumSquareDevValue / (this.observations - 1);

            stDevValue = Math.Pow(variansValue, 0.5);

            skewnessValue = 3 * (meanValue - medianValue) / stDevValue;

            sum4DevValue = 0;
            foreach (double elemen in tmpList)
                sum4DevValue += Math.Pow(elemen - meanValue, 4);

            kurtosisValue = sum4DevValue / (this.observations * Math.Pow(variansValue, 2));

            isValueChanged = false;

        }

        #region override

        /// <summary>
        /// Nilai string yang mewakili objek
        /// </summary>
        /// <returns>String nama variabel</returns>
        public override string ToString()
        {
            return this.variableName;
        }

        #endregion


        #region ICloneable Members

        /// <summary>
        /// Mengkloning variabel
        /// </summary>
        /// <returns>variabel baru dengan nilai sama dengan variabel asal</returns>
        public object Clone()
        {
            SeriesVariable clone = new SeriesVariable(this.VariableName, this.VariableDescription, this.SeriesValues.Count);

            for (int i = 0; i < this.SeriesValues.Count; i++)
            {
                clone[i] = this[i];
            }

            return clone;
        }

        #endregion


        #region Event
        public event ChangedEventHandler Changed;

        protected virtual void OnChanged(System.EventArgs e)
        {
            if (Changed != null )
            {
                Changed(this, e);
            }
        }

        #endregion
    }
}
