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

namespace zaitun.MatrixVector
{
    /// <summary>
    /// Kelas Matrix berisi data dan operasi matriks yang sering digunakan
    /// untuk perhitungan komputasi statistik
    /// copyright (c) rzaf 2007
    /// </summary>
    /// <remarks>
    /// Indeks baris maupun kolom dimulai dari 0 sampai jumlah baris
    /// atau kolom - 1
    /// </remarks>
    public class Matrix
    {
        /// <summary>
        /// Variabel yang digunakan untuk menampung data matriks
        /// </summary>
        private double[,] data;
        private int cols, rows;

        #region Constructor
        /// <summary>
        /// Constructor : Nilai awal ketika matriks dibuat. 
        /// Jumlah baris dan kolom harus ditentukan terlebih dahulu
        /// </summary>
        /// <param name="rows">Integer. Jumlah baris.</param>
        /// <param name="cols">Integer. Jumlah kolom.</param>
        /// <remarks>
        /// Semua elemen matriks diisi dengan nilai defaultnya yaitu 0.0
        /// </remarks>
        public Matrix(int rows, int cols)
        {
            if (cols > 0 && rows > 0)
            {
                this.cols = Math.Max(1, cols); //nilai minimal 1
                this.rows = Math.Max(1, rows);
                this.data = new double[this.rows, this.cols];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Matrix.Cols || Matrix.Rows", "Only positive number valid");                
            }
        }

        /// <summary>
        /// Constructor : Nilai awal ketika matriks dibuat. 
        /// Jumlah baris dan kolom harus ditentukan terlebih dahulu
        /// </summary>
        /// <param name="data">Array double dua dimensi. 
        /// Nilai data yang akan dimasukkan ke matriks</param>
        /// <param name="rows">Integer. Jumlah baris.</param>
        /// <param name="cols">Integer. Jumlah kolom.</param>
        /// <remarks>
        /// Nilai elemen matriks diisi dengan nilai array yang dimasukkan.
        /// Ukuran array (jumlah baris dan kolom) harus sama dengan ukuran matriks
        /// </remarks>
        public Matrix(double[,] data, int rows, int cols)
        {
            if (cols > 0 && rows > 0)
            {
                this.cols = Math.Max(1, cols); //nilai minimal 1
                this.rows = Math.Max(1, rows);
                this.data = new double[this.rows, this.cols];
                this.data = (double[,])data.Clone();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Matrix.Cols || Matrix.Rows", "Only positive number valid");                
            }
        }

        /// <summary>
        /// Mengeset semua elemen array dengan nilai tertentu
        /// </summary>
        /// <param name="value">Double. Nilai yang dimasukkan</param>
        /// <remarks>
        /// Digunakan untuk membuat matriks dengan semua nilai elemen sama
        /// </remarks>
        public void InitializeAllValue(double value)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    data[i, j] = value;
        }

        #endregion

        #region Properties Member
        /// <summary>
        /// Mendapatkan jumlah baris dari matriks
        /// </summary>
        /// <remarks>
        /// Property ini bersifat Read Only,  
        /// Jumlah baris tidak dapat diubah.
        /// </remarks>
        public int Rows
        {
            get { return this.rows; }
        }

        /// <summary>
        /// Mendapatkan jumlah kolom dari matriks
        /// </summary>
        /// <remarks>
        /// Property ini bersifat Read Only,  
        /// Jumlah kolom tidak dapat diubah.
        /// </remarks>
        public int Cols
        {
            get { return this.cols; }
        }

        /// <summary>
        /// Mendapatkan atau mengeset nilai suatu elemen matriks
        /// </summary>
        /// <param name="row">Integer. Baris yang dituju</param>
        /// <param name="col">Integer. Kolom yang dituju</param>
        /// <returns>Double. Nilai elemen matriks yang dituju</returns>
        public double this[int row, int col]
        {
            get { return this.data[row, col]; }
            set { this.data[row, col] = value; }
        }

        /// <summary>
        /// Mendapatkan array satu dimensi yang berisi nilai elemen
        /// matriks pada baris tertentu.
        /// </summary>
        /// <param name="row">Integer. Baris yang dimaksud</param>
        /// <returns>Array Double satu dimensi</returns>
        public double[] GetRowData(int row)
        {
            double[] result = new double[this.cols];
            for (int i = 0; i < this.cols; i++)
            {
                result[i] = this.data[row, i];
            }
            return result;
        }

