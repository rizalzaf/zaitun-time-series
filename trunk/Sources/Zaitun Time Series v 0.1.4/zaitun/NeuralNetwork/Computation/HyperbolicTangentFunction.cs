using System;
using System.Collections.Generic;
using System.Text;
using Encog.Neural.Activation;

namespace zaitun.NeuralNetwork
{
    /// <summary>
    /// Fungsi tangen hiperbolik
    /// </summary>
    public class HyperbolicTangentFunction : IActivationFunction
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
            double result = (Math.Exp(d * 2.0) - 1.0)
                    / (Math.Exp(d * 2.0) + 1.0);
            return result;
        }

        public double DerivativeFunction(double d)
        {
            double fd = this.ActivationFunction(d);

            return 1.0 - Math.Pow(fd, 2.0);
        }
    }
}
