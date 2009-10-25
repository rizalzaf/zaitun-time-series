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
using zaitun.Data;
using zaitun.MatrixVector;
using zaitun.Distribution;

namespace zaftime.ARCH
{
    /// <summary>
    /// Kelas abstrak yang merupakan Base Class (kelas induk) pada setiap class untuk suatu fungsi (persamaan).
    /// Berisi fungsi abstrak Function yang akan digunakan pada setiap fungsi turunnnya sesuai fungsi masing-masing, 
    /// serta fungsi virtual Gradient yang akan mengeksekusi turunan pertama dari fungsinya
    /// </summary>
    public abstract class BaseFunction
    {
        /// <summary>
        /// Fungsi Abstrak yang akan digunkakan pada setiap kelas turunannya sesuai fungsi masing-masing
        /// </summary>
        /// <param name="input">Vector. Vektor parameter yang dimasukkan</param>
        /// <returns>double. hasil penghitungan fungsi sesuai nilai masukkannya</returns>
        public abstract double Function(Vector input);        

        /// <summary>
        /// Fungsi Virtual unutk mendapatkan turunan pertama pada fungsi 
        /// </summary>
        /// <param name="input">Vector. Vector parameter yang dimasukkan</param>
        /// <returns>double. hasil penghitungan fungsi sesuai nilai masukkannya</returns>
        public virtual Vector Gradient(Vector input)
        {
            Vector result = new Vector(input.Tuples);
            Vector vh = new Vector(input.Tuples);
            double h = 0.000001;

            for (int i = 0; i < input.Tuples; i++)
            {
                vh.InitializeAllValue(0);
                vh[i] = h;

                result[i] = (this.Function(input + vh) - this.Function(input)) / h;
            }

            return result;
        }
    }
}
