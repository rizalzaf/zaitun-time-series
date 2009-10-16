using System;
using System.Collections.Generic;
using System.Text;
using zaitun.Data;
using zaitun.MatrixVector;


namespace zaitun.Decomposition
{
    /// <summary>
    /// Kelas menghitung nilai keakuratan peramalan
    /// </summary>
    class MeasuringForecastingError
    {
        Vector y;
        double[] e;
        private double sse;
        private double mse;
        private double mae;
        private double mpe;
        private double mape;
        private int n, endIdx, startIdx;

        #region Constructor
        /// <summary>
        /// Constructor. Menghitung nilai keakuratan peramalan
        /// </summary>
        /// <param name="dataY">Vector. data actual</param>
        /// <param name="residual">ArrayDouble. residual</param>
        /// <param name="startIdx">Integer. data awal mulai penghitungan</param>
        /// <param name="endIdx">Integer. banyaknya jumlah observasi</param>
        public MeasuringForecastingError(Vector dataY, double[] residual, int startIdx, int endIdx)
        {
            this.y = dataY;
            this.e = residual;
            this.startIdx = startIdx;
            this.endIdx = endIdx;
            this.n = endIdx - startIdx;

            this.CalcSSE();
            this.CalcMSE();
            this.CalcMAE();
            this.CalcMPE();
            this.CalcMAPE();
        }
        #endregion

        #region Procedure Member
        /// <summary>
        /// Prosedur untuk menghitung SSE
        /// Jumlah kuadrat residual
        /// </summary>
        private void CalcSSE()
        {
            double suku = 0;
            for (int i = this.startIdx; i < this.endIdx; ++i)
                suku += (Math.Pow(this.e[i], 2));
            this.sse = suku;
        }

        /// <summary>
        /// Prosedur untuk menghitung MSE
        /// Rata-rata kuadrat residual
        /// </summary>
        private void CalcMSE()
        {
            this.mse = this.sse / n;
        }

        /// <summary>
        /// Prosedur untuk menghitung MAE
        /// rata-rata absolut residual
        /// </summary>
        private void CalcMAE()
        {
            double suku = 0;
            for (int i = this.startIdx; i < this.endIdx; ++i)
                suku += Math.Abs(this.e[i]);
            this.mae = suku / this.n;
        }

        /// <summary>
        /// Prosedur untuk menghitung MPE
        /// Persentase rata-rata rasio residual dan aktual
        /// </summary>
        private void CalcMPE()
        {
            double suku = 0;
            for (int i = this.startIdx; i < this.endIdx; ++i)
                suku += (this.e[i] / this.y[i]);
            this.mpe = (suku / this.n) * 100;
        }

        /// <summary>
        /// Prosedur untuk menghitung MAPE
        /// Persentase rata-rata absolut rasidual dan aktual 
        /// </summary>
        private void CalcMAPE()
        {
            double suku = 0;
            for (int i = this.startIdx; i < this.endIdx; ++i)
                suku += Math.Abs(this.e[i] / this.y[i]);
            this.mape = (suku / this.n) * 100;
        }
        #endregion

        #region Properties
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
        /// Mendapatkan nilai MAD
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
    }
}
