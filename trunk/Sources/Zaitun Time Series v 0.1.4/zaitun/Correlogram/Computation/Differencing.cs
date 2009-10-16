using System;
using System.Collections.Generic;
using System.Text;

namespace zaitun.Correlogram
{
    /// <summary>
    /// Melakukan proses diferensi     
    /// </summary>
    public class Differencing
    {
        private Double[] dat;

        /// <summary>
        /// Melakukan proses diferensi     
        /// </summary>
        /// <param name="data"> data yang digunakan untuk analisis </param>
        /// <param name="diff"> tingkat proses diferensi </param>
        public Differencing(double[] data, int diff)
        {
            int n = data.Length;
            double[] diferr;
            diferr = new double[n - 1];
            this.dat = new double[n - diff];
            int k;


            for (int i = 0; i < diff; i++)
            {
                for (k = 0; k < n - 1; k++)
                {
                    diferr[k] = data[k + 1] - data[k];
                }
                for (k = 0; k < n - 1; k++)
                {
                    data[k] = diferr[k];
                }
            }



            for (int a = 0; a < n - diff; a++)
            {
                dat[a] = data[a];
            }

        }

        /// <summary>
        /// Mendapatkan nilai (data) setelah proses diferensi
        /// </summary>
        public Double[] Data
        {
            get { return dat; }
        }
    }



}