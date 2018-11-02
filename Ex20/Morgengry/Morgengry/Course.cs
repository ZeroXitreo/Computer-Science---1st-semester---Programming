using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public class Course : IValuable
    {
        public string Name;
        public int DurationInMinutes;
        public double CourseHourValue { get; set; } = 825;

        public Course(string name, int durationInMinutes = 0)
        {
            Name = name;
            DurationInMinutes = durationInMinutes;
        }

        public double GetValue()
        {
            double hours = Math.Ceiling(DurationInMinutes / 60d);
            return hours * CourseHourValue;
        }

        new
        public string ToString()
        {
            return string.Format("Name: {0}, Duration in Minutes: {1}, Pris pr påbegyndt time: {2}", Name, DurationInMinutes, CourseHourValue);
        }
    }
}
