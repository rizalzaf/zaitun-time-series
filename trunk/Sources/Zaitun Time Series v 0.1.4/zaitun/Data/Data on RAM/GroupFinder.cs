using System;
using System.Collections.Generic;
using System.Text;

namespace zaitun.Data
{
    /// <summary>
    /// Variabel yang akan dicari
    /// </summary>
    public static class GroupFinder
    {
        /// <summary>
        /// Variabel yang akan dicari
        /// </summary>
        private static SeriesGroup groupToFind;

        /// <summary>
        /// Mencari index variabel pada list
        /// </summary>
        /// <param name="variableCollection">list variabel</param>
        /// <param name="name">nama variabel</param>
        /// <returns>index</returns>
        public static int FindGroupIndex(SeriesGroups groupCollection, string name)
        {
            SeriesVariables a = new SeriesVariables();
            groupToFind = new SeriesGroup(name, a);
            System.Predicate<SeriesGroup> search = findGroupPredicate;

            return groupCollection.FindIndex(search);
        }

        /// <summary>
        /// Predicate untuk pencarian variabel
        /// </summary>
        /// <param name="search">variabel yang akan dicari</param>
        /// <returns>apakah nama variabel match</returns>
        private static bool findGroupPredicate(SeriesGroup search)
        {
            return search.GroupName.Equals(groupToFind.GroupName);
        }
    }
}
