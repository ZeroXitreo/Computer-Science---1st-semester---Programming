using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> bookList = new List<Book>();

            bookList.Add(new Book
            {
                Title = "Get out of my store"
            });
            bookList.Add(new Book
            {
                Title = "Holy shit, it's alive!"
            });
            bookList.Add(new Book
            {
                Title = "Your mother and me on adventure"
            });

            foreach (Book bookItem in bookList)
            {
                Console.WriteLine(bookItem.Title);
            }
            Console.ReadKey();
        }
    }
}
