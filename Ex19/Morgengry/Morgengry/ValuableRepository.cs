using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public class ValuableRepository
    {
        private List<IValuable> Valuables = new List<IValuable>();

        public void AddValuable(IValuable valuable)
        {
            Valuables.Add(valuable);
        }

        public IValuable GetValuable(string itemId)
        {
            foreach (Book book in Valuables.OfType<Book>())
            {
                if (book.ItemId == itemId)
                {
                    return book;
                }
            }
            return null;
        }

        public double GetTotalValue()
        {
            double total = 0;
            foreach (IValuable valuable in Valuables)
            {
                total += valuable.GetValue();
            }
            return total;
        }

        public int Count()
        {
            return Valuables.Count;
        }
    }
}
