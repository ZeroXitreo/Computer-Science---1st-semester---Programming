using System;

namespace oevelse_3
{
    internal class GasStation : Subject, IObserver
    {
        private bool discount;
        public GasCompany GasCompany { get; private set; }

        public GasStation(RegionType region, string city)
        {
            Region = region;
            City = city;
        }

        public RegionType Region { get; private set; }
        public string City { get; private set; }
        public bool Discount
        {
            get
            {
                return discount;
            }
            set
            {
                discount = value;
                Notify();
            }
        }

        public void Update(Subject subject)
        {
            GasCompany = (GasCompany)subject;

            Notify();
        }
    }
}