using System;

namespace oevelse_3
{
    internal class GasPump : Subject, IObserver
    {
        public readonly int Number;
        public FuelType Fuel { get; private set; } = FuelType.HydroOxygen;
        public double Liters { get; internal set; }
        public double Price { get; internal set; }
        private GasStation gasStation;

        public GasPump(int number)
        {
            this.Number = number;
        }

        internal void Pump(double liters)
        {
            Liters = liters;
            Price = GetPrice(Fuel, Liters);
            Update(gasStation);
            Notify();
        }

        internal void SelectFuel(FuelType fuel)
        {
            this.Fuel = fuel;
        }

        public void Update(Subject subject)
        {
            if (subject != this)
            {
                gasStation = (GasStation)subject;
            }

            Console.WriteLine($"  Stander {Number} på tankstation i {gasStation.City}({gasStation.Region}):");

            string status;
            if (Liters > 0)
            {
                status = "Betal påfyldning";
            }
            else
            {
                status = "Klar til brug";
            }

            Console.WriteLine($"    Valgt brændstof: {Fuel}");
            Console.WriteLine($"    Antal liter:     {Liters} liter");
            Console.WriteLine($"    Pris:            {Price} kr");
            Console.WriteLine($"    Status:          {status}");

            foreach (FuelType fuelType in Enum.GetValues(typeof(FuelType)))
            {
                Console.WriteLine($"    {fuelType}: {GetPrice(fuelType)} kr/liter");
            }
        }

        private double GetPrice(FuelType fuelType, double liters = 1)
        {
            double totalPrice = gasStation.GasCompany.BasePrice;
            totalPrice *= (double)gasStation.Region / 100d;
            totalPrice *= (double)fuelType / 100d;

            if (gasStation.Discount)
            {
                totalPrice *= 0.9; // 10% off
            }

            totalPrice *= liters;

            return totalPrice;
        }
    }
}