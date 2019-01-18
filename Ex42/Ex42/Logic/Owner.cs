using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Owner
    {
        public readonly int Id;
        public readonly string LastName;
        public readonly string FirstName;
        public readonly string Phone;
        public readonly string Email;

        public Owner(int id, string lastName, string firstName, string phone, string email)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Phone = phone;
            Email = email;
        }
    }
}
