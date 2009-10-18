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
using zaitun.Data;
using zaitun.MatrixVector;
using zaitun.Distribution;

namespace zaftime.ARCH
{
    /// <summary>
    /// Kelas untuk melakukan pencarian nilai optimum pada suatu fungsi yang dimasukan
    /// Bisa diterapkan pada semua fungsi termasuk pencarian nilai maksimum Likelihood.
    /// </summary>
    public class QuasiNewton
    {
        //Vector nilai awal
        private Vector initialPoint;
        //Matrix turunan kedua (Hessian)
        private Matrix hessian;
        //nilai tolerance untuk turunan pertama
        private double gradtolerance;
        //Nilai toleransi untuk mencapai konvergen
        private double tolerance;
        //Nilai toleransi untuk pengurangan antara previusFunction dengan currentFunction
        private double functolerance;
        //Jumlah dimensi/parameter yang akan diestimasi
        private int inputDimension;
        //Nilai batas maksimum dari iterasi
        private int maximumIteration;
        //Jumlah iterasi yang dihasilkan
        private int iteration;
        //fungsi yang akan dicari nilai optimumnya
        private BaseFunction function;
        //Nilai optimum dari fungsi
        private double optimumValue;
        // Hasil penghitungan, konvergen atau tidak
        private bool isConvergence;

        /// <summary>
        /// Constructor, Statement-statement yang pertama kali dieksekusi ketika inisialisasi Object 
        /// Memberikan setting terhadap nilai-nilai untuk optimasi sesuai nilai-nilai yang dimasukan.
        /// </summary>
        /// <param name="inputDimension">Integer. Dimensi parameter yang akan dicari nilai optimumnya</param>
        /// <param name="function">BaseFunction. Fungsi yang akan dioptimasi</param>
        /// <param name="tolerance">Double. Batas toleransi kekonvergenan dari metode optimasi</param>
        /// <param name="maximumIteration">Integer. Batas maksimum itersi yang digunakan</param>
        public QuasiNewton(int inputDimension, BaseFunction function, double tolerance, int maximumIteration)
        {
            this.inputDimension = inputDimension;
            this.initialPoint = new Vector(inputDimension);
            this.initialPoint.InitializeAllValue(1);
            this.hessian = Matrix.CreateIdentity(inputDimension);
            this.tolerance = tolerance;
            this.gradtolerance = tolerance;
            this.functolerance = tolerance;            
            this.maximumIteration = maximumIteration;
            this.function = function;
        }

        /// <summary>
        /// Constructor, Statement-statement yang pertama kali dieksekusi ketika inisialisasi Object 
        /// Memberikan setting terhadap nilai-nilai untuk optimasi sesuai nilai-nilai yang dimasukan.
        /// </summary>
        /// <param name="inputDimension">Integer. Dimensi parameter yang akan dicari nilai optimumnya</param>
        /// <param name="function">BaseFunction. Fungsi yang akan dioptimasi</param>
        /// <param name="tolerance">Double. Batas toleransi kekonvergenan dari metode optimasi</param>
        /// <param name="maximumIteration">Integer. Batas maksimum itersi yang digunakan</param>
        /// <param name="initialPoint">Vector. Nilai-nilai parameter yang digunakan sebagai initial value (starting point)</param>
        public QuasiNewton(int inputDimension, BaseFunction function, double tolerance, int maximumIteration, Vector initialPoint)
            : this(inputDimension, function, tolerance, maximumIteration)
        {
            this.initialPoint = initialPoint;
        }

