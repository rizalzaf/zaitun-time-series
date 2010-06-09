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
using zaitun.Distribution;

namespace zaitun.Correlogram
{
    /// <summary>
    /// Kelas untuk menghitung nilai ACF
    /// Kelas untuk menentukan nilai LjungBox (Q) Statistik
    /// Kelas untuk menghitung nilai PACF
    /// </summary>
    public class LjungBoxQTest
    {
        private Vector lBox, acf, pValue, se, pValue1;
        private Matrix pacf;
        private double sumY, yBar;
        private int lag,n;
        //private Matrix x;
        private Vector y;

        /// <summary>
        /// Constructor. Menghitung nilai LjungBox Q Stat.        
        /// </summary>
        /// <param name="Y">Vektor. Vektor data yang akan dicari 
        /// nilai LjungBox Q Statistiknya. </param>
        /// <param name="Lag">Int. Jumlah lag yang di include kan</param>
        public LjungBoxQTest(Vector Y, int Lag)
        {            
            double[] ljung = new double[Lag];
            double[] acfValue = new double[Lag];
            double sekuadrat;
            double sumacf = 0;
            double[] acfD;

            this.acf = new Vector(Lag);
            this.pacf = new Matrix (Lag,Lag);
            this.se = new Vector(Lag);
            this.lBox = new Vector(Lag);
            this.pValue = new Vector(Lag);
            this.pValue1 = new Vector(Lag);
           
            this.n = Y.Tuples;            
            this.lag = Lag;            
            this.y = Y.Copy();            
            this.sumY = y.GetSumData();
            this.yBar = sumY / n;


            // Penghitungan nilai ACF

            for (int k = 0; k < lag; k++)
            {
                acf[k] = getRho(k+1);
            }

            double sumRho = 0;
            for (int i = 1; i <= lag; i++)
            {               
                sumRho += Math.Pow(acf[i - 1], 2) / (n - i);                

                lBox[i - 1] = n * (n + 2) * sumRho;                

                pValue1[i - 1] = ChiSquare.PValue(lBox[i - 1], i);
                if (pValue1[i - 1] < 0) pValue[i - 1] = 0;
                else pValue[i - 1] = pValue1[i - 1];
            }

            //previous way
            //for (int i = 1; i <= lag; i++)
            //{
            //    double sumRho = 0;
            //    for (int k = 1; k <= i; k++)
            //    {
            //        sumRho += Math.Pow(acf[k - 1], 2) / (n - k);
            //    }

            //    lBox[i - 1] = n * (n + 2) * sumRho;
            //    ChiSquare chi = new ChiSquare(i);

            //    pValue1[i - 1] = chi.PValue(lBox[i - 1]);
            //    if (pValue1[i - 1] < 0) pValue[i - 1] = 0;
            //    else pValue[i - 1] = pValue1[i - 1];
            //}
            
            //Penghitungan nilai PACF

            pacf[0, 0] = acf[0];

            for (int i = 1; i < lag; i++)
            {
                double sumatas = 0;
                double sumbawah = 0;

                for (int k = 0; k < i; k++)
                {
                    sumatas += pacf[i - 1, k] * acf[(i - k) - 1];
                    sumbawah += pacf[i - 1, k] * acf[k];
                }

                pacf[i, i] = (acf[i] - sumatas) / (1 - sumbawah);

                for (int j = 0; j < i; j++)
                {
                    pacf[i, j] = pacf[i - 1, j] - (pacf[i, i] * pacf[i - 1, (i - j) - 1]);
                }
            }

            // previous way
            //for (int i = 1; i < lag; i++)
            //{
            //    for (int j = 0; j < i; j++)
            //    {
            //        double sumatas = 0;
            //        double sumbawah = 0;

            //        for (int k = 0; k < i; k++)
            //        {
            //            sumatas += pacf[i - 1, k] * acf[(i - k) - 1];
            //            sumbawah += pacf[i - 1, k] * acf[k];
            //        }

            //        pacf[i, i] = (acf[i] - sumatas) / (1 - sumbawah);

            //        pacf[i, j] = pacf[i - 1, j] - (pacf[i, i] * pacf[i - 1, (i - j) - 1]);

            //    }
            //}            

            acfD = acf.GetData();

            sumacf = 0;
            for (int i = 0; i < lag; i++)
            {
                sekuadrat = (1 + 2 * sumacf) / y.Tuples;
                se[i] = Math.Sqrt(sekuadrat);

                sumacf += Math.Pow(acfD[i], 2);
            }

            // previous way            
            //for (int i = 0; i < lag; i++)
            //{
            //    sumacf = 0;
            //    for (int j = 0; j < i; j++)
            //    {
            //        sumacf += Math.Pow(acfD[j], 2);
            //    }
            //    sekuadrat = (1 + 2 * sumacf) / y.Tuples;
            //    se[i] = Math.Sqrt(sekuadrat);
            //}
        }

        /// <summary>
        /// Mendapatkan nilai 
        /// </summary>
        /// <param name="lag"></param>
        /// <returns></returns>
        private double getYk(int lag)
        {
            double Yk = 0;
            for (int i = 0; i < y.Tuples - lag; i++)
            {
                Yk += (y[i] - yBar) * (y[i + lag] - yBar);
            }
            Yk = Yk / y.Tuples;
            return Yk;
        }

        private double getYo(int lag)
        {
            double Yo = 0;
            for (int i = 0; i < y.Tuples; i++)
            {
                Yo += Math.Pow((y[i] - yBar), 2);
            }
            Yo = Yo / y.Tuples;
            return Yo;
        }

        private double getRho(int lag)
        {
            double rho, Yk, Yo;
            Yk = getYk(lag);
            Yo = getYo(lag);
            rho = Yk / Yo;
            return rho;
        }
        
        public Vector SE
        {
            get { return se; }
        }

        /// <summary>
        /// Mendapatkan nilai LjungBox (Q) Statistik
        /// </summary>
        public Vector LB
        {
            get { return lBox; }
        }

        /// <summary>
        /// Mendapatkan nilai ACF
        /// </summary>
        public Vector ACF
        {
            get { return acf; }
        }


        /// <summary>
        /// Mendapatkan nilai PACF
        /// </summary>
        public Matrix PACF
        {
            get { return pacf; }
        }

        /// <summary>
        /// Mendapatkan Nilai Lag
        /// </summary>
        public int Lag
        {
            get { return lag; }
        }

        /// <summary>
        /// Mendapatkan nilai PValue dengan menggunakan distribusi ChiSquare
        /// </summary>
        public Vector PValue
        {
            get { return pValue; }
        }
    }
}
