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

namespace zaitun.MatrixVector
{
    /// <summary>
    /// Kelas Vector berisi data dan operasi vektor yang sering digunakan
    /// untuk perhitungan komputasi statistik
    /// copyright (c) rzaf 2007
    /// </summary>
    /// <remarks>
    /// Indeks tuple dimulai dari 0 sampai jumlah tuple -1    
    /// </remarks>
    public class Vector
    {

        /// <summary>
        /// Variabel yang digunakan untuk menampung data vektor
        /// </summary>
        private double[] data;
        private int tuples;
        private VectorType type;

        /// <summary>
        /// Enumerasi tipe vektor
        /// vektor kolom atau vektor baris
        /// </summary>
        public enum VectorType
        {
            /// <summary>
            /// Vektor kolom
            /// </summary>
            ColumnVector,
            /// <summary>
            /// Vektor Baris
            /// </summary>
            RowVector
        }

        # region Constructor
        /// <summary>
        /// Constructor : Nilai awal ketika vektor dibuat.
        /// Nilai tuple harus diisi terlebih dahulu.
        /// </summary>
        /// <param name="tuples">Integer. Jumlah tuple</param>
        /// <remarks>Semua elemen vektor diisi dengan nilai defaultnya 0.0
        /// Tipe vektor default adalah vektor kolom</remarks>
        public Vector(int tuples)
        {
            this.tuples = Math.Max(1, tuples);
            this.type = Vector.VectorType.ColumnVector;
            this.data = new double[this.tuples];
        }

        /// <summary>
        /// Constructor : Nilai awal ketika vektor dibuat.
        /// </summary>
        /// <param name="data">Array Double. Nilai inisialisasi vektor</param>
        /// <param name="tuples">Integer. Jumlah tuple</param>
        /// <remarks>Nilai elemen vektor diisi dengan nilai array data.
        /// Panjang array harus sama dengan jumlah tuple.
        /// Tipe vektor default adalah vektor kolom</remarks>
        public Vector(double[] data, int tuples)
        {
            this.tuples = Math.Max(1, tuples);
            this.type = Vector.VectorType.ColumnVector;
            this.data = data;
        }

        /// <summary>
        /// Constructor : Nilai awal ketika vektor dibuat.
        /// </summary>
        /// <param name="data">Array Double. Nilai inisialisasi vektor</param>
        /// <remarks>Nilai elemen vektor diisi dengan nilai array data.
        /// Jumlah tuple menyesuaikan panjang array data.
        /// Tipe vektor default adalah vektor kolom</remarks>
        public Vector(double[] data)
        {
            this.tuples = data.Length;
            this.type = Vector.VectorType.ColumnVector;
            this.data = data;
        }

        /// <summary>
        /// Constructor : Nilai awal ketika vektor dibuat.
        /// </summary>
        /// <param name="tuples">Integer. Jumlah tuple</param>
        /// <param name="type">VectorType. Tipe vektor (vektor kolom atau baris).
        /// Semua elemen vektor diisi dengan nilai defaultnya 0.0</param>
        public Vector(int tuples, VectorType type)
        {
            this.tuples = Math.Max(1, tuples);
            this.type = type;
            this.data = new double[this.tuples];
        }

        /// <summary>
        /// Constructor : Nilai awal ketika vektor dibuat.
        /// </summary>
        /// <param name="data">Array Double. Nilai inisialisasi vektor</param>
        /// <param name="tuples">Integer. Jumlah tuple</param>
        /// <param name="type">VectorType. Tipe vektor (vektor kolom atau baris)</param>
        /// <remarks>Nilai elemen vektor diisi dengan nilai array data.
        /// Jumlah tuple menyesuaikan panjang array data.</remarks>
        public Vector(double[] data, int tuples, VectorType type)
        {
            this.tuples = Math.Max(1, tuples);
            this.type = type;
            this.data = data;
        }

        /// <summary>
        /// Constructor : Nilai awal ketika vektor dibuat.
        /// </summary>
        /// <param name="data">Array Double. Nilai inisialisasi vektor</param>
        /// <param name="type">VectorType. Tipe vektor (vektor kolom atau baris)</param>
        /// <remarks>Nilai elemen vektor diisi dengan nilai array data.
        /// Jumlah tuple menyesuaikan panjang array data.</remarks>
        public Vector(double[] data, VectorType type)
        {
            this.tuples = data.Length;
            this.type = type;
            this.data = data;
        }

