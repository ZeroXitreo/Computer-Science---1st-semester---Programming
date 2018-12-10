using Observation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevelse_4
{
    class Headquater : Subject
    {
        private double keroOxygen;

        public double KeroOxygen
        {
            get
            {
                return keroOxygen;
            }
            set
            {
                keroOxygen = value;
                Notify();
            }
        }
        public double HydroOxygen => keroOxygen * 1.1;
        public double AlcoOxygen => keroOxygen * .9;
        public string Name { get; }

        public Headquater(string name)
        {
            Name = name;
        }
    }
}
