using System;
using System.Collections.Generic;
using System.Text;

namespace zaitun.NumericalComputation
{
    public class Differential
    {
        public enum DiferentiationMethod
        {
            Backward,
            Central,
            Forward
        }

        private DiferentiationMethod method = DiferentiationMethod.Forward;
        private int h = 1000;
        private BaseFunction function;
        
        public Differential(BaseFunction function)
        {
            this.function = function;
        }

        public Differential(BaseFunction function, DiferentiationMethod method)
            : this(function)
        {
            this.method = method;
        }

        public Differential(BaseFunction function, int h)
            : this(function)
        {
            this.h = h;
        }

        public Differential(BaseFunction function, DiferentiationMethod method, int h)
            : this(function, method)
        {
            this.h = h;
        }

        public double GetFirstDifference(double x)
        {
            double result = 0.0;

            switch (this.method)
            {
                case DiferentiationMethod.Forward:
                    result = (function.Function(x + h) - function.Function(x)) / h; ;
                    break;
                case DiferentiationMethod.Central:
                    result = (function.Function(x + h) - function.Function(x - h)) / (2 * h);
                    break;
                case DiferentiationMethod.Backward:
                    result = (function.Function(x) - function.Function(x - h)) / h;
                    break;
            }

            return result;
        }

        public double GetSecondDifference(double x)
        {
            double result = 0.0;

            switch (this.method)
            {
                case DiferentiationMethod.Forward:
                    result = (function.Function(x + 2 * h) - 2 * function.Function(x + h) + function.Function(x))
                / (h * h);
                    break;
                case DiferentiationMethod.Central:
                    result = (function.Function(x + h) - 2 * function.Function(x) + function.Function(x - h))
                / (h * h);
                    break;
                case DiferentiationMethod.Backward:
                    result = (function.Function(x) - 2 * function.Function(x - h) + function.Function(x - 2 * h))
                / (h * h);
                    break;
            }

            return result;
        }



    }
}
