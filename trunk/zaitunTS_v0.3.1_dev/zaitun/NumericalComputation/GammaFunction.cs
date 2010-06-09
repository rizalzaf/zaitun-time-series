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
    /// compute Gamma Function.
    /// This gamma function only cover for x is integer or
    /// (x-0.5) is integer
    /// (c) anasikova 2009
    /// </summary>
    public class GammaFunction : BaseFunction
    {
        public GammaFunction()
        {
        }
        /// <summary>
        /// This function return the value of gamma function 
        /// where x > 0
        /// </summary>
        /// <param name="x">double. x</param>
        /// <returns>
        /// The value of GammaFunction for given x
        /// </returns>
        public override double Value(double x)
        {
            if (x == 1.0) return 1.0;
            if (x == 0.5) return Math.Sqrt(Math.PI);
            // for n=0,1,2,... 
            // gamma(n + 1/2) = 1*3*5*(2n-1)*Sqrt(PI)/2^n
            if (x - Math.Sign(x) == 0.5) 
                return ((2.0 * (x - 0.5) - 1.0) / 2.0) * Value(x - 1.0);
            // gamma(n+1) = n!
            else return (x - 1.0) * Value(x - 1.0);
        }
    }
}