        /// <summary>
        /// Mendapatkan array satu dimensi yang berisi nilai elemen
        /// matriks pada baris tertentu.
        /// </summary>
        /// <param name="row">Integer. Baris yang dimaksud</param>
        /// <returns>Array Double satu dimensi</returns>
        public double[] GetRowDataSquare(int row)
        {
            double[] result = new double[this.cols];
            for (int i = 0; i < this.cols; i++)
            {
                result[i] = this.data[row, i] * this.data[row, i];
            }
            return result;
        }

        /// <summary>
        /// Mendapatkan array satu dimensi yang berisi nilai elemen
        /// matriks pada kolom tertentu.
        /// </summary>
        /// <param name="col">Integer. Kolom yang dimaksud</param>
        /// <returns>Array Double satu dimensi</returns>
        public double[] GetColData(int col)
        {
            double[] result = new double[this.rows];
            for (int i = 0; i < this.rows; i++)
            {
                result[i] = this.data[i, col];
            }
            return result;
        }

        /// <summary>
        /// Mendapatkan array satu dimensi yang berisi nilai elemen kuadrat
        /// matriks pada kolom tertentu.
        /// </summary>
        /// <param name="col">Integer. Kolom yang dimaksud</param>
        /// <returns>Array Double satu dimensi</returns>
        public double[] GetColDataSquare(int col)
        {
            double[] result = new double[this.rows];
            for (int i = 0; i < this.rows; i++)
            {
                result[i] = this.data[i, col] * this.data[i, col]; ;
            }
            return result;
        }

        /// <summary>
        /// Mendapatkan array satu dimensi yang berisi jumlah data dari         
        /// matriks pada seluruh kolom.
        /// </summary>        
        /// <returns>Array Double satu dimensi</returns>
        public double[] GetSumColData()
        {
            double[] result = new double[this.cols];
            for (int i = 0; i < this.cols; i++)
            {
                result[i] = 0;
                for (int j = 0; j <= this.rows; j++)
                {
                    result[i] += this.data[i, j];
                }
            }
            return result;
        }
        
        /// <summary>
        /// Mendapatkan array dua dimensi yang berisi nilai elemen matriks        
        /// </summary>
        /// <returns>Array Double dua dimensi</returns>
        public double[,] GetData()
        {
            return this.data;
        }

        /// <summary>
        /// Mendapatkan copy dari matriks
        /// </summary>
        /// <returns>Matrix. Matriks copy</returns>
        public Matrix Copy()
        {
            Matrix result = new Matrix(rows, cols);

            for (int i = 0; i < result.rows; i++)
                for (int j = 0; j < result.cols; j++)
                    result[i, j] = data[i, j];

            return result;
        }

        /// <summary>
        /// Mendapatkan matriks transpose
        /// </summary>
        /// <returns>Matrix. Matriks transpose</returns>
        public Matrix GetTranspose()
        {
            Matrix result = new Matrix(cols, rows);

            for (int i = 0; i < result.rows; i++)
                for (int j = 0; j < result.cols; j++)
                    result[i, j] = data[j, i];

            return result;
        }

        #endregion

        #region Boolean Member
        /// <summary>
        /// Apakah matriks persegi?
        /// </summary>
        /// <returns>
        /// Boolean. Matriks persegi?
        /// <c>True</c> Jika matriks persegi
        /// <c>False</c> Jika bukan matriks persegi
        /// </returns>
        public bool IsSquare()
        {
            bool result = false;
            if (this.cols == this.rows) result = true;
            return result;
        }

