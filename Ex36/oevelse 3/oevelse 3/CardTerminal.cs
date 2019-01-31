using System;
using System.Collections.Generic;

namespace oevelse_3
{
    internal class CardTerminal : IObserver
    {
        private readonly List<GasPump> gasPumps = new List<GasPump>();
        public void Update(Subject subject)
        {
            GasPump gasPump = (GasPump)subject;
            if (!gasPumps.Contains(gasPump))
            {
                gasPumps.Add(gasPump);
            }

            Console.WriteLine("  Betalingsautomat:");

            if (gasPumps.TrueForAll(o => o.Liters == 0))
            {
                Console.WriteLine("    Alt betalt.");
            }
            else
            {
                Console.WriteLine("    Ubetalte standere:");
                foreach (GasPump gp in gasPumps)
                {
                    if (gp.Liters != 0)
                    {
                        Console.WriteLine($"      Stander {gp.Number}: {gp.Liters} liter {gp.Fuel} til {gp.Price} kr.");
                    }
                }
                Console.WriteLine("    Vælg stander og betal.");
            }
        }

        internal void PayFilling(int v)
        {
            foreach (GasPump gasPump in gasPumps)
            {
                if (gasPump.Number == v)
                {
                    gasPump.Liters = 0;
                    gasPump.Price = 0;
                    gasPump.Update(gasPump);
                    Update(gasPump);
                }
            }
        }
    }
}