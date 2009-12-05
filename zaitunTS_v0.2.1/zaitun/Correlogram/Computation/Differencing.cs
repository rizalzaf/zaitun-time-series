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