using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public class CourseRepository
    {
        private List<Course> Courses = new List<Course>();

        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }

        public Course GetCourse(int itemId)
        {
            if (itemId < Courses.Count)
            {
                return Courses[itemId];
            }
            return null;
        }

        public double GetTotalValue()
        {
            double total = 0;
            foreach (Course course in Courses)
            {
                total += Utility.GetValueOfCourse(course);
            }
            return total;
        }
    }
}
