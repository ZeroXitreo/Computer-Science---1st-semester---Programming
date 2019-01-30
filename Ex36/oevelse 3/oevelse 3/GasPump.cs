using System;

namespace oevelse_3
{
    internal class GasPump : Subject, IObserver
    {
        private int v;

        public GasPump(int v)
        {
            this.v = v;
        }

        internal void Pump(double v)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        internal void SelectFuel(FuelType alcoOxygen)
        {
            throw new NotImplementedException();
        }
    }
}