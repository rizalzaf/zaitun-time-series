using System;
using System.Collections.Generic;
using System.Text;

namespace zaitun.Data
{
    /// <summary>
    /// Kelas kumpulan (list) dari group 
    /// turunan dari kelas ListWithOnChanged
    /// </summary>
    public class SeriesGroups : ListWithOnChanged<SeriesGroup>
    {
        /// <summary>
        /// Apakah group baru duplikat
        /// </summary>
        /// <param name="item">group baru yang dimaksud</param>
        /// <returns>Apakah nama group baru sudah ada dipakai oleh group
        /// lain dalam list</returns>
        private bool isDuplicateName(SeriesGroup item)
        {
            bool b = false;
            foreach (SeriesGroup group in Inner)
            {
                // non case sensitive
                if (group.GroupName.ToLower() == item.GroupName.ToLower())
                {
                    b = true;
                    break;
                }
            }
            return b;
        }

        /// <summary>
        /// Apakah suatu kumpulan group mempunyai group duplikat
        /// </summary>
        /// <param name="item">kumpulan group dimaksud</param>
        /// <returns>Apakah ada nama group dalam suatu kumpulan group 
        /// sudah ada dipakai oleh group
        /// lain dalam list</returns>
        private bool isEnumerableDuplicateName(IEnumerable<SeriesGroup> item)
        {
            bool b = false;
            foreach (SeriesGroup s in item)
            {
                foreach (SeriesGroup var in Inner)
                {
                    // non case sensitive
                    if (var.GroupName.ToLower() == s.GroupName.ToLower())
                    {
                        b = true;
                        break;
                    }
                }
                if (!b) break;
            }
            return b;
        }

        /// <summary>
        /// Menambah group baru kedalm list
        /// </summary>
        /// <param name="item">group baru</param>
        public override void Add(SeriesGroup item)
        {
            if (isDuplicateName(item))
            {
                throw new DuplicateGroupException();
            }
            else
            {
                base.Add(item);
                item.Changed += new ChangedEventHandler(OnChanged);
            }
        }

        /// <summary>
        /// Menambah kumpulan group ke list
        /// </summary>
        /// <param name="stuff">kumpulan group</param>
        public override void AddRange(IEnumerable<SeriesGroup> stuff)
        {
            if (isEnumerableDuplicateName(stuff))
            {
                throw new DuplicateGroupException();
            }
            else
            {
                base.AddRange(stuff);
                foreach (SeriesGroup item in stuff)
                {
                    item.Changed += new ChangedEventHandler(OnChanged);
                }
            }
        }

        /// <summary>
        /// Menyisipkan group baru ke list
        /// </summary>
        /// <param name="index">index yang akan disisipi</param>
        /// <param name="item">group baru</param>
        public override void Insert(int index, SeriesGroup item)
        {
            if (isDuplicateName(item))
            {
                throw new DuplicateGroupException();
            }
            else
            {
                base.Insert(index, item);
                item.Changed += new ChangedEventHandler(OnChanged);
            }
        }

        /// <summary>
        /// Menyisipkan kumpulan group baru ke list
        /// </summary>
        /// <param name="index">index yang akan disisipi</param>
        /// <param name="stuff">kumpulan group</param>
        public override void InsertRange(int index, IEnumerable<SeriesGroup> stuff)
        {
            if (isEnumerableDuplicateName(stuff))
            {
                throw new DuplicateGroupException();
            }
            else
            {
                base.InsertRange(index, stuff);
                foreach (SeriesGroup item in stuff)
                {
                    item.Changed += new ChangedEventHandler(OnChanged);
                }
            }
        }

        /// <summary>
        /// Indexer. mengakses group pada list dengan index tertentu
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>group dituju</returns>
        public override SeriesGroup this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                if (isDuplicateName(value))
                {
                    throw new DuplicateGroupException();
                }
                else
                {
                    base[index] = value;
                    value.Changed += new ChangedEventHandler(OnChanged);
                }
            }
        }

        void OnChanged(object sender, EventArgs e)
        {
            this.OnChanged(e);
        }
    }
}
