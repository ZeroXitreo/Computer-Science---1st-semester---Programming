using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public class Utility
    {
        public static double GetValueOfBook(Book book)
        {
            return book.Price;
        }

        public static double GetValueOfAmulet(Amulet amulet)
        {
            double price;

            switch (amulet.Quality)
            {
                case Level.low:
                    price = 12.5;
                    break;
                default:
                case Level.medium:
                    price = 20d;
                    break;
                case Level.high:
                    price = 27.5;
                    break;
            }

            return price;
        }

        public static double GetValueOfCourse(Course course)
        {
            return course.DurationInMinutes * 2625d / 157d;
        }
    }
}
