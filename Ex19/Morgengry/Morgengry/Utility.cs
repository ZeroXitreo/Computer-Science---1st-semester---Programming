using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public class Utility
    {
        public static double LowQualityValue { get; set; } = 12.5;
        public static double MediumQualityValue { get; set; } = 20;
        public static double HighQualityValue { get; set; } = 27.5;
        public static double CourseHourValue { get; set; } = 875;

        public static double GetValueOfMerchandise(Merchandise merchandise)
        {
            if (merchandise is Amulet)
            {
                return GetValueOfAmulet((Amulet)merchandise);
            }
            else
            {
                return GetValueOfBook((Book)merchandise);
            }
        }

        private static double GetValueOfBook(Book book)
        {
            return book.Price;
        }

        private static double GetValueOfAmulet(Amulet amulet)
        {
            double price;

            switch (amulet.Quality)
            {
                case Level.low:
                    price = LowQualityValue;
                    break;
                default:
                case Level.medium:
                    price = MediumQualityValue;
                    break;
                case Level.high:
                    price = HighQualityValue;
                    break;
            }

            return price;
        }

        public static double GetValueOfCourse(Course course)
        {
            double hours = Math.Ceiling(course.DurationInMinutes / 60d);
            return hours * CourseHourValue;
        }
    }
}
