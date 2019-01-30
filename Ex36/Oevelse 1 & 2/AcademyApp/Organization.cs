using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApp
{
    class Organization
    {
        public string Address;

        public Organization(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; private set; }
    }
}
