using System;
using System.Collections.Generic;
using System.Text;
using Encog.Neural.Activation;

namespace zaitun.NeuralNetwork
{
    /// <summary>
    /// Fungsi sigmoid
    /// </summary>
    public class SigmoidFunction : IActivationFunction
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
            return (1.0 / (1.0 + Math.Exp(-d)));
        }

        public double DerivativeFunction(double d)
        {
            double fd = this.ActivationFunction(d);

            return (fd * (1.0 - fd));
        }

    }
}
