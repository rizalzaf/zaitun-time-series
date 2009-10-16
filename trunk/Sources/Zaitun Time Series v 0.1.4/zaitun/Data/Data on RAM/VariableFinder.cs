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
