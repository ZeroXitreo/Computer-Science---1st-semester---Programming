using System;

namespace oevelse_3
{
    internal class PriceBoard : IObserver
    {
        public void Update(Subject subject)
        {
            GasStation gs = (GasStation)subject;

            Console.WriteLine($"  Lysskilt på tankstation i {gs.City}({gs.Region}):");

            double totalPrice = gs.GasCompany.BasePrice;
            totalPrice *= (double)gs.Region / 100d;

            foreach (FuelType fuelType in Enum.GetValues(typeof(FuelType)))
            {
                double fuelPrice = totalPrice;
                fuelPrice *= (double)fuelType / 100d;

                if (gs.Discount)
                {
                    fuelPrice *= 0.9; // 10% off
                }

                Console.WriteLine($"    {fuelType}: {fuelPrice} kr / liter");
            }
        }
    }
}