        /// <summary>
        /// Mengisi semua elemen vektor dengan nilai tertentu
        /// </summary>
        /// <param name="value">Double. Nilai yang dimasukkan</param>
        public void InitializeAllValue(double value)
        {
            for (int i = 0; i < tuples; i++)
                data[i] = value;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Jumlah tuple
        /// </summary>
        public int Tuples
        {
            get { return this.tuples; }
        }

        /// <summary>
        /// Tipe vektor: vektor kolom atau baris
        /// </summary>
        public VectorType Type
        {
            get { return this.type; }            
        }

        /// <summary>
        /// Mendapatkan atau mengeset nilai elemen vektor
        /// </summary>
        /// <param name="tuple">Integer. tuple yang dituju</param>
        /// <returns>Double. Nilai elemen vektor dituju</returns>
        public double this[int tuple]
        {
          
            get { return this.data[tuple]; }
            set { this.data[tuple] = value; }
        }

        /// <summary>
        /// Mendapatkan array data vektor
        /// </summary>
        /// <returns>Array double. Aray data vektor</returns>
        public double[] GetData()
        {
            return this.data;
        }

        /// <summary>
        /// Mendapatkan vector data kuadrat vektor
        /// </summary>
        /// <returns>Vector. Vector data kuadrat</returns>
        public Vector GetDataSquare()
        {
            Vector result = new Vector(this.tuples);            
            for (int i = 0; i < this.tuples; i++)
            {
                result[i] = this.data[i] * this.data[i]; ;
            }            
            return result;
        }

        /// <summary>
        /// Mendapatkan jumlah data pada vektor
        /// </summary>        
        public double GetSumData()
        {
            double result=0;
            for (int i = 0; i < this.tuples; i++)
            {
                result += this.data[i];
            }           
            return result;
        }

        /// <summary>
        /// Mendapatkan copy dari vektor
        /// </summary>
        /// <returns>Vector. Copy dari vektor</returns>
        public Vector Copy()
        {
            Vector result = new Vector(this.tuples, this.type);

            for (int i = 0; i < this.tuples; i++)
                result[i] = this.data[i];

            return result;
        }

        /// <summary>
        /// Mendapatkan vektor transpose
        /// </summary>
        /// <returns>Vector. Vektor transpose</returns>
        /// <remarks>Vektor transpose didapat dengan mengganti tipe vektor
        /// dari baris menjadi kolom atau sebaliknya</remarks>
        public Vector GetTranspose()
        {
            VectorType newType;

            if (this.type == VectorType.ColumnVector)
                newType = VectorType.RowVector;
            else
                newType = VectorType.ColumnVector;

            Vector result = new Vector(this.tuples, newType);

            for (int i = 0; i < this.tuples; i++)
                result[i] = this.data[i];

            return result;
        }

        /// <summary>
        /// Mendapatkan panjang mutlak suatu vektor
        /// </summary>
        public double Length
        {
            get
            {
                double result = 0.0;
                for (int i = 0; i < tuples; i++)
                    result += Math.Pow((data[i]),2);

                result = Math.Sqrt(result);

                return result;
            }
        }

        #endregion

        #region Static Member
        /// <summary>
        /// Mengecek apakah dua vektor berukuran sama
        /// </summary>
        /// <param name="a">Vector. vektor pertama</param>
        /// <param name="b">Vector. vektor kedua</param>
        /// <returns>Boolean. Apakah dua vektor berukuran sama?</returns>
        public static bool IsSameSize(Vector a, Vector b)
        {
            return (a.Tuples == b.Tuples);
        }

        /// <summary>
        /// Mengecek apakah dua vektor bertipe sama
        /// </summary>
        /// <param name="a">Vector. vektor pertama</param>
        /// <param name="b">Vector. vektor kedua</param>
        /// <returns>Boolean. Apakah dua vektor bertipe sama?</returns>
        public static bool IsSameType(Vector a, Vector b)
        {
            return (a.Type == b.Type);
        }

        /// <summary>
        /// Mengecek apakah dua vektor berukuran dan bertipe sama
        /// </summary>
        /// <param name="a">Vector. vektor pertama</param>
        /// <param name="b">Vector. vektor kedua</param>
        /// <returns>Boolean. Apakah dua vektor berukuran dan bertipe sama?</returns>
        public static bool IsSameSizeType(Vector a, Vector b)
        {
            return IsSameSize(a,b) && IsSameType(a,b) ;
        }

        /// <summary>
        /// Mengecek apakah dua vektor dapat dilakukan perkalian double.
        /// Perkalian double adalah perkalian vektor baris dengan vektor kolom
        /// dimana menghasilkan sebuah bilangan bertipe double.
        /// </summary>
        /// <param name="a">Vector. vektor pertama</param>
        /// <param name="b">Vector. vektor kedua</param>
        /// <returns>Boolean. apakah dua vektor dapat dilakukan perkalian double?</returns>
        public static bool CanDoubleMultiply(Vector a, Vector b)
        {
            return IsSameSize(a,b) && (a.Type == VectorType.RowVector)
                && (b.Type==VectorType.ColumnVector);
        }

        /// <summary>
        /// Mengecek apakah dua vektor dapat dilakukan perkalian matriks.
        /// Perkalian matriks adalah perkalian vektor kolom dengan vektor baris
        /// dimana menghasilkan sebuah matriks persegi.
        /// </summary>
        /// <param name="a">Vector. vektor pertama</param>
        /// <param name="b">Vector. vektor kedua</param>
        /// <returns>Boolean. apakah dua vektor dapat dilakukan perkalian matriks?</returns>
        public static bool CanMatrixMultiply(Vector a, Vector b)
        {
            return IsSameSize(a,b) && (a.Type == VectorType.ColumnVector)
                && (b.Type == VectorType.RowVector);
        }

        /// <summary>
        /// Mengecek apakah sebuah matriks dapat dikalikan dengan sebuah vektor
        /// </summary>
        /// <param name="a">Matrix. Matriks</param>
        /// <param name="b">Vector. Vektor</param>
        /// <returns>Boolean. apakah sebuah matriks dapat dikalikan
        /// dengan sebuah vektor?</returns>
        public static bool CanMultiply(Matrix a, Vector b)
        {
            return (a.Cols == b.Tuples) && (b.Type == VectorType.ColumnVector);
        }

        /// <summary>
        /// Mengecek apakah sebuah vektor dapat dikalikan dengan sebuah matriks
        /// </summary>
        /// <param name="a">Vector. Vektor</param>
        /// <param name="b">Matrix. Matriks</param>
        /// <returns>Boolean. apakah sebuah vektor dapat dikalikan
        /// dengan sebuah matriks?</returns>
        public static bool CanMultiply(Vector a, Matrix b)
        {
            return (a.Tuples == b.Rows) && (a.Type == VectorType.RowVector);
        }

        /// <summary>
        /// Operator overloading. Operasi penjumlahan vektor
        /// </summary>
        /// <param name="a">Vector. Vektor pertama</param>
        /// <param name="b">Vector. Vektor kedua</param>
        /// <returns>Vector. Vektor hasil penjumlahan</returns>
        public static Vector operator +(Vector a, Vector b)
        {
            Vector result = new Vector(a.Tuples, a.Type);

            if (IsSameSizeType(a, b))
            {
                for (int i = 0; i < a.Tuples; i++)
                    result[i] = a[i] + b[i];
            }
            else
            {
                throw new NotSameSizeVectorException();
            }

            return result;
        }

        /// <summary>
        /// Operator overloading. Operasi pengurangan vektor
        /// </summary>
        /// <param name="a">Vector. Vektor pertama</param>
        /// <param name="b">Vector. Vektor kedua</param>
        /// <returns>Vector. Vektor hasil pengurangan</returns>
        public static Vector operator -(Vector a, Vector b)
        {
            Vector result = new Vector(a.Tuples, a.Type);

            if (IsSameSizeType(a, b))
            {
                for (int i = 0; i < a.Tuples; i++)
                    result[i] = a[i] - b[i];
            }
            else
            {
                throw new NotSameSizeVectorException();
            }

            return result;
        }

        /// <summary>
        /// Operator overloading. Operasi perkalian skalar
        /// (perkalian vektor dengan konstanta)
        /// </summary>
        /// <param name="constant">Double. konstanta</param>
        /// <param name="a">Vector. vektor</param>
        /// <returns>Vector. vektor hasil perkalian skalar</returns>
        public static Vector operator *(double constant, Vector a)
        {
            Vector result = new Vector(a.Tuples, a.Type);

            for (int i = 0; i < a.Tuples; i++)
                result[i] = constant * a[i];

            return result;
        }

        /// <summary>
        /// Operator overloading. Operasi perkalian matriks dengan vektor
        /// </summary>
        /// <param name="a">Matrix. Matriks</param>
        /// <param name="b">Vector. Vektor</param>
        /// <returns>Vector. vektor hasil perkalian matriks dengan vektor.
        /// Berupa vektor kolom</returns>
        public static Vector operator *(Matrix a, Vector b)
        {
            Vector result = new Vector(a.Rows,VectorType.ColumnVector);

            if (CanMultiply(a, b))
            {
                for (int i = 0; i < a.Rows; i++)
                {
                    result[i] = 0.0;
                    for (int j = 0; j < a.Cols; j++)
                    {
                        result[i] += a[i, j] * b[j];
                    }
                }
            }
            else
            {
                throw new WrongVectorSizeOrTypeException("Can't be multiplied");
            }

            return result;
        }

        /// <summary>
        /// Operator overloading. Operasi perkalian vektor dengan matriks
        /// </summary>
        /// <param name="a">Vector. Vektor</param>
        /// <param name="b">Matrix. Matriks</param>
        /// <returns>Vector. vektor hasil perkalian vektor dengan matriks.
        /// Berupa vektor baris</returns>
        public static Vector operator *(Vector a, Matrix b)
        {
            Vector result = new Vector(b.Cols, VectorType.RowVector);

            if (CanMultiply(a, b))
            {
                for (int i = 0; i < b.Cols; i++)
                {
                    result[i] = 0.0;
                    for (int j = 0; j < b.Rows; j++)
                    {
                        result[i] += a[j] * b[j, i];
                    }
                }
            }
            else
            {
                throw new WrongVectorSizeOrTypeException("Can't be multiplied");
            }

            return result;
        }        

        /// <summary>
        /// Melakukan perkalian double terhadap dua vektor
        /// </summary>
        /// <param name="a">Vector. vektor pertama</param>
        /// <param name="b">Vector. vektor kedua</param>
        /// <returns>Double. hasil perkalian double dua vektor</returns>
        public static double DoubleMultiply(Vector a, Vector b)
        {
            double result=0.0;

            if (CanDoubleMultiply(a, b))
            {
                for (int i = 0; i < a.Tuples; i++)
                    result += a[i] * b[i];
            }
            else
            {
                throw new WrongVectorSizeOrTypeException("Vector can't be double Multiplied");
            }

            return result;
        }

        /// <summary>
        /// Melakukan perkalian matriks terhadap dua vektor
        /// </summary>
        /// <param name="a">Vector. vektor pertama</param>
        /// <param name="b">Vector. vektor kedua</param>
        /// <returns>Matrix. hasil perkalian matriks dua vektor</returns>
        public static Matrix MatrixMultiply(Vector a, Vector b)
        {
            Matrix result = new Matrix(a.Tuples, b.Tuples);

            if (CanMatrixMultiply(a, b))
            {
                for (int i = 0; i < a.Tuples; i++)
                    for (int j = 0; j < b.Tuples; j++)
                        result[i,j] = a[i] * b[j];
            }
            else
            {
                throw new WrongVectorSizeOrTypeException("Vector can't be matrix Multiplied");
            }

            return result;
        }

        /// <summary>
        /// Operator overloading. Membandingkan kesamaan dua vektor
        /// </summary>
        /// <param name="a">Vector. vektor pertama</param>
        /// <param name="b">Vector. vektor kedua</param>
        /// <returns>Bolean. Apakah dua vektor sama?</returns>
        public static bool operator ==(Vector a, Vector b)
        {
            bool result = true;

            if (a.Type == b.Type)
            {
                if (a.Tuples == b.Tuples)
                {
                    for (int i = 0; i < a.Tuples; i++)
                    {
                        if (a[i] != b[i])
                        {
                            result = false;
                            break;
                        }
                    }
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Operator overloading. Membandingkan ketidaksamaan dua vektor
        /// </summary>
        /// <param name="a">Vector. vektor pertama</param>
        /// <param name="b">Vector. vektor kedua</param>
        /// <returns>Bolean. Apakah dua vektor tidak sama?</returns>
        public static bool operator !=(Vector a, Vector b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Mengecek apakah dua buah vektor perpendicular.
        /// Dua buah vektor perpendicular jika hasil perkalian doublenya 0
        /// </summary>
        /// <param name="a">Vector. Vektor pertama</param>
        /// <param name="b">Vector. Vektor kedua</param>
        /// <returns>Boolean. Apakah dua buah vektor perpendicular?</returns>
        public static bool IsPerpendicular(Vector a, Vector b)
        {
            bool result;

            if (a.Type == VectorType.ColumnVector && b.Type == VectorType.ColumnVector)
            {
                Vector aT = a.GetTranspose();
                result = Vector.DoubleMultiply(aT, b) == 0.0;
            }
            else
            {
                throw new WrongVectorTypeException("Only Column Vector valid");
            }

            return result;
        }

        /// <summary>
        /// Mendapatkan sudut (dalam radian) antara dua vektor
        /// </summary>
        /// <param name="a">Vector. Vektor pertama</param>
        /// <param name="b">Vector. Vektor kedua</param>
        /// <returns>Double. Sudut antara dua vektor dalam radian</returns>
        public static double Angle(Vector a, Vector b)
        {
            double result;

            if (a.Type == VectorType.ColumnVector && b.Type == VectorType.ColumnVector)
            {
                Vector aT = a.GetTranspose();
                result = Vector.DoubleMultiply(aT, b);
                result /= a.Length * b.Length;
                result = Math.Acos(result);
            }
            else
            {
                throw new WrongVectorTypeException("Only Column Vector valid");
            }

            return result;
        }

        /// <summary>
        /// Mendapatkan vektor proyeksi antara Vektor X dan Vektor Y
        /// </summary>
        /// <param name="X">Vector. Vektor X</param>
        /// <param name="Y">Vector. Vektor Y</param>
        /// <returns>Vector. Vektor proyeksi</returns>
        public static Vector ProjectionXonY(Vector X, Vector Y)
        {
            Vector result;

            if (X.Type == VectorType.ColumnVector && Y.Type == VectorType.ColumnVector)
            {
                Vector XT = X.GetTranspose();
                double proj = Vector.DoubleMultiply(XT, Y)/(Math.Pow(Y.Length,2));

                result = proj * Y;
            }
            else
            {
                throw new WrongVectorTypeException("Only Column Vector valid");
            }

            return result;

        }

        #endregion

        #region Override Member

        /// <summary>
        /// Override Method. Mengecek apakah objek obj equal dengan nilai vektor.
        /// </summary>
        /// <param name="obj">Objek yang akan dicek equal atu tidak</param>
        /// <returns>Boolean. apakah objek obj equal dengan vektor ini?</returns>
        public override bool Equals(object obj)
        {
            bool result;

            if (obj is Vector)
            {
                Vector b = (Vector)obj;
                result = (this == b);
            }
            else
            {
                result = false;
            }

            return result;

            //return base.Equals(obj);
        }

        /// <summary>
        /// Override Method. Mendapatkan hash code vektor.
        /// </summary>
        /// <returns>Integer. Nilai hash code vektor</returns>
        public override int GetHashCode()
        {
            return data.GetHashCode() * Type.GetHashCode();

            //return base.GetHashCode();
        }

       

        #endregion

        /// <summary>
        /// Mendapatkan matrix dari vektor berdasarkan lag yang diinput. Setiap lag
        /// akan menjadi colum pada Matrix. 
        /// </summary>
        /// <param name="Lag">Nilai Lag. Nilai akan menjadi nilai colum dari matrix</param>
        /// <returns>Matrix. Matrix berukuran vectorTupples X lag</returns>
        public Matrix GetMatrix(int Lag)
        {
            Matrix X = new Matrix(this.tuples - Lag, Lag + 1);

            for (int j = 0; j < this.tuples - Lag; j++)
            {
                X[j, 0] = 1;
                for (int i = 1; i <= Lag; i++)
                {
                    X[j, i] = this[Lag+j-i];
                }
            }
            return X;
        }

        public Matrix GetAcfMatrix()
        {
            int n = this.tuples;
            Matrix X = new Matrix(n, n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j) X[i, j] = 1;
                    else X[i, j] = this[Math.Abs(j - i) - 1];
                }
            }
            return X;
        }
    }
}
