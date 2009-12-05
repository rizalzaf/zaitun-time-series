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
using System.Collections;
using System.Text;
using System.Diagnostics;

/// <summary>
/// Dimodifikasi dari EventedList Class
/// EventedList Class diperoleh dari komunitas C# www.codeproject.com
/// </summary>

namespace zaitun.Data
{
    public delegate void ChangedEventHandler(object sender, System.EventArgs e);

    /// <summary>
    /// Kelas List yang menyalakan event Changed jika data pada list berubah
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListWithOnChanged<T>:IList<T> ,ICloneable
    { 
        
        /// <summary>
        /// List bayangan
        /// </summary>
        protected readonly List<T> Inner;

        /// <summary>
        /// Apakah penyalaan event pada list untuk sementara dinonaktifkan
        /// </summary>
        protected bool suspendEvent = false;

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ListWithOnChanged()
            : this(null)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="initialData">Data awal</param>
        public ListWithOnChanged(IEnumerable<T> initialData)
        {
            if (initialData == null)
            {
                this.Inner = new List<T>();
            }
            else
            {
                this.Inner = new List<T>(initialData);
            }
        }

        #endregion

        #region IList<T> Members

        public virtual int IndexOf(T item)
        {
            return Inner.IndexOf(item);
        }

        public virtual void Insert(int index, T item)
        {
            if (this.IsReadOnly) throw new ListReadOnlyException();
            Inner.Insert(index, item);
            OnChanged(System.EventArgs.Empty);
        }

        public virtual void RemoveAt(int index)
        {
            if (this.IsReadOnly) throw new ListReadOnlyException();
            T item = this[index];
            Inner.RemoveAt(index);
            OnChanged(System.EventArgs.Empty);
        }

        public virtual T this[int index]
        {
            [DebuggerStepperBoundary]
            get { return Inner[index]; }
            set
            {
                if (this.IsReadOnly) throw new ListReadOnlyException();
                T old = this[index];
                Inner[index] = value;
                OnChanged(System.EventArgs.Empty);
            }
        }

        #endregion

        #region ICollection<T> Members

        public virtual void Add(T item)
        {
            if (this.IsReadOnly) throw new ListReadOnlyException();
            Inner.Add(item);
            OnChanged(System.EventArgs.Empty);
        }

        public virtual void Clear()
        {
            if (this.IsReadOnly) throw new ListReadOnlyException();
            if (Inner.Count == 0) return;            
            Inner.Clear();
            OnChanged(System.EventArgs.Empty);
        }

        public virtual bool Contains(T item)
        {
            return Inner.Contains(item);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            Inner.CopyTo(array, arrayIndex);
        }

        public virtual int Count
        {
            [DebuggerStepThrough]
            get { return Inner.Count; }
        }

        public virtual bool IsReadOnly
        {
            [DebuggerStepThrough]
            get { return this.IsReadOnly_p; }
            [DebuggerStepThrough]
            set { this.IsReadOnly_p = value; }
        }
        private bool IsReadOnly_p;

        public virtual bool Remove(T item)
        {
            if (this.IsReadOnly) throw new ListReadOnlyException();
            if (Inner.Remove(item))
            {
                OnChanged(System.EventArgs.Empty); 
                return true;
            }
            return false;
        }

        #endregion

        #region IEnumerable<T> Members

        public virtual IEnumerator<T> GetEnumerator()
        {
            return Inner.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)Inner.GetEnumerator();
        }

        #endregion

        public virtual IList<T> AsReadOnly()
        {
            if (this.IsReadOnly) throw new ListReadOnlyException();
            ListWithOnChanged<T> el = new ListWithOnChanged<T>(this.Inner);
            el.IsReadOnly = true;
            return el;
        }

        public virtual void AddRange(IEnumerable<T> stuff)
        {
            if (this.IsReadOnly) throw new ListReadOnlyException();
            this.Inner.AddRange(stuff);
            OnChanged(System.EventArgs.Empty);
        }

        public virtual void InsertRange(int index, IEnumerable<T> stuff)
        {
            if (this.IsReadOnly) throw new ListReadOnlyException();
            this.Inner.InsertRange(index,stuff);
            OnChanged(System.EventArgs.Empty);
        }

        public virtual T[] ToArray()
        {
            return Inner.ToArray();
        }

        public virtual void SuspendEvent()
        {
            this.suspendEvent = true;
        }

        public virtual void ResumeEvent()
        {
            this.suspendEvent = false;
            OnChanged(System.EventArgs.Empty);
        }

        #region Event Handler

        public event ChangedEventHandler Changed;

        protected virtual void OnChanged(System.EventArgs e)
        {
            if (Changed != null && !suspendEvent)
            {
                Changed(this, e);
            }
        }

        #endregion

        #region Fire Changed
        public void FireChangedEvent()
        {
            OnChanged(System.EventArgs.Empty);
        }

        #endregion


        #region search
        public int BinarySearch(T item)
        {
            return Inner.BinarySearch(item);
        }

        public int BinarySearch(T item, IComparer<T> comparer)
        {
            return Inner.BinarySearch(item, comparer);
        }

        public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
        {
            return Inner.BinarySearch(index, count, item, comparer);
        }

        #endregion

        #region FindIndex

        public int FindIndex(Predicate<T> match)
        {
            return Inner.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<T> match)
        {
            return Inner.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            return Inner.FindIndex(startIndex, count, match);
        }      

        #endregion

        #region ICloneable Members

        public virtual object Clone()
        {
            ListWithOnChanged<T> clone = new ListWithOnChanged<T>();
            T[] arr = this.ToArray();
            clone.AddRange(arr);            
            return clone;
        }

        #endregion
    }
}