        /// <summary>
        /// Fungsi untuk pencarian nilai optimum metode Quasi Newton dengan algoritma DFP
        /// Diperkenalkan oleh Davidon, Fletcher dan Powell, sehingga sering dikenal dengan sebutan DFP Algorithm
        /// </summary>
        /// <returns>Vector. Nilai parameter optimum</returns>
        public Vector DFPOptimize()
        {
            double previousFunction = double.MaxValue;
            double currentFunction = double.MaxValue;

            Matrix H;
            Vector x, x1, lastX, s, g, gamma, delta;
            double alpha, sTg, error;

            this.iteration = 0;

            // iterasi 0, inisialisasi, 
            // x diinisialisasi dengan initial point, H (hessian) dinisialisasi dengan matrix identitas
            x = this.initialPoint;
            H = this.hessian;

            Vector nullVector = new Vector(x.Tuples);
            nullVector.InitializeAllValue(0);
         
            do
            {
                iteration++;                

                previousFunction = this.function.Function(x);
                lastX = x;

                //g = gradient/turunan pertama fungsi
                g = this.function.Gradient(x);
                // s = search direction
                s = -1 * (H * g);
                // normalisasi pada nilai s
                s = (1 / s.Length) * s;

                // stg = nilai s transpose dikalikan dengan g (gradient), 
                // untuk digunakan pada pencarian nilai alpha
                sTg = Vector.DoubleMultiply(s.GetTranspose(), g);
                // Alpha = nilai unutk memaksimumkan fungsi f(x + alpha s)
                // dicari dengan algoritma "Fletcher Acceptability Criterion"
                // Sumber, buku "Numerical Methods And Analysis" karya Buchanan and Turner
                alpha = this.findAcceptableAlpha(x, s, sTg);

                if (alpha == 0) break;

                double alphaTemp = alpha;
                do
                {
                    alpha = alphaTemp;
                    delta = alpha * s;
                    x1 = x + delta;

                    // Perlakuan khusus ketika fungsi yang dihasilkan dari nilai alpha bernilai NaN
                    // alpha dipindahkan 0.95 kali alpha sebelumnya
                    alphaTemp = 0.95 * alpha;
                } while (double.IsNaN(this.function.Function(x1)));

                delta = alpha * s;
                x1 = x + delta;
                gamma = this.function.Gradient(x1) - g;
                x = x1;               
                currentFunction = this.function.Function(x);

                // meng-update nilai Hessian baru dengan algoritma BFGS
                Vector Hy = H * gamma;
                Matrix M = (1 / (Vector.DoubleMultiply(gamma.GetTranspose(), Hy))) * (Vector.MatrixMultiply(Hy, Hy.GetTranspose()));
                Matrix N = (1 / (Vector.DoubleMultiply(delta.GetTranspose(), gamma))) * (Vector.MatrixMultiply(delta, delta.GetTranspose()));

                H = H - M + N;
                
                g = this.function.Gradient(x);

                // error = selisih nilai fungsi sekarang dengan fungsi sebelumnya
                error = Math.Abs(currentFunction - previousFunction);

            } while (error > this.functolerance && g.Length > this.gradtolerance && g != nullVector && iteration < maximumIteration && (currentFunction - previousFunction) < this.tolerance);
          
            // Kondisi ketika fungsi semakin menaik/membesar
            if (currentFunction - previousFunction > 0)
            {
                this.optimumValue = Math.Min(currentFunction, previousFunction);
                x = lastX;
                this.isConvergence = false;

            }
            // Kondisi ketika fungsi yang dihasilkan bernilai NaN
            else if (double.IsNaN(currentFunction))
            {
                this.optimumValue = previousFunction;
                x = lastX;
                this.isConvergence = false;
            }
            // Kondisi ketika fungsi mencapai kekonvergenan
            else
            {
                this.optimumValue = currentFunction;
                this.isConvergence = true;
            }

            return x;
        }

        /// <summary>
        /// Fungsi untuk pencarian nilai optimum metode Quasi Newton dengan algoritma BFGS
        /// Diperkenalkan oleh Broyden, Fletcher, Goldfarb dan Shanno, sehingga sering dikenal dengan sebutan BFGS Algorithm
        /// </summary>
        /// <returns>Vector. Nilai parameter optimum</returns>
        public Vector BFGSOptimize()
        {
            double previousFunction = double.MaxValue;
            double currentFunction = double.MaxValue;

            Matrix H;
            Vector x, x1, lastX, s, g, gamma, delta;
            double alpha, sTg, error;

            this.iteration = 0;

            // iterasi 0, inisialisasi, 
            // x diinisialisasi dengan initial point, H (hessian) dinisialisasi dengan matrix identitas
            x = this.initialPoint;            
            H = this.hessian;

            Vector nullVector = new Vector(x.Tuples);
            nullVector.InitializeAllValue(0);

            do
            {
                iteration++;

                previousFunction = this.function.Function(x);
                lastX = x;

                //g = gradient/turunan pertama fungsi
                g = this.function.Gradient(x);
                // s = search direction
                s = -1 * (H * g);
                // normalisasi pada nilai s
                s = (1 / s.Length) * s;
                
                // stg = nilai s transpose dikalikan dengan g (gradient), 
                // untuk digunakan pada pencarian nilai alpha
                sTg = Vector.DoubleMultiply(s.GetTranspose(), g);
                // Alpha = nilai unutk memaksimumkan fungsi f(x + alpha s)
                // dicari dengan algoritma "Fletcher Acceptability Criterion"
                // Sumber, buku "Numerical Methods And Analysis" karya Buchanan and Turner
                alpha = this.findAcceptableAlpha(x, s, sTg);
               
                if (alpha == 0) break;
                
                double alphaTemp = alpha;
                do
                {
                    alpha = alphaTemp;
                    delta = alpha * s;
                    x1 = x + delta;

                    // Perlakuan khusus ketika fungsi yang dihasilkan dari nilai alpha bernilai NaN
                    // alpha dipindahkan 0.95 kali alpha sebelumnya
                    alphaTemp = 0.95 * alpha;
                } while (double.IsNaN(this.function.Function(x1)));


                delta = alpha * s;
                x1 = x + delta;
                gamma = this.function.Gradient(x1) - g;
                x = x1;
                currentFunction = this.function.Function(x);

                // meng-update nilai Hessian baru dengan algoritma BFGS
                Vector Hy = H * gamma;
                double gtx = Vector.DoubleMultiply(gamma.GetTranspose(), delta);
                double gtHy = Vector.DoubleMultiply(gamma.GetTranspose(), Hy);
                Matrix Hydt = Vector.MatrixMultiply(Hy, delta.GetTranspose());

                Matrix M = (1 / gtx) * (Hydt + Hydt.GetTranspose());
                Matrix N = (1 + (gtHy / gtx)) * (1 / (Vector.DoubleMultiply(delta.GetTranspose(), gamma))) * (Vector.MatrixMultiply(delta, delta.GetTranspose()));

                H = H - M + N;

                g = this.function.Gradient(x);
                // error = selisih nilai fungsi sekarang dengan fungsi sebelumnya
                error = Math.Abs(currentFunction - previousFunction);

            } while (error > this.functolerance && g.Length > this.gradtolerance && g != nullVector && iteration < maximumIteration && (currentFunction - previousFunction) < this.tolerance);


            // Kondisi ketika fungsi semakin menaik/membesar
            if (currentFunction - previousFunction > 0)
            {
                this.optimumValue = Math.Min(currentFunction, previousFunction);
                x = lastX;
                this.isConvergence = false;

            }
            // Kondisi ketika fungsi yang dihasilkan bernilai NaN
            else if (double.IsNaN(currentFunction))
            {
                this.optimumValue = previousFunction;
                x = lastX;
                this.isConvergence = false;
            }
            // Kondisi ketika fungsi mencapai kekonvergenan
            else
            {
                this.optimumValue = currentFunction;
                this.isConvergence = true;
            }

            return x;
        }      