        /// <summary>
        /// Apakah matriks diagonal?
        /// </summary>
        /// <returns>Boolean. Matriks diagonal?
        /// <c>True</c> Jika matriks diagonal
        /// <c>False</c> Jika bukan matriks diagonal
        /// </returns>
        public bool IsDiagonal()
        {
            bool result = true;
            if (IsSquare())
            {
                for (int i = 0; i < this.rows; i++)
                {
                    for (int j = 0; j < this.rows; j++)
                    {
                        if (i != j && this.data[i, j] != 0.0D)
                        {
                            result = false;
                            break;
                        }
                    }
                    if (result == false) break;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Apakah matriks identitas?
        /// </summary>
        /// <returns>Boolean. Matriks identitas?
        /// <c>True</c> Jika matriks identitas
        /// <c>False</c> Jika bukan matriks identitas
        /// </returns>
        public bool IsIdentity()
        {
            bool result = true;
            if (IsDiagonal())
            {
                for (int i = 0; i < this.rows; i++)
                {
                    if (this.data[i, i] != 1.0D)
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
            return result;
        }

        /// <summary>
        /// Apakah matriks singular? (determinan = 0)
        /// </summary>
        /// <returns>Boolean. Matriks Singular?
        /// <c>True</c> Jika matriks singular
        /// <c>False</c> Jika bukan matriks singular
        /// </returns>
        public bool IsSingular()
        {
            bool isSingular, detChange;
            Matrix L, U;
            Queue<int> sourceInterchange, destinationInterchange;

            this.getLUDecomposition(out L, out U, out detChange, out isSingular,
                out sourceInterchange, out destinationInterchange);

            return isSingular;
        }

        #endregion


        // Gaussian Elimination : referensi buku Fundamentals of Matrix Computations
        // David S. Watkins.   1991    . Canada: John Wiley & Sons, Inc
        #region Gaussian Elimination

        /// <summary>
        /// Melakukan pertukaran baris pada suatu matriks
        /// </summary>
        /// <param name="source">nomor baris sumber</param>
        /// <param name="destination">nomor baris tujuan</param>
        public void RowInterchange(int source, int destination)
        {
            double tmp;
            for (int i = 0; i < cols; i++)
            {
                tmp = data[source, i];
                data[source, i] = data[destination, i];
                data[destination, i] = tmp;
            }
        }

        /// <summary>
        /// Melakukan pertukaran kolom pada suatu matriks
        /// </summary>
        /// <param name="source">nomor kolom sumber</param>
        /// <param name="destination">nomor kolom tujuan</param>
        public void ColInterchange(int source, int destination)
        {
            double tmp;
            for (int i = 0; i < rows; i++)
            {
                tmp = data[i, source];
                data[i, source] = data[i, destination];
                data[i, destination] = tmp;
            }
        }

        /// <summary>
        /// Dekomposisi LU
        /// Memecah matriks menjadi dua lower triangular dan upper triangular
        /// L * U =A
        /// </summary>
        /// <param name="L">Matrix. Out. lower triangular matrix</param>
        /// <param name="U">Matrix. Out. upper triangular matrix</param>
        /// <param name="detChange">Boolean. Apakah terjadi pergantian tanda determinan
        /// karena pertukaran kolom / baris (interchange)</param>
        /// <param name="isSingular">Boolean. Apakah matriks singular?</param>
        /// <param name="sourceInterchange">Stack. Rekaman baris/kolom sumber
        /// proses pertukaran (interchange)</param>
        /// <param name="destinationInterchange">Stack. Rekaman baris/kolom tujuan
        /// proses pertukaran (interchange)</param>
        private void getLUDecomposition(out Matrix L, out Matrix U,
            out bool detChange, out bool isSingular,
            out Queue<int> sourceInterchange, out Queue<int> destinationInterchange)
        {
            Matrix LU = new Matrix(data, rows, cols);
            L = new Matrix(rows, cols);
            U = new Matrix(rows, cols);
            sourceInterchange = new Queue<int>();
            destinationInterchange = new Queue<int>();

            detChange = false;
            isSingular = false;

            int imax = 0;
            double amax;

            for (int i = 0; i < LU.Cols; i++)
            {
                imax = -1;
                amax = 0;

                // cari pivot maksimal
                for (int j = i; j < LU.Rows; j++)
                {
                    if (Math.Abs(LU[j, i]) > amax)
                    {
                        amax = Math.Abs(LU[j, i]);
                        imax = j;
                    }
                }

                if (amax == 0)
                {
                    // singular
                    isSingular = true;
                    //break;

                    // jika singular, proses dekomposisi berhenti,
                    // error akan dilempar oleh proses yang memanggil
                }
                else
                {
                    if (imax != i)
                    {
                        // row interchange
                        LU.RowInterchange(imax, i);
                        detChange = !detChange;

                        // rekam row interchange
                        sourceInterchange.Enqueue(imax);
                        destinationInterchange.Enqueue(i);
                    }

                    for (int j = i + 1; j < LU.Rows; j++)
                        LU[j, i] = LU[j, i] / LU[i, i];

                    for (int j = i + 1; j < LU.Rows; j++)
                        for (int k = i + 1; k < LU.Cols; k++)
                            LU[j, k] -= LU[j, i] * LU[i, k];
                }
            }

            // mengisi nilai matriks lower triangular
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < i; j++)
                    L[i, j] = LU[i, j];
            for (int i = 0; i < rows; i++)
                L[i, i] = 1.0;

            // mengisi nilai matriks upper triangular
            for (int i = 0; i < rows; i++)
                for (int j = i; j < cols; j++)
                    U[i, j] = LU[i, j];

        }

        /// <summary>
        /// Mendapatkan nilai determinan untuk matriks persegi
        /// </summary>
        /// <returns>Double. Nilai determinan</returns>
        public double GetDeterminant()
        {
            if (this.IsSquare())
            {
                bool isSingular, detChange;
                Matrix L, U;
                double det = 1.0;
                Queue<int> sourceInterchange, destinationInterchange;

                this.getLUDecomposition(out L, out U, out detChange, out isSingular,
                    out sourceInterchange, out destinationInterchange);

                for (int i = 0; i < U.Rows; i++)
                {
                    det *= U[i, i];
                }

                if (detChange) det = -det;

                return det;
            }
            else
            {
                throw new NonSquareMatrixException();
            }
        }

        /// <summary>
        /// Memecahkan persamaan A * X = B
        /// dimana A adalah matriks ini (this)
        /// B adalah matriks input
        /// X adalah matriks yang dicari.
        /// Dilakukan dengan mendekomposisi A menjadi LU terlebih dahulu
        /// </summary>
        /// <param name="B">Matrix. Matriks input</param>
        /// <returns>Matrix. Matriks hasil</returns>
        public Matrix Solve(Matrix B)
         {
            if (!this.IsSquare())
                throw new NonSquareMatrixException();

            if (B.Rows != rows)
                throw new WrongMatrixSizeException();

            bool isSingular, detChange;
            Matrix L, U;
            Queue<int> sourceInterchange, destinationInterchange;            

            this.getLUDecomposition(out L, out U, out detChange, out isSingular,
                out sourceInterchange, out destinationInterchange);
            
            while (sourceInterchange.Count > 0)
            {
                B.RowInterchange(sourceInterchange.Dequeue(), destinationInterchange.Dequeue());
            }       

            if (isSingular)
                throw new SingularMatrixException();

            Matrix X = new Matrix(rows, B.Cols);
            Matrix Y = new Matrix(rows, B.Cols);


            // Memecahkan persamaan L*Y = B
            for (int i = 0; i < B.Cols; i++)
            {
                Y[0, i] = B[0, i] / L[0, 0];
                for (int j = 1; j < B.Rows; j++)
                {
                    Y[j, i] = B[j, i];
                    if (L[j, j] == 0)
                        break;
                    for (int k = 0; k < j; k++)
                    {
                        Y[j, i] -= Y[k, i] * L[j, k];
                    }
                    Y[j, i] /= L[j, j];
                }
            }

            // Memecahkan persamaan U*X = Y
            for (int i = B.Cols - 1; i >= 0; i--)
            {
                X[B.Rows - 1, i] = Y[B.Rows - 1, i] / U[B.Rows - 1, B.Rows - 1];
                for (int j = B.Rows - 2; j >= 0; j--)
                {
                    X[j, i] = Y[j, i];
                    if (U[j, j] == 0)
                        break;
                    for (int k = B.Rows - 1; k > j; k--)
                    {
                        X[j, i] -= X[k, i] * U[j, k];
                    }
                    X[j, i] /= U[j, j];
                }
            }

            return X;
        }

        /// <summary>
        /// Memecahkan persamaan A * X = B
        /// dimana A adalah matriks ini (this)
        /// B adalah vektor input
        /// X adalah vektor yang dicari.
        /// Dilakukan dengan mendekomposisi A menjadi LU terlebih dahulu
        /// </summary>
        /// <param name="B">Vector. Vektor input</param>
        /// <returns>Vector. Vektor hasil</returns>
        public Vector Solve(Vector B)
        {
            Matrix inp = new Matrix(B.Tuples, 1);
            Matrix outp = new Matrix(B.Tuples, 1);
            Vector result = new Vector(B.Tuples,Vector.VectorType.ColumnVector);

            if (B.Type == Vector.VectorType.RowVector)
                throw new WrongVectorTypeException("Only ColumnVector valid");

            for (int i = 0; i < B.Tuples; i++)
                inp[i,0] = B[i];

            outp = this.Solve(inp);

            for (int i = 0; i < outp.Rows; i++)
                result[i] = outp[i,0];

            return result;
        }

        /// <summary>
        /// Mendapatkan invers dari matriks persegi
        /// Hanya untuk matriks non singular.
        /// Dilakukan dengan memecahkan persamaan A * A' = I
        /// </summary>
        /// <returns>Matrix. Matriks Invers</returns>
        public Matrix GetInverse()
        {
            if (this.IsSquare())
            {
                return this.Solve(Matrix.CreateIdentity(rows));
            }
            else
            {
                throw new NonSquareMatrixException();
            }
        }

        #endregion

        #region Static Member
        /// <summary>
        /// Membuat matriks identitas dengan jumlah baris/kolom tertentu
        /// </summary>
        /// <param name="n">Jumlah baris/kolom</param>
        /// <returns>Matrix. Matriks identitas n x n</returns>
        public static Matrix CreateIdentity(int n)
        {
            Matrix Identity = new Matrix(n, n);

            for (int i = 0; i < n; i++)
                Identity[i, i] = 1.0D;

            return Identity;
        }

        /// <summary>
        /// Mengecek apakah dua matriks mempunyai ukuran sama
        /// </summary>
        /// <param name="a">Matrix. Matriks pertama</param>
        /// <param name="b">Matrix. Matriks kedua</param>
        /// <returns>
        /// Boolean. Apakah sama ukurannya?
        /// <c>True</c> Jika ukurannya sama
        /// <c>False</c> Jika ukurannya tidak sama
        /// </returns>
        public static bool IsSameSize(Matrix a, Matrix b)
        {
            bool result = false;
            if (a.Cols == b.Cols && a.Rows == b.Rows)
                result = true;
            return result;
        }

        /// <summary>
        /// Mengecek apakah dua matriks dapat dilakukan operasi perkalian
        /// </summary>
        /// <param name="a">Matrix. Matriks pertama</param>
        /// <param name="b">Matrix. Matriks kedua</param>
        /// <returns>
        /// Boolean. Apakah dua matriks dapat dikalikan?
        /// <c>True</c> Jika matriks dapat dikalikan
        /// <c>False</c> Jika matriks tidak dapat dikalikan
        /// </returns>
        public static bool CanMultiply(Matrix a, Matrix b)
        {
            bool result = false;
            if (a.Cols == b.Rows)
                result = true;
            return result;
        }

        /// <summary>
        /// Operator overloading. Operasi penjumlahan matriks
        /// </summary>
        /// <param name="a">Matrix. Matriks pertama</param>
        /// <param name="b">Matrix. Matriks kedua</param>
        /// <returns>Matrix. Matriks hasil penjumlahan</returns>
        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix result = new Matrix(a.Rows, a.Cols);

            if (Matrix.IsSameSize(a, b))
            {
                for (int i = 0; i < a.Rows; i++)
                    for (int j = 0; j < a.Cols; j++)
                        result[i, j] = a[i, j] + b[i, j];
            }
            else
            {
                throw new NotSameSizeMatrixException();
            }

            return result;
        }

        /// <summary>
        /// Operator overloading. Operasi pengurangan matriks
        /// </summary>
        /// <param name="a">Matrix. Matriks pertama</param>
        /// <param name="b">Matrix. Matriks kedua</param>
        /// <returns>Matrix. Matriks hasil pengurangan</returns>
        public static Matrix operator -(Matrix a, Matrix b)
        {
            Matrix result = new Matrix(a.Rows, a.Cols);

            if (Matrix.IsSameSize(a, b))
            {
                for (int i = 0; i < a.Rows; i++)
                    for (int j = 0; j < a.Cols; j++)
                        result[i, j] = a[i, j] - b[i, j];
            }
            else
            {
                throw new NotSameSizeMatrixException();
            }

            return result;
        }

        /// <summary>
        /// Operator overloading. Operasi perkalian matriks dengan konstanta
        /// (perkalian skalar)
        /// </summary>
        /// <param name="constant">Double. konstanta/skalar</param>
        /// <param name="a">Matrix. Matriks yang dikalikan</param>
        /// <returns>Matrix. Hasil perkalian skalar</returns>
        public static Matrix operator *(double constant, Matrix a)
        {
            Matrix result = new Matrix(a.Rows, a.Cols);

            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    result[i, j] = constant * a[i, j];

            return result;
        }

        /// <summary>
        /// Operator overloading. Operasi perkalian matriks
        /// </summary>
        /// <param name="a">Matrix. Matriks pertama</param>
        /// <param name="b">Matrix. Matriks kedua</param>
        /// <returns>Matrix. Matriks hasil perkalian</returns>
        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix result = new Matrix(a.Rows, b.Cols);

            if (Matrix.CanMultiply(a, b))
            {
                for (int i = 0; i < a.Rows; i++)
                    for (int j = 0; j < b.Cols; j++)
                        for (int k = 0; k < b.Rows; k++)
                            result[i, j] += a[i, k] * b[k, j];
            }
            else
            {
                throw new WrongMatrixSizeException("Matrixs can't multiplied");
            }

            return result;
        }

        /// <summary>
        /// Operator overloading. Operasi kebalikan matriks
        /// </summary>
        /// <param name="a">Matrix. Matriks</param>
        /// <returns>Matrix. Hasil operasi kebalikan</returns>
        public static Matrix operator -(Matrix a)
        {
            return (-1 * a);
        }

        /// <summary>
        /// Operator overloading. Operasi logika apakah matriks a 
        /// sama dengan matriks b
        /// </summary>
        /// <param name="a">Matrix. Matriks pertama</param>
        /// <param name="b">Matrix. Matriks kedua</param>
        /// <returns>
        /// Boolean. Apakah dua matriks sama?
        /// <c>True</c> Jika dua matriks sama
        /// <c>False</c> Jika dua matriks tidak sama
        /// </returns>
        public static bool operator ==(Matrix a, Matrix b)
        {
            bool result = true;
            if (Matrix.IsSameSize(a, b))
            {
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Cols; j++)
                    {
                        if (a[i, j] != b[i, j])
                        {
                            result = false;
                            break;
                        }
                    }
                    if (result == false) break;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Operator overloading. Operasi logika apakah matriks a 
        /// tidak sama dengan matriks b
        /// </summary>
        /// <param name="a">Matrix. Matriks pertama</param>
        /// <param name="b">Matrix. Matriks kedua</param>
        /// <returns>
        /// Boolean. Apakah dua matriks tidak sama?
        /// <c>True</c> Jika dua matriks tidak sama
        /// <c>False</c> Jika dua matriks sama
        /// </returns>
        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }

        #endregion

        #region Override Member

        /// <summary>
        /// Override method. Apakah objek obj equal dengan nilai matriks?
        /// </summary>
        /// <param name="obj">Objek yang dicek equal atau tidak</param>
        /// <returns>
        /// Boolean. Apakah objek obj equal dengan nilai matriks?
        /// <c>True</c> Jika equal
        /// <c>False</c> Jika tidak
        /// </returns>
        public override bool Equals(object obj)
        {
            bool result;

            if (obj is Matrix)
            {
                Matrix b = (Matrix)obj;
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
        /// Override method. Mendapatkan nilai hash code
        /// </summary>
        /// <returns>hash code</returns>
        /// <remarks>Biasa digunakan untuk algoritma hashing 
        /// seperti pada pembuatan hash table</remarks>
        public override int GetHashCode()
        {
            return data.GetHashCode();

            //return base.GetHashCode();
        }

        #endregion
    }
}
