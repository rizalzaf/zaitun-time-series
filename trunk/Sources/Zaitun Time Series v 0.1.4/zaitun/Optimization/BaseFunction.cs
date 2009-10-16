using System;
using System.Collections.Generic;
using System.Text;
using zaitun.Data;
using zaitun.MatrixVector;
using zaitun.Distribution;

namespace zaftime.ARCH
{
    /// <summary>
    /// Kelas abstrak yang merupakan Base Class (kelas induk) pada setiap class untuk suatu fungsi (persamaan).
    /// Berisi fungsi abstrak Function yang akan digunakan pada setiap fungsi turunnnya sesuai fungsi masing-masing, 
    /// serta fungsi virtual Gradient yang akan mengeksekusi turunan pertama dari fungsinya
    /// </summary>
    public abstract class BaseFunction
    {
        /// <summary>
        /// Fungsi Abstrak yang akan digunkakan pada setiap kelas turunannya sesuai fungsi masing-masing
        /// </summary>
        /// <param name="input">Vector. Vektor parameter yang dimasukkan</param>
        /// <returns>double. hasil penghitungan fungsi sesuai nilai masukkannya</returns>
        public abstract double Function(Vector input);        

        /// <summary>
        /// Fungsi Virtual unutk mendapatkan turunan pertama pada fungsi 
        /// </summary>
        /// <param name="input">Vector. Vector parameter yang dimasukkan</param>
        /// <returns>double. hasil penghitungan fungsi sesuai nilai masukkannya</returns>
        public virtual Vector Gradient(Vector input)
        {
            Vector result = new Vector(input.Tuples);
            Vector vh = new Vector(input.Tuples);
            double h = 0.000001;

            for (int i = 0; i < input.Tuples; i++)
            {
                vh.InitializeAllValue(0);
                vh[i] = h;

                result[i] = (this.Function(input + vh) - this.Function(input)) / h;
            }

            return result;
        }
    }
}