        /// <summary>
        /// Fungsi untuk mendapatkan nilai alpha, yaitu nilai yang memaksimumkan fungsi f(x + alpha s)
        /// dicari dengan algoritma "Fletcher Acceptability Criterion"
        /// Sumber, buku "Numerical Methods And Analysis" karya Buchanan and Turner
        /// </summary>
        /// <param name="x">Vector. Nilai current X</param>
        /// <param name="s">Vector. Nilai current S</param>
        /// <param name="sTg">double. Nilai s transpose kali gradient</param>
        /// <returns></returns>
        private double findAcceptableAlpha(Vector x, Vector s, double sTg)
        {
            double mu = 0.00000001;
            double alpha = 1, mina = 0, maxa = 1;
            double aTemp = 1, f1;
            do
            {
                alpha = aTemp;
                f1 = alphaFunction(x, s, alpha);
                aTemp = 0.95 * alpha;

            } while (double.IsNaN(f1));

            double D;
            int iteration = 0;

            do
            {
                iteration++;
                D = (this.function.Function(x + alpha * s) - this.function.Function(x)) / (alpha * sTg);

                if (D > 1 - mu) //
                {
                    if (alpha == maxa)
                    {
                        mina = alpha;
                        maxa = 2 * alpha;
                        alpha = maxa;
                    }
                    else
                    {
                        mina = alpha;
                        alpha = (alpha + maxa) / 2;
                    }
                }

                if (D < mu)
                {
                    maxa = alpha;
                    alpha = (alpha + 3 * mina) / 4;
                }
            }
            while ((D < mu || D > 1 - mu) && iteration < 100);

            return alpha;
        }        
        /// <summary>
        /// Fungsi untuk penghitungan nilai fungsi pada fungsi f(x + alpha * s)
        /// </summary>
        /// <param name="x">Vector. Nilai current X</param>
        /// <param name="s">Vector. Nilai current S</param>
        /// <param name="alpha">double. Nilai alpha</param>
        /// <returns>double. nilai fungsi yang dihasilkan</returns>
        private double alphaFunction(Vector x, Vector s, double alpha)
        {
            return this.function.Function(x + alpha * s);
        }

        /// <summary>
        /// Fungsi untuk penghitungan nilai turunan pertama fungsi pada fungsi f(x + alpha * s)
        /// </summary>
        /// <param name="x">Vector. Nilai current X</param>
        /// <param name="s">Vector. Nilai current S</param>
        /// <param name="alpha">double. Nilai alpha</param>
        /// <returns>double. nilai turunan pertama fungsi yang dihasilkan</returns>
        private double alphaFunctionDerivative(Vector x, Vector s, double alpha)
        {
            double h = 0.00000001;

            return (this.alphaFunction(x, s, alpha + h) - this.alphaFunction(x, s, alpha)) / (h);
        }

        /// <summary>
        /// Properties untuk mendapatkan nilai optimum yang dhasilkan
        /// </summary>
        public double OptimumValue
        {
            get { return this.optimumValue; }
        }

        /// <summary>
        /// Properties untuk mendapatkan nilai apakah fungsi optimum yang dihasilkan konvergen atau tidak
        /// </summary>
        public bool IsConvergence
        {
            get { return this.isConvergence; }
        }

        /// <summary>
        /// Properties untuk mendapatkan jumlah iterasi yang dihasilkan
        /// </summary>
        public int Iteration
        {
            get { return this.iteration; }
        }
    }
}