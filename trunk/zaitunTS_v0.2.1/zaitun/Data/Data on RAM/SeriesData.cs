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

namespace zaitun.Data
{

    /// <summary>
    /// Kelas yang menyimpan project data-data time series
    /// </summary>
    public class SeriesData
    {
        private string seriesName;
        private SeriesFrequency frequency;
        private DateTime startDate;

        private DateTime endDate;
        private int numberObservations;

        private ListWithOnChanged<string> time;
        private ListWithOnChanged<DateTime> xTime;
        private SeriesVariables seriesVariables;
        private SeriesGroups seriesGroups;
        private SeriesStocks seriesStocks;

        /// <summary>
        /// Nama Data Time Series
        /// </summary>
        public string SeriesName
        {
            get { return seriesName; }
            set { seriesName = value; OnChanged(System.EventArgs.Empty); }
        }

        /// <summary>
        /// frekuensi data
        /// </summary>
        public SeriesFrequency Frequency
        {
            get { return frequency; }
            set { frequency = value; OnChanged(System.EventArgs.Empty); }
        }

        /// <summary>
        /// tanggal awal data
        /// </summary>
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; OnChanged(System.EventArgs.Empty); }
        }

        /// <summary>
        /// tanggal awal data
        /// </summary>
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; OnChanged(System.EventArgs.Empty); }
        }

        /// <summary>
        /// jumlah Observasi
        /// </summary>
        public int NumberObservations
        {
            get { return numberObservations; }
            //set { numberObservations = value; }
        }

        /// <summary>
        /// Variabel waktu
        /// </summary>
        public ListWithOnChanged<string> Time
        {
            get { return this.time; }
        }

        /// <summary>
        /// Variabel waktu dalam DateTime format
        /// </summary>
        public ListWithOnChanged<DateTime> XTime
        {
            get { return this.xTime; }
        }

        /// <summary>
        /// Kumpulan variabel pada data time series
        /// </summary>
        public SeriesVariables SeriesVariables
        {
            get { return this.seriesVariables; }
            //set { this.seriesVariables = value; }
        }

        /// <summary>
        /// Kumpulan group pada data time series
        /// </summary>
        public SeriesGroups SeriesGroups
        {
            get { return this.seriesGroups; }
            //set { this.seriesGroups = value; }
        }

        /// <summary>
        /// Kumpulan stock pada data time series
        /// </summary>
        public SeriesStocks SeriesStocks
        {
            get { return this.seriesStocks; }
            //set { this.seriesStocks = value; }
        }

        /// <summary>
        /// Enumerasi frekuesi
        /// </summary>
        public enum SeriesFrequency
        {
            /// <summary>
            /// Data Tahunan
            /// </summary>
            Annual,
            /// <summary>
            /// Data semi tahunan (pertengahan tahun)
            /// </summary>
            SemiAnnual,
            /// <summary>
            /// Data triwulanan (satu tahun dibagi empat)
            /// </summary>
            Quarterly,
            /// <summary>
            /// Data Bulanan
            /// </summary>
            Monthly,
            /// <summary>
            /// Data Mingguan
            /// </summary>
            Weekly,
            /// <summary>
            /// Data Harian 7hari per minggu
            /// </summary>
            Daily,
            /// <summary>
            /// Data Harian 6hari per minggu
            /// </summary>
            Daily6,
            /// <summary>
            /// Data Harian 5hari per minggu
            /// </summary>
            Daily5,
            /// <summary>
            /// Tanpa penagggalan
            /// </summary>
            Undated
        }      

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">nama project</param>
        /// <param name="frequency">frekuensi</param>
        /// <param name="start">tangal awal</param>
        /// <param name="end">tangal akhir</param>
        public SeriesData(string name,SeriesFrequency frequency, DateTime start, DateTime end)
        {
            this.seriesName = name;
            this.frequency = frequency;
            this.startDate = start;
            this.endDate = end;
            this.computeNumberObservations();
            this.createNewTimeData();
            this.seriesVariables = new SeriesVariables();
            this.seriesGroups = new SeriesGroups();
            this.seriesStocks = new SeriesStocks();

            this.seriesVariables.Changed += new ChangedEventHandler(OnChanged);
            this.seriesGroups.Changed += new ChangedEventHandler(OnChanged);
            this.seriesStocks.Changed += new ChangedEventHandler(OnChanged);
            this.time.Changed += new ChangedEventHandler(OnChanged);
            
        }

       
        
        /// <summary>
        /// Constructor. untuk undated
        /// </summary>
        /// <param name="name">nama project</param>
        /// <param name="numberObservations">jumlah observasi</param>
        public SeriesData(string name, int numberObservations)
        {
            this.seriesName = name;
            this.frequency = SeriesData.SeriesFrequency.Undated;
            this.numberObservations = numberObservations;
            this.createNewTimeData();
            this.seriesVariables = new SeriesVariables();
            this.seriesGroups = new SeriesGroups();
            this.seriesStocks = new SeriesStocks();

            this.seriesVariables.Changed += new ChangedEventHandler(OnChanged);
            this.seriesGroups.Changed += new ChangedEventHandler(OnChanged);
            this.seriesStocks.Changed += new ChangedEventHandler(OnChanged);
            this.time.Changed += new ChangedEventHandler(OnChanged);
        }

        /// <summary>
        /// Fungsi untuk membuat variabel waktu
        /// </summary>
        private void createNewTimeData()
        {
            DateTime currentDate = new DateTime(startDate.Year,startDate.Month,startDate.Day);

            this.time = new ListWithOnChanged<string>();
            this.xTime = new ListWithOnChanged<DateTime>();
            
            switch (this.frequency)
            {
                case SeriesFrequency.Annual:
                    while (currentDate <= this.endDate)
                    {
                        this.time.Add(currentDate.Year.ToString());
                        this.xTime.Add(currentDate);
                        currentDate = currentDate.AddYears(1);
                    }
                    break;
                case SeriesFrequency.SemiAnnual:
                    while (currentDate <= this.endDate)
                    {
                        this.time.Add("Half " + (currentDate.Month / 6) + " " +
                            currentDate.Year.ToString());
                        this.xTime.Add(currentDate);
                        currentDate = currentDate.AddMonths(6);
                    }
                    break;
                case SeriesFrequency.Quarterly:
                    while (currentDate <= this.endDate)
                    {
                        this.time.Add("Quarter " + (currentDate.Month / 3) + " " +
                            currentDate.Year.ToString());
                        this.xTime.Add(currentDate);
                        currentDate = currentDate.AddMonths(3);
                    }
                    break;
                case SeriesFrequency.Monthly:
                    while (currentDate <= this.endDate)
                    {
                        this.time.Add(SeriesData.ConvertIntToMonth(currentDate.Month) 
                            +" "+ currentDate.Year.ToString());
                        this.xTime.Add(currentDate);
                        currentDate = currentDate.AddMonths(1);
                    }
                    break;
                case SeriesFrequency.Weekly:
                    while (currentDate <= this.endDate)
                    {
                        this.time.Add(currentDate.ToString("dd/MM/yy"));
                        this.xTime.Add(currentDate);
                        currentDate = currentDate.AddDays(7);
                    }
                    break;
                case SeriesFrequency.Daily:
                    while (currentDate <= this.endDate)
                    {
                        this.time.Add(currentDate.ToString("dd/MM/yy"));
                        this.xTime.Add(currentDate);
                        currentDate = currentDate.AddDays(1);
                    }
                    break;
                case SeriesFrequency.Daily6:
                    while (currentDate <= this.endDate)
                    {
                        if (currentDate.DayOfWeek != DayOfWeek.Sunday)
                        {
                            this.time.Add(currentDate.ToString("dd/MM/yy"));
                            this.xTime.Add(currentDate);
                        }
                        currentDate = currentDate.AddDays(1);
                    }
                    break;
                case SeriesFrequency.Daily5:
                    while (currentDate <= this.endDate)
                    {
                        if (currentDate.DayOfWeek != DayOfWeek.Sunday &&
                            currentDate.DayOfWeek != DayOfWeek.Saturday)
                        {
                            this.time.Add(currentDate.ToString("dd/MM/yy"));
                            this.xTime.Add(currentDate);
                        }
                        currentDate = currentDate.AddDays(1);
                    }
                    break;
                case SeriesFrequency.Undated:
                    for (int i = 0; i < this.numberObservations; i++)
                        this.time.Add(Convert.ToString(i + 1));
                    break;
            }            
        }

        /// <summary>
        /// Menghitung jumlah observasi
        /// </summary>
        private void computeNumberObservations()
        {
            numberObservations = NumberObservation(this.startDate, this.endDate, this.frequency);  
        }       

        #region Static Member

        /// <summary>
        /// Fungsi statik mengonversi nilai bulan integer ke nama bulan
        /// </summary>
        /// <param name="value">nilai bulan integer</param>
        /// <returns>nama bulan</returns>
        public static string ConvertIntToMonth(int value)
        {
            string month="";

            switch (value)
            {
                case 1: month = "January"; break;
                case 2: month = "February"; break;
                case 3: month = "March"; break;
                case 4: month = "April"; break;
                case 5: month = "May"; break;
                case 6: month = "June"; break;
                case 7: month = "July"; break;
                case 8: month = "August"; break;
                case 9: month = "September"; break;
                case 10: month = "October"; break;
                case 11: month = "November"; break;
                case 12: month = "December"; break;
            }

            //switch (value)
            //{
            //    case 1: month = "Januari"; break;
            //    case 2: month = "Februari"; break;
            //    case 3: month = "Maret"; break;
            //    case 4: month = "April"; break;
            //    case 5: month = "Mei"; break;
            //    case 6: month = "Juni"; break;
            //    case 7: month = "Juli"; break;
            //    case 8: month = "Agustus"; break;
            //    case 9: month = "September"; break;
            //    case 10: month = "Oktober"; break;
            //    case 11: month = "November"; break;
            //    case 12: month = "Desember"; break;
            //}
            return month;
        }

        /// <summary>
        /// Fungsi statik menghitung jumlah observasi
        /// </summary>
        /// <param name="startDate">tanggal awal</param>
        /// <param name="endDate">tangal akhir</param>
        /// <param name="frequency">frekuensi</param>
        /// <returns>jumlah observasi</returns>
        public static int NumberObservation(DateTime startDate, DateTime endDate, SeriesFrequency frequency)
        {
            int intdiff = 0;
            TimeSpan timediff = new TimeSpan();
            DateTime current;
            switch (frequency)
            {
                case SeriesFrequency.Annual:
                    intdiff = endDate.Year - startDate.Year + 1;
                    break;
                case SeriesFrequency.SemiAnnual:
                    current = startDate;
                    while (current <= endDate)
                    {
                        intdiff++;
                        current = current.AddMonths(6);
                    }
                    break;
                case SeriesFrequency.Quarterly:
                    current = startDate;
                    while (current <= endDate)
                    {
                        intdiff++;
                        current = current.AddMonths(3);
                    }
                    break;
                case SeriesFrequency.Monthly:
                    intdiff = 12 * (endDate.Year - startDate.Year)
                        + (endDate.Month - startDate.Month) + 1;
                    break;
                case SeriesFrequency.Weekly:
                    timediff = endDate - startDate;
                    intdiff = (timediff.Days) / 7 + 1;
                    break;
                case SeriesFrequency.Daily:
                    timediff = endDate - startDate;
                    intdiff = timediff.Days + 1;
                    break;
                case SeriesFrequency.Daily6:
                    current = startDate;
                    while (current <= endDate)
                    {
                        if (current.DayOfWeek != DayOfWeek.Sunday)
                        {
                            intdiff++;
                        }
                        current = current.AddDays(1);
                    }
                    break;
                case SeriesFrequency.Daily5:
                    current = startDate;
                    while (current <= endDate)
                    {
                        if (current.DayOfWeek != DayOfWeek.Sunday &&
                            current.DayOfWeek != DayOfWeek.Saturday)
                        {
                            intdiff++;
                        }
                        current = current.AddDays(1);
                    }
                    break;
                case SeriesFrequency.Undated:
                    break;

            }
            return intdiff;    

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

        void OnChanged(object sender, EventArgs e)
        {
            this.OnChanged(e);
        }

        #endregion

    }
}
