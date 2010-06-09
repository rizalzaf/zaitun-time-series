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
using AForge.Neuro;

namespace zaitun.NeuralNetwork
{
    /// <summary>
    /// Fungsi linear
    /// </summary>
    public class LinearFunction : IActivationFunction 
    {
        #region IActivationFunction Members

        /// <summary>
        /// Menghitung nilai fungsi
        /// </summary>
        /// <param name="x">input</param>
        /// <returns>nilai fungsi</returns>
        public double Function(double x)
        {
            return (x);
        }

        /// <summary>
        /// Menghitung nilai turunan fungsi
        /// </summary>
        /// <param name="x">input</param>
        /// <returns>nilai turunan fungsi</returns>
        public double Derivative(double x)
        {
            return (1.0);
        }

        /// <summary>
        /// Menghitung nilai turunan fungsi jika sudah 
        /// diketahui nilai fungsinya
        /// </summary>
        /// <param name="y">nilai fungsi</param>
        /// <returns>nilai turunan fungsi</returns>
        public double Derivative2(double y)
        {
            return (1.0);
        }

        #endregion

        /// <summary>
        /// Nilai string yang mewakili objek
        /// </summary>
        /// <returns>String yang mewakili objek</returns>
        public override string ToString()
        {
            return "Linear";
        }
    }
}
