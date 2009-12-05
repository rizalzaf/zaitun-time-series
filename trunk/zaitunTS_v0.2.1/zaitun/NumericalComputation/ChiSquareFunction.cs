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
    /// compute ChiSquare Function
    /// (c) anasikova 2009
    /// </summary>
    public class ChiSquareFunction : BaseFunction
    {
        // the number of degree of freedom
        private int k;
        /// <summary>
        /// Constructor of ChiSquareFunction class
        /// </summary>
        /// <param name="k">double. k is number degree of freedom</param>
        public ChiSquareFunction(int k)
        {
            this.k = k;
        }
        /// <summary>
        /// This function return the value of this ChiSquareFunction for given x
        /// </summary>
        /// <param name="x">double. x</param>
        /// <returns>
        /// the value of this ChiSquareFunction for given x
        /// </returns>
        public override double  Value(double x)
        {
            double result;
            GammaFunction function = new GammaFunction();
            result = 1.0 / (Math.Pow(2.0, 0.5 * this.k) * function.Value(0.5 * this.k));
            result *= Math.Exp(-0.5 * x);
            result *= Math.Pow(x, 0.5 * this.k - 1.0);
            return result;
        }
    }
}
