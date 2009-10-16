using System;
using System.Collections.Generic;
using System.Text;
using Encog.Neural.Activation;

namespace zaitun.NeuralNetwork
{
    /// <summary>
    /// Fungsi semi linear
    /// </summary>
    public class SemiLinearFunction : IActivationFunction
    {  
        public String Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
      
        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        private String description;
        private String name;

        public double ActivationFunction(double d)
        {
            double result;

            if (d < -1) result = 0.0;
            else if (d > 1) result = 1.0;
            else result = (d / 2.0) + 1.0 / 2.0;

            return result;
        }

        public double DerivativeFunction(double d)
        {
            double result;

            if (d < -1 || d > 1) result = 0.0;
            else result = 0.5;

            return result;
        }

    }
}
