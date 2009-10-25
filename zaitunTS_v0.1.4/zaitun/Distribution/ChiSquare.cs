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
using System.Text;

namespace zaitun.Distribution
{
    /// <summary>
    /// Class untuk mendapatkan nilai probability dari Distribusi ChiSquare.
    /// </summary>
    public class ChiSquare
    {
        /// <summary>
        /// DF = nilai degree of Freedom(derajat Bebas)
        /// x = nilai batas sumbu X dari tabel distribusi ChiSquare
        /// pValue = nilai peluang(probability) dari distribusi ChiSquare pada batas sumbu X
        /// </summary>
        private double df;        

        /// <summary>
        /// Constructor-->Statement-statement yang pertama kali akan di eksekusi
        /// ketika object di inisialisasi.
        /// Menghitung nilai pValue ChiSquare
        /// </summary>
        /// <param name="DF">Double. Nilai Degree of Freedom (Derajat Bebas)</param>
        public ChiSquare(double df)
        {
            this.df = df;
        }

        /// <summary>
        /// Mendapatkan nilai Probability(PValue)
        /// </summary>
        /// <param name="X">Double. Batas X</param>
        /// <returns>Double. Nilai PValue</returns>
        public double PValue(double X)
        {
            if (df == 1)
            {
                double result;

                if (X >= 0.00001)
                    result = (1 - (0.0252271 + integration(0.001, X))); //CDF 0.001 = 0.0252271
                else if (X >= 0.000001)
                    result = (1 - (0.00797871 + integration(0.0001, X))); //CDF 0.0001 = 0.00797871
                else
                {
                    //interpolate
                    double val = X;
                    int i = 0;
                    while (val < 0.0001)
                    {
                        val *= 100;
                        i++;
                    }
                    double cdf;                    
                    if (val >= 0.001)
                    {
                        cdf = (0.0252271 + integration(0.001, val)) / (Math.Pow(10, i));
                    }
                    else
                    {
                        cdf = (0.00797871 + integration(0.0001, val)) / (Math.Pow(10, i));
                    }
                                        
                    result = (1 - cdf);
                }

                return result;
            }
            else
            {
                return (1 - integration(0, X));
            }                  
        }

        /// <summary>
        /// Fungsi untuk menghitung nilai Gamma r.
        /// </summary>
        /// <param name="r">Double. Nilai yang dicari</param>
        /// <returns>Double. Nilai Gamma(r)</returns>
        private double recGamma(double r)
        {
            if (r == 1) return 1;
            else if (r == 0) return 1;
            else if (r == 0.5) return Math.Sqrt(Math.PI);
            else if (r < 0) return recGamma(r + 1) / r;
            else return (r - 1) * recGamma(r - 1);
        }

        /// <summary>
        /// Metode untuk menghitung nilai dari persamaan Chi Square pada nilai x
        /// </summary>
        /// <param name="x">Double. Nilai X</param>
        /// <returns>Double. Hasil Penghitungan dari Persamaan</returns>
        private double chiSquareEquation(double x)
        {
            double result, rG;

            rG = recGamma(df / 2);

            result = ((1 / (Math.Pow(2, df / 2) * rG)) * (Math.Pow(x, (df / 2) - 1) * Math.Pow(Math.E, -x / 2)));
            //if (df == 1 && x == 0)
            //{
            //    result = ((1 / (Math.Pow(2, df / 2) * rG)) * 0 * Math.Pow(Math.E, -x / 2));
            //}
            //else
            //{
            //    result = ((1 / (Math.Pow(2, df / 2) * rG)) * (Math.Pow(x, (df / 2) - 1) * Math.Pow(Math.E, -x / 2)));
            //}
            return result;
        }

        /// <summary>
        /// Fungsi untuk menghitung nilai integral dari batas bawah sampai batas atas
        /// dari Persamaan ChiSquare.
        /// Menggunakan metode Simpson.
        /// </summary>
        /// <param name="lowerBound">Double. Batas Bawah</param>
        /// <param name="upperBound">Double. Batas Atas</param>
        /// <returns>Double. Hasil Penghitungan Integral</returns>
        private double integration(double lowerBound, double upperBound)
        {
            double XN_1, int1, sum1, x2j_1, x2j, h,result;
            int interval = 10000;
            h = (upperBound - lowerBound) / interval;
            XN_1 = lowerBound + (interval - 1) * h;
            int1 = chiSquareEquation(lowerBound) + 4 * chiSquareEquation(XN_1) + chiSquareEquation(upperBound);
            sum1 = 0;
            for (int j = 1; j <= (interval / 2 - 1); j++)
            {
                x2j_1 = lowerBound + (2 * j - 1) * h;
                x2j = lowerBound + (2 * j) * h;
                sum1 = sum1 + 2 * chiSquareEquation(x2j_1) + chiSquareEquation(x2j);
            }
            result = ((h / 3 * (int1 + 2 * sum1)));
            if (result >= 1) result = 1;
            return result;
        }
        
        /// <summary>
        /// Mendapatkan nilai X --> nilai batas sumbu X pada tabel distribusi ChiSquare
        /// </summary>
        public double X
        {
            get { return X; }
        }

        /// <summary>
        /// Mendapatkan nilai DF - Degree of Freedom - atau Derajat Bebas. 
        /// </summary>
        public double DF
        {
            get { return df; }
        }

    }
}