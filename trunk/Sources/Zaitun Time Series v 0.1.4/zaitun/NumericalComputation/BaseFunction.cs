using System;
using System.Collections.Generic;
using System.Text;

namespace zaitun.NumericalComputation
{
    public abstract class BaseFunction
    {
        public abstract double Function(double input);

        public abstract double Gradient(double input);
    }
}
