using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public class Book
    {
        public string ItemId;
        public string Title;
        public double Price;

        public Book(string itemId, string title = null, double price = 0)
        {
            ItemId = itemId;
            Title = title;
            Price = price;
        }

        new
        public string ToString()
        {
            return "ItemId: " + ItemId + ", Title: " + Title + ", Price: " + Price;
        }
    }
}
