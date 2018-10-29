using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public class AmuletRepository
    {
        private List<Amulet> Amulets = new List<Amulet>();

        public void AddAmulet(Amulet amulet)
        {
            Amulets.Add(amulet);
        }

        public Amulet GetAmulet(int itemId)
        {
            if (itemId < Amulets.Count)
            {
                return Amulets[itemId];
            }
            return null;
        }

        public double GetTotalValue()
        {
            double total = 0;
            foreach (Amulet amulet in Amulets)
            {
                total += Utility.GetValueOfAmulet(amulet);
            }
            return total;
        }
    }
}
