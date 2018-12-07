using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex33_linkedlist
{
    public class ClubMember
    {
        public int Number;
        public string Firstname;
        public string Lastname;
        public int Age;

        public ClubMember(int number, string firstname, string lastname, int age)
        {
            Number = number;
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Number, Firstname, Lastname, Age);
        }
    }
}
