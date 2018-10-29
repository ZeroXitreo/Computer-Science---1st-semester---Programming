using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public class BookRepository
    {
        private List<Book> Books = new List<Book>();

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public Book GetBook(int itemId)
        {
            if (itemId < Books.Count)
            {
                return Books[itemId];
            }
            return null;
        }

        public double GetTotalValue()
        {
            double total = 0;
            foreach (Book book in Books)
            {
                total += Utility.GetValueOfBook(book);
            }
            return total;
        }
    }
}
