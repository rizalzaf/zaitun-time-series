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

namespace zaitun.Data
{
    /// <summary>
    /// Kelas untuk mencari index suatu variabel dalam list
    /// berdasarkan nama variabel
    /// </summary>
    public static class VariableFinder
    {
        /// <summary>
        /// Variabel yang akan dicari
        /// </summary>
        private static SeriesVariable variableToFind;

        /// <summary>
        /// Mencari index variabel pada list
        /// </summary>
        /// <param name="variableCollection">list variabel</param>
        /// <param name="name">nama variabel</param>
        /// <returns>index</returns>
        public static int FindVariableIndex(SeriesVariables variableCollection, string name)
        {
            variableToFind = new SeriesVariable(name, "");
            System.Predicate<SeriesVariable> search = findVariablePredicate;

            return variableCollection.FindIndex(search);
        }

        /// <summary>
        /// Predicate untuk pencarian variabel
        /// </summary>
        /// <param name="search">variabel yang akan dicari</param>
        /// <returns>apakah nama variabel match</returns>
        private static bool findVariablePredicate(SeriesVariable search)
        {
            return search.VariableName.Equals(variableToFind.VariableName);
        }
    }
}