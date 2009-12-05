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
using System.Text;
using zaitun.Data;
using zaitun.MatrixVector;

namespace zaitun.MovingAverage
{
    /// <summary>
    /// Kelas untuk menghitung "Single Moving Average" (Rata-Rata Bergerak Tunggal)
    /// </summary>
    class SingleMovingAverage
    {
        private SeriesVariable variable;
        private Vector Y;
        private double[] smoothing1;
        private double[] predicted;
        private double[] residual;
        private int index, n, t;

        private double sse;
        private double mse;
        private double mae;
        private double mpe;
        private double mape;

        #region Constructor
        /// <summary>
        /// Constructor. Pemulusan dengan metode Rata-Rata Bergerak Tunggal
        /// </summary>
        /// <param name="variable">SeriesVariable. variable</param>
        /// <param name="maLength">Integer. MA Length</param>
        public SingleMovingAverage(SeriesVariable variable, int maLength)
        {
            this.variable = variable;
            Vector var = new Vector(this.variable.SeriesValuesNoNaN.ToArray());
            this.Y = new Vector(var.Tuples);
            for (int i = 0; i < Y.Tuples; i++)
                this.Y[i] = var[i];

            this.n = Y.Tuples;
            this.t = maLength;

            this.smoothing1 = new double[this.n];
            this.predicted = new double[this.n];
            this.residual = new double[this.n];

            this.Smoothing();
            this.ForecastingError();
        }

        /// <summary>
        /// Digunakan untuk menghitung SingleMA pada metode Double Moving Average
        /// Data yang akan dihitung dalam bentuk Vector
        /// </summary>
        /// <param name="Data">ArrayDouble. Data</param>
        ///// <param name="maLength">Integer. MA Length</param>
        public SingleMovingAverage(Vector Data, int maLength)
        {
            this.Y = new Vector(Data.Tuples);
            for (int i = 0; i < Data.Tuples; i++)
                this.Y[i] = Data[i];

            this.n = Y.Tuples;
            this.t = maLength;

            this.smoothing1 = new double[this.n];
            this.predicted = new double[this.n];
            this.residual = new double[this.n];

            this.Smoothing();
        }
        #endregion

        #region Function Member
        /// <summary>
        /// Fungsi untuk menghitung nilai rata-rata
        /// Rata-rata dihitung mulai dari angka index terakhir hingga t periode ke belakang
        /// </summary>
        /// <returns>Double. nilai rata-rata</returns>
        private double Average()
        {
            double jumlah = 0;
            double value;

            //Menghitung rata-rata
            for (int i = this.index; i > this.index - this.t; --i)
                jumlah = jumlah + this.Y[i];
            value = jumlah / this.t;

            return (value);
        }
        #endregion

        #region Procedure Member
        /// <summary>
        /// Prosedur untuk menghitung nilai pemulusan, prediksi, dan residual
        /// </summary>
        private void Smoothing()
        {
            for (this.index = t - 1; this.index < n; ++this.index)
            {
                //Menghitung rata-rata bergerak periode ke-index
                this.smoothing1[this.index] = this.Average();

                //Nilai kecocokan/fitted value
                //Prediksi ke-index adalah nilai rata-rata bergerak periode sebelumnya
                this.predicted[this.index] = this.smoothing1[this.index - 1];

                //Residual adalah selisih dari data aktual dan nilai kecocokan
                this.residual[this.index] = this.Y[this.index] - this.predicted[this.index];
            }

            //inisialisasi nilai null
            for (int i = 0; i < t - 1; i++)
                this.smoothing1[i] = double.NaN;
            for (int i = 0; i < t; i++)
            {
                this.predicted[i] = double.NaN;
                this.residual[i] = double.NaN;
            }
        }

        /// <summary>
        /// Prosedur untuk menghitung nilai error hasil prediksi
        /// </summary>
        private void ForecastingError()
        {
            MeasuringForecastingError mfe = new MeasuringForecastingError(this.Y, this.residual, this.t, this.n);
            this.sse = mfe.SSE;
            this.mse = mfe.MSE;
            this.mae = mfe.MAE;
            this.mpe = mfe.MPE;
            this.mape = mfe.MAPE;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Mendapatkan nilai banyaknya observasi
        /// </summary>
        public int IncludedObservations
        {
            get { return this.n; }
        }

        /// <summary>
        /// Mendapatkan nilai pemulusan tunggal
        /// </summary>
        public double[] Smoothed1
        {
            get { return this.smoothing1; }
        }

        /// <summary>
        /// Mendapatkan nilai prediksi
        /// </summary>
        public double[] Predicted
        {
            get { return this.predicted; }
        }

        /// <summary>
        /// Mendapatkan nilai sisaan
        /// </summary>
        public double[] Residual
        {
            get { return this.residual; }
        }

        /// <summary>
        /// Mendapatkan nilai SSE
        /// </summary>
        public double SSE
        {
            get { return this.sse; }
        }

        /// <summary>
        /// Mendapatkan nilai MSE
        /// </summary>
        public double MSE
        {
            get { return this.mse; }
        }

        /// <summary>
        /// Mendapatkan nilai MAE
        /// </summary>
        public double MAE
        {
            get { return this.mae; }
        }

        /// <summary>
        /// Mendapatkan nilai MPE
        /// </summary>
        public double MPE
        {
            get { return this.mpe; }
        }

        /// <summary>
        /// Mendapatkan nilai MAPE
        /// </summary>
        public double MAPE
        {
            get { return this.mape; }
        }
        #endregion

        #region Forecast
        /// <summary>
        /// Menghitung peramalan
        /// </summary>
        /// <param name="step">Integer. Banyaknya periode yang akan diprediksi</param>
        /// <returns>ArrayDouble. Hasil Peramalan</returns>
        public double[] Forecast(int step)
        {
            double[] result = new double[step];

            for (int i = 0; i < step; ++i)
                result[i] = this.smoothing1[n - 1];

            return result;
        }

        //public double[] Forecast(int step)
        //{
        //    double[] result = new double[step];

        //    double[] movingData = new double[this.t];
        //    for (int i = 0; i < this.t; i++)
        //    {
        //        movingData[t - i - 1] = this.Y[this.n - i - 1];
        //    }

        //    for (int i = 0; i < step; i++)
        //    {
        //        result[i] = this.averageForecast(movingData);

        //        for (int j = 0; j < this.t - 1; j++)
        //            movingData[j] = movingData[j + 1];
        //        movingData[this.t - 1] = result[i];
        //    }

        //    return result;
        //}

        //private double averageForecast(double[] movingData)
        //{
        //    double sum=0.0;
        //    for (int i = 0; i < movingData.Length; i++)
        //        sum += movingData[i];

        //    return sum / movingData.Length;
        //}
        #endregion
    }
}
