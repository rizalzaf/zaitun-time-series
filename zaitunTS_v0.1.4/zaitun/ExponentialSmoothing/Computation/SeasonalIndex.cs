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
using zaitun.MatrixVector;

namespace zaitun.ExponentialSmoothing
{
    /// <summary>
    /// Kelas untuk menghitung nilai indeks musiman
    /// </summary>
    class SeasonalIndex
    {
        private Vector y;
        private double[] sMov1, sMov2;
        private double[] median;
        private double[] seasonal;
        private double[] term;
        private double[] dataMedian;
        private int startPosition;
        private int endPosition;
        private int includedObservation;
        private int seasonalLength;
        private bool isMultiplicative;

        #region Constructor
        /// <summary>
        /// Menghitung nilai indeks musiman
        /// </summary>
        /// <param name="y">Vector. data aktual</param>
        /// <param name="seasonalLength">Integer. panjang musiman</param>
        /// <param name="isMultiplicative">Boolean. tipe model yang digunakan</param>
        public SeasonalIndex(Vector y, int seasonalLength, bool isMultiplicative)
        {
            this.y = y;
            this.includedObservation = this.y.Tuples;
            this.seasonalLength = seasonalLength;
            this.isMultiplicative = isMultiplicative;

            sMov1 = new double[includedObservation];
            sMov2 = new double[includedObservation];
            median = new double[seasonalLength];
            seasonal = new double[seasonalLength];

            term = new double[this.includedObservation];
            for (int i = 0; i < this.includedObservation; )
            {
                for (int j = 0; j < this.seasonalLength; ++j)
                {
                    if (i + j != this.includedObservation)
                        term[i + j] = j;
                    else
                        break;
                }
                i += this.seasonalLength;
            }

            this.CalcSeasonalIndex();
        }
        #endregion

        #region Procedure
        /// <summary>
        /// Prosedur untuk menghitung nilai seasonal
        /// </summary>
        private void CalcSeasonalIndex()
        {
            double jumlah, remedial = 0;

            //penentuan posisi nilai awal dan nilai akhir
            if (seasonalLength % 2 == 0)
            {
                startPosition = (seasonalLength / 2);
                endPosition = includedObservation - (seasonalLength / 2);
            }
            else
            {
                startPosition = ((seasonalLength + 1) / 2) - 1;
                endPosition = (includedObservation - ((seasonalLength + 1) / 2));
            }

            //penghitungan l-mov
            //Rata-rata bergerak dengan besarnya orde adalah panjang musimannya
            for (int i = 0; i < includedObservation - seasonalLength + 1; i++)
            {
                jumlah = 0;
                for (int j = i; j < i + seasonalLength; j++)
                    jumlah = jumlah + y[j];
                sMov1[i + startPosition] = jumlah / seasonalLength;
            }

            //penghitungan 2-mov
            //Menghitung rata-rata bergerak berorde 2
            //Kemudian mencari rasionya dengan data aktual untuk multiplikatif
            //atau selisihnya dengan data aktual untuk aditif
            for (int i = startPosition; i <= endPosition; i++)
            {
                if (i == endPosition)
                    sMov1[i] = 0;
                else
                {
                    sMov1[i] = (sMov1[i] + sMov1[i + 1]) / 2;
                    if (this.isMultiplicative)
                        sMov1[i] = y[i] / sMov1[i];
                    else
                        sMov1[i] = y[i] - sMov1[i];
                }
            }

            //Mencari median setiap musiman
            List<double> termData = new List<double>();
            for (int i = 0; i < seasonalLength; i++)
            {
                for (int j = startPosition; j < endPosition; ++j)
                {
                    if (this.term[j] == i)
                    {
                        termData.Add(sMov1[j]);
                    }
                }
                median[i] = SearchMedian(termData);
                termData.Clear();
            }

            //menghitung nilai remedial
            //kemudian menghitung indeks musiman setiap periode musiman
            if (this.isMultiplicative)
            {
                for (int i = 0; i < seasonalLength; i++)
                    remedial += median[i];
                remedial = seasonalLength / remedial;

                //indeks musiman
                for (int i = 0; i < seasonalLength; i++)
                    seasonal[i] = median[i] * remedial;
            }
            else
            {
                for (int i = 0; i < seasonalLength; i++)
                    remedial += median[i];
                remedial = remedial / this.seasonalLength;

                //indeks musiman
                for (int i = 0; i < seasonalLength; i++)
                    seasonal[i] = median[i] - remedial;
            }
        }

        /// <summary>
        /// Prosedur mengurutkan data
        /// </summary>
        /// <param name="array_size">Integer. banyaknya data yang akan diurutkan</param>
        private void BubbleSort(int array_size)
        {
            int i, j;
            double temp;
            for (i = (array_size - 1); i >= 0; i--)
            {
                for (j = 1; j <= i; j++)
                {
                    if (dataMedian[j - 1] > dataMedian[j])
                    {
                        temp = dataMedian[j - 1];
                        dataMedian[j - 1] = dataMedian[j];
                        dataMedian[j] = temp;
                    }
                }
            }
        }
        #endregion

        #region Function
        /// <summary>
        /// Fungsi untuk mencari nilai median
        /// </summary>
        /// <param name="termData">List Double. List data yang akan dicari mediannya</param>
        /// <returns>Double. Nilai median</returns>
        private double SearchMedian(List<double> termData)
        {
            double valMedian;

            //Banyaknya data yang akan dicari mediannya
            int jml = termData.Count;

            //Memindahkan data dari list ke dalam array
            dataMedian = new double[jml];
                termData.CopyTo(dataMedian);

            //mengurutkan data terlebih dahulu sebelum mencari nilai median
            BubbleSort(jml);

            //Mencari nilai median
            if (jml % 2 == 0)
            {
                valMedian = dataMedian[jml / 2 - 1] + dataMedian[jml / 2];
                valMedian = valMedian / 2;
            }
            else
                valMedian = dataMedian[(jml - 1) / 2];

            return valMedian;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Mendapatkan data seasonal
        /// </summary>
        public double[] SEASONAL
        {
            get { return seasonal; }
        }
        #endregion
    }
}
