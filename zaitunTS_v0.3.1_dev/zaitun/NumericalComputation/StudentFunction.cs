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

namespace zaitun.NumericalComputation
{
    /// <summary>
    /// Class that provides methods to
    /// compute Students't Function
    /// (c) anasikova 2009
    /// </summary>
    public class StudentFunction : BaseFunction
    {
        // the number of degree of freedom
        private double k;
        /// <summary>
        /// Constructor of StudentFunction class
        /// </summary>
        /// <param name="k">double. k is number degree of freedom</param>
        public StudentFunction(int k)
        {
            this.k = k;
        }
        /// <summary>
        /// This function return the value of StudentFunction for
        /// given x
        /// </summary>
        /// <param name="x">double. x</param>
        /// <returns>
        /// the value of StudentFunction for given x
        /// </returns>
        public override double Value(double x)
        {
            double result, GpG;
            if (this.k <= 0) return double.NaN;
            // if k is even number
            if (this.k % 2 == 0)
            {
                GpG = Math.Sqrt(Math.PI) / 2;
                for (int i = 3; i < this.k; i += 2)
                    GpG *= (i / (double)(i - 1));
            }
            else // if k is odd number
            {
                GpG = 2 / Math.Sqrt(Math.PI);
                for (int i = 4; i < this.k; i += 2)
                    GpG *= ((double)(i) / (i - 1));
            }
            result = (GpG / Math.Sqrt((this.k * Math.PI))) * 
                Math.Pow((1.0 + (x * x / this.k)), -0.5 * (this.k + 1));
            return result;
        }
    }
}
