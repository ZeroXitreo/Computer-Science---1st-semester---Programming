using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApp
{
    class Teacher : Person
    {
        public string JobTitle;

        public Teacher(string name, string jobTitle) : base(name)
        {
            JobTitle = jobTitle;
        }
    }
}
