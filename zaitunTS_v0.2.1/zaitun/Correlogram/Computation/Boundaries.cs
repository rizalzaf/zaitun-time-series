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
using zaitun.MatrixVector;

namespace zaitun.Correlogram
{
    /// <summary>
    /// Kelas untuk menghitung nilai batas atas dan bawah     
    /// </summary>
    class Boundaries
    {
        private double[] acfup;
        private double[] acfdown;

        private double[] pacfup;
        private double[] pacfdown;

        private bool whiteNoiseAcf = true;


        /// <summary>
        /// Kelas untuk menghitung nilai batas atas dan bawah     
        /// </summary>
        /// / // <param name="data"> data yang digunakan untuk analisis </param>
        /// <param name="lag"> Jumlah lag yang di include kan</param>
        
        public Boundaries(double[] data, int lag, bool whiteNoiseACf)
        {
            double[] t = new double[] {12.706, 4.303, 3.182, 2.776, 2.571,
             2.447, 2.365, 2.306, 2.262, 2.228, 2.201, 2.179, 2.160, 2.145, 2.131, 2.120, 2.110,
             2.101, 2.093, 2.086, 2.080, 2.074, 2.069, 2.064, 2.060, 2.056, 2.052, 2.048, 2.045, 1.96};
                       
            int n = data.Length;
            this.whiteNoiseAcf = whiteNoiseACf;

            this.acfup = new double[lag];
            this.acfdown = new double[lag];
            this.pacfup = new double[lag];
            this.pacfdown = new double[lag];


            // calculate ACF
            if (!this.whiteNoiseAcf)
            {
                double seacf;                
                double se2acf;
                Vector A = new Vector(data, data.Length);
                LjungBoxQTest k = new LjungBoxQTest(A, lag);

                //Nilai batas atas dan bawah berdasar buku "Peramalan Bisnis" by John E. Hanke 
                if (n < 30)
                {
                    double sumacf = 0;
                    for (int a = 0; a < lag; a++)
                    {                        
                        se2acf = (1 + 2 * sumacf) / n;

                        seacf = Math.Sqrt(se2acf);

                        acfup[a] = t[n - 2] * seacf;
                        acfdown[a] = -1 * t[n - 2] * seacf;

                        sumacf += Math.Pow(k.ACF[a], 2);
                    }

                    // previous way
                    //for (int a = 0; a < lag; a++)
                    //{
                    //    double sumacf = 0;

                    //    for (int j = 0; j < a; j++)
                    //    {
                    //        sumacf += Math.Pow(k.ACF[j], 2);
                    //    }
                    //    se2acf = (1 + 2 * sumacf) / n;

                    //    seacf = Math.Sqrt(se2acf);

                    //    acfup[a] = t[n - 2] * seacf;
                    //    acfdown[a] = -1 * t[n - 2] * seacf;
                    //}
                }
                else
                {
                    double sumacf = 0;
                    for (int a = 0; a < lag; a++)
                    {                        
                        se2acf = (1 + 2 * sumacf) / n;

                        seacf = Math.Sqrt(se2acf);

                        acfup[a] = 1.96 * seacf;
                        acfdown[a] = -1 * 1.96 * seacf;

                        sumacf += Math.Pow(k.ACF[a], 2);
                    }

                    // previous way
                    //for (int a = 0; a < lag; a++)
                    //{
                    //    double sumacf = 0;

                    //    for (int j = 0; j < a; j++)
                    //    {
                    //        sumacf += Math.Pow(k.ACF[j], 2);
                    //    }
                    //    se2acf = (1 + 2 * sumacf) / n;

                    //    seacf = Math.Sqrt(se2acf);

                    //    acfup[a] = 1.96 * seacf;
                    //    acfdown[a] = -1 * 1.96 * seacf;
                    //}
                }
            }
            else
            {
                //white noise

                double seacf;
                seacf = Math.Sqrt((double)1 / n);
                for (int i = 0; i < lag; i++)
                {
                    acfup[i] = 1.96 * seacf;
                    acfdown[i] = -1 * 1.96 * seacf;
                }
            }
            

            //Penghitungan nilai batas atas dan bawah berdasar buku Gujarati (white noise)
            // calculate PACF
            double sepacf;
            sepacf = Math.Sqrt((double)1 / n);
            for (int i = 0; i < lag; i++)
            {
                pacfup[i] = 1.96 * sepacf;
                pacfdown[i] = -1 * 1.96 * sepacf;
            }
            

        }

        /// <summary>
        /// Mendapatkan nilai batas atas ACF
        /// </summary>
        public Double[] ACFUp
        {
            get { return acfup; }
        }


        /// <summary>
        /// Mendapatkan nilai batas bawah ACF
        /// </summary>
        public Double[] ACFDown
        {
            get { return acfdown; }
        }

        /// <summary>
        /// Mendapatkan nilai batas atas PACF
        /// </summary>
        public Double[] PACFUp
        {
            get { return pacfup; }
        }


        /// <summary>
        /// Mendapatkan nilai batas bawah PACF
        /// </summary>
        public Double[] PACFDown
        {
            get { return pacfdown; }
        }

        public bool WhiteNoiseAcf
        {
            get { return this.whiteNoiseAcf; }
            set { this.whiteNoiseAcf = value; }
        }

    }


}