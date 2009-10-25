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
    /// Class untuk mendapatkan nilai probability dari Distribusi Normal.
    /// </summary>
    public class Normal
    {   
        /// <summary>
        /// Nilai mean(rata-rata) dan var(varians) sebagai nilai input 
        /// pada persamaan Normal.
        /// </summary>   
        private double mean, var;
        
        /// <summary>
        /// Constructor-->Statement-statement yang pertama kali akan di eksekusi 
        /// ketika object di inisialisasi.
        /// </summary>
        /// <param name="mean">Double. Nilai input rata-rata</param>
        /// <param name="var">Double. Nilai input varians</param>
        public Normal(double mean, double var)
        {
            this.mean = mean;
            this.var = var;            
        }

        /// <summary>
        /// Mendapatkan nilai probability(PValue) dari distribusi normal,
        /// menggunakan kaidah setengah tabel.
        /// </summary>
        /// <param name="X">Doubel. Nilai input X (titik batas sunbu X pada tabel)</param>
        /// <returns>Double. Mengembalikan nilai Probability dari batas sumbu X</returns>
        public double HalfValue(double X)
        {
            return (0.5 - integration(0, X));
        }

        /// <summary>
        /// Mendapatkan nilai probability(PValue) dari distribusi normal,
        /// menggunakan kaidah satu tabel penuh.
        /// </summary>
        /// <param name="X">Doubel. Nilai input X (titik batas sunbu X pada tabel)</param>
        /// <returns>Double. Mengembalikan nilai Probability dari batas sumbu X</returns>
        public double FullValue(double X)
        {
            return (2 * (0.5 - integration(0 , X)));            
        }

        /// <summary>
        /// Menghitung nilai dari Persamaan Normal dengan input nilai X.
        /// </summary>
        /// <param name="x">Double. Nilai input untuk persamaan</param>
        /// <returns>Double. Hasil dari penghitungan nilai dari persamaan normal untuk nilai X</returns>
        private double normalEquation(double x)
        {           
            double normal, power;
            power = -0.5 * (Math.Pow(((x - mean) / var), 2));
            normal = (1 / (var * (Math.Sqrt(2 * Math.PI)))) * Math.Pow(Math.E, power);
            return normal;
        }
        
        /// <summary>
        /// Fungsi untuk menghitung nilai integral dari batas bawah sampai batas atas
        /// dari Persamaan Normal.
        /// Menggunakan metode Simpson.
        /// </summary>
        /// <param name="lowerBound">Double. Nilai batas bawah</param>
        /// <param name="upperBound">Double. Nilai batas atas</param>
        /// <returns>Double. Nilai hasil integral</returns>
        private double integration(double lowerBound, double upperBound)
        {            
            double XN_1, int1, sum1,x2j_1, x2j, h;
            int interval = 10;
            h = (upperBound - lowerBound) / interval;
            XN_1 = lowerBound + (interval - 1) * h;
            int1 = normalEquation(lowerBound) + 4 * normalEquation(XN_1) + normalEquation(upperBound);
            sum1 = 0;
            for (int j = 1; j <= (interval / 2 - 1); j++)
            {
                x2j_1 = lowerBound + (2 * j - 1) * h;
                x2j = lowerBound + (2 * j) * h;
                sum1 = sum1 + 2 * normalEquation(x2j_1) + normalEquation(x2j);
            }
            
            double ret = (h / 3 * (int1 + 2 * sum1));
            if (ret >= 0.5) ret = 0.5; 
            return ret;
        }

        /// <summary>
        /// Mendapatkan nilai batas sumbu X pada alpha tertentu dari Distribusi Normal.
        /// </summary>
        /// <param name="alpha">Double. Nilai nilai peluang (probability value)</param>
        /// <returns>Double. Nilai batas X</returns>
        public double Z(double alpha)
        {
            double value,i;            
            Normal Normal_2 = new Normal(0, 1);
            for (i = 0; i <= 3.09; i += 0.01)            
            {
                value = Normal_2.HalfValue(i);
                if (value >= alpha)break;
            }   
            return i;                  
        }
    }
}