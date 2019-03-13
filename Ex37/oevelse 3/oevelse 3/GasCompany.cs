using System;
using System.Collections.Generic;

namespace oevelse_3
{
    internal class GasCompany : Subject
    {
        private double basePrice;

        public double BasePrice
        {
            get
            {
                return basePrice;
            }
            set
            {
                basePrice = value;
                Notify();
            }
        }
    }
}