using System;

namespace oevelse_3
{
    internal class GasStation : IObserver
    {
        private RegionType region;
        private GasCompany gasCompany;

        public GasStation(RegionType region, string city)
        {
            this.region = region;
            City = city;
        }

        public object City { get; internal set; }
        public bool Discount { get; internal set; }

        public void Update(Subject subject)
        {
            Update((GasCompany)subject);
        }

        public void Update(GasCompany gasCompany)
        {
            this.gasCompany = gasCompany;
        }
    }
}