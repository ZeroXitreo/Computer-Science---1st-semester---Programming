using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public class MerchandiseRepository
    {
        private List<Merchandise> Merchandises = new List<Merchandise>();

        public void AddMerchandise(Merchandise merchandise)
        {
            Merchandises.Add(merchandise);
        }

        public Merchandise GetMerchandise(int itemId)
        {
            if (itemId < Merchandises.Count)
            {
                return Merchandises[itemId];
            }
            return null;
        }

        public double GetTotalValue()
        {
            double total = 0;
            foreach (Merchandise merchandise in Merchandises)
            {
                total += Utility.GetValueOfMerchandise(merchandise);
            }
            return total;
        }
    }
}
