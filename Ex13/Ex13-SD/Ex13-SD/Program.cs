using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex13_SD
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            for (int i = 0; i < 3; i++)
            {
                Book book = new Book("Title");
                controller.AddBook(book);
            }

            Book gottenBook = controller.GetBook(2);
            Print(gottenBook);

            bool bookExists = controller.ExistBook(gottenBook.Title);
        }

        static void Print(Book book)
        {
            Console.WriteLine(book.Title);
        }
    }
}
