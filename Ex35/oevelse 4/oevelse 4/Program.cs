using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevelse_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Headquater hq = new Headquater("RocketFuel");

            Station s1 = new Station(hq, "Herning", Region.Jutland);
            hq.Attach(s1);
            Station s2 = new Station(hq, "Odense", Region.Funen);
            hq.Attach(s2);
            Station s3 = new Station(hq, "Vigersted", Region.Zealand);
            hq.Attach(s3);

            hq.KeroOxygen = 20;

            hq.KeroOxygen = 35;

            hq.KeroOxygen = 32;
        }
    }
}
