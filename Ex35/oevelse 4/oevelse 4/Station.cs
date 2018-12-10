using Observation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevelse_4
{
    class Station : Observer
    {
        private Headquater Headquater;
        public string City { get; }
        public Region Region { get; }
        public double KeroOxygen { get; private set; }
        public double HydroOxygen { get; private set; }
        public double AlcoOxygen { get; private set; }

        public Station(Headquater headquater, string city, Region region)
        {
            Headquater = headquater;
            City = city;
            Region = region;
        }

        public override void Update()
        {
            double multiplier = (double) Region / 100d;

            KeroOxygen = Headquater.KeroOxygen * multiplier;
            HydroOxygen = Headquater.HydroOxygen * multiplier;
            AlcoOxygen = Headquater.AlcoOxygen * multiplier;

            Console.WriteLine(string.Format("{0}: ", City));
            Console.WriteLine(string.Format("   KO: {0}", KeroOxygen));
            Console.WriteLine(string.Format("   HO: {0}", HydroOxygen));
            Console.WriteLine(string.Format("   AO: {0}", AlcoOxygen));
        }
    }
}
