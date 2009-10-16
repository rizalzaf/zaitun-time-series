using System;
using System.Collections.Generic;
using System.Text;

namespace zaitun.NumericalComputation
{
    public class Integral
    {
        public enum IntegrationMethod
        {
            Simpson,
            Trapezoid
        }

        private IntegrationMethod method = IntegrationMethod.Simpson;
        private int interval = 1000;
        private BaseFunction function;

        public Integral(BaseFunction function)
        {
            this.function = function;
        }

        public Integral(BaseFunction function, IntegrationMethod method)
            : this(function)
        {
            this.method = method;
        }

        public Integral(BaseFunction function, int interval)
            : this(function)
        {
            this.interval = interval;
        }

        public Integral(BaseFunction function, IntegrationMethod method, int interval)
            : this(function, method)
        {
            this.interval = interval;
        }

        public double GetIntegral(double x0, double x1)
        {
            double result = 0.0;
            switch (this.method)
            {
                case IntegrationMethod.Simpson: 
                    result = this.simpsonIntegral(x0, x1);
                    break;
                case IntegrationMethod.Trapezoid:
                    result = this.trapezoidIntegral(x0, x1);
                    break;
            }

            return result;
        }

        private double simpsonIntegral(double x0, double x1)
        {
            double h = (x1 - x0) / interval;
            double sum = (function.Function(x0) + 4 * function.Function(x1 - h) + function.Function(x1));

            double x2i_1, x2i;
            for (int i = 1; i <= (interval / 2) - 1; i++)
            {
                x2i_1 = x0 + (2 * i - 1) * h;
                x2i = x0 + (2 * i) * h;
                sum += 4 * function.Function(x2i_1) + 2 * function.Function(x2i);
            }

            return (h / 3) * sum;
        }

        private double trapezoidIntegral(double x0, double x1)
        {
            double h = (x1 - x0) / interval;
            double init = (h / 2) * (function.Function(x0) + function.Function(x1));

            double xn = x0 + h;
            double sum = 0.0;
            for (int i = 1; i < interval; i++)
            {
                sum += function.Function(xn);
                xn += h;
            }

            return sum * h + init;
        }

    }
}
