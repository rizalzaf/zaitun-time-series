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
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace zaitun.Data
{
    /// <summary>
    /// Kelas yang menyimpan data sebuah variabel
    /// </summary>
    public class SeriesStock : ICloneable
    {
        private string stockName;
        private string stockDescription;        

        private SeriesVariable open;
        private SeriesVariable close;
        private SeriesVariable high;
        private SeriesVariable low;
        private SeriesVariable volume;        
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Stock Name</param>
        /// <param name="description">Stock Description</param>
        public SeriesStock(string name, string description)
        {
            this.initialize(name, description, null, null, null, null, null);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Stock Name</param>
        /// <param name="description">Stock Description</param>
        /// <param name="open">Stock's open variable</param>
        /// <param name="close">Stock's close variable</param>
        /// <param name="high">Stock's high variable</param>
        /// <param name="low">Stock's low variable</param>
        public SeriesStock(string name, string description, SeriesVariable open, SeriesVariable close, SeriesVariable high, SeriesVariable low)
        {
            this.initialize(name, description, open, close, high, low, null);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Stock Name</param>
        /// <param name="description">Stock Description</param>
        /// <param name="open">Stock's open variable</param>
        /// <param name="close">Stock's close variable</param>
        /// <param name="high">Stock's high variable</param>
        /// <param name="low">Stock's low variable</param>
        /// <param name="volume">Stock's volume variable</param>
        public SeriesStock(string name, string description, SeriesVariable open, SeriesVariable close, SeriesVariable high, SeriesVariable low, SeriesVariable volume)
        {
            this.initialize(name, description, open, close, high, low, volume);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Stock Name</param>
        /// <param name="description">Stock Description</param>
        /// <param name="open">Stock's open variable</param>
        /// <param name="close">Stock's close variable</param>
        /// <param name="high">Stock's high variable</param>
        /// <param name="low">Stock's low variable</param>
        /// <param name="volume">Stock's volume variable</param>
        private void initialize(string name, string description, SeriesVariable open, SeriesVariable close, SeriesVariable high, SeriesVariable low, SeriesVariable volume)
        {
            this.stockName = name;
            this.stockDescription = description;
            this.open = open;
            this.close = close;
            this.high = high;
            this.low = low;
            this.volume = volume;

            if (this.open != null) this.open.Changed += new ChangedEventHandler(changed);
            if (this.close != null) this.close.Changed += new ChangedEventHandler(changed);
            if (this.high != null) this.high.Changed += new ChangedEventHandler(changed);
            if (this.low != null) this.low.Changed += new ChangedEventHandler(changed);
            if (this.volume != null) this.volume.Changed += new ChangedEventHandler(changed);
        }

        void changed(object sender, EventArgs e)
        {
            OnChanged(System.EventArgs.Empty);
        }

        /// <summary>
        /// The name of the stock
        /// </summary>
        public string StockName
        {
            get { return this.stockName; }
            set { this.stockName = value; OnChanged(System.EventArgs.Empty); }
        }

        /// <summary>
        /// The description of the stock
        /// </summary>
        public string StockDescription
        {
            get { return this.stockDescription; }
            set { this.stockDescription = value; OnChanged(System.EventArgs.Empty); }
        }

        /// <summary>
        /// The Open variable of the stock
        /// </summary>
        public SeriesVariable Open
        {
            get { return this.open; }
            set { this.open = value; OnChanged(System.EventArgs.Empty); }
        }

        /// <summary>
        /// The Close variable of the stock
        /// </summary>
        public SeriesVariable Close
        {
            get { return this.close; }
            set { this.close = value; OnChanged(System.EventArgs.Empty); }
        }

        /// <summary>
        /// The High variable of the stock
        /// </summary>
        public SeriesVariable High
        {
            get { return this.high; }
            set { this.high = value; OnChanged(System.EventArgs.Empty); }
        }

        /// <summary>
        /// The Low variable of the stock
        /// </summary>
        public SeriesVariable Low
        {
            get { return this.low; }
            set { this.low = value; OnChanged(System.EventArgs.Empty); }
        }

        /// <summary>
        /// The Volume variable of the stock
        /// </summary>
        public SeriesVariable Volume
        {
            get { return this.volume; }
            set { this.volume = value; OnChanged(System.EventArgs.Empty); }
        }        


        #region override

        /// <summary>
        /// String value represent the object
        /// </summary>
        /// <returns>String value of the stock's name</returns>
        public override string ToString()
        {
            return this.stockName;
        }

        #endregion


        #region ICloneable Members

        /// <summary>
        /// Clone stock
        /// </summary>
        /// <returns>new stock which has same identity as the source</returns>
        public object Clone()
        {
            SeriesStock clone = new SeriesStock(this.StockName, this.StockDescription, this.Open, this.Close, this.High, this.Low, this.Volume);

            return clone;
        }

        #endregion


        #region Event
        public event ChangedEventHandler Changed;

        protected virtual void OnChanged(System.EventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }

        #endregion
    }
}
