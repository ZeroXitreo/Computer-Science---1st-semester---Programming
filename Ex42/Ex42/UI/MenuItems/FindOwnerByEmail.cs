using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartMenuLibrary;
using System.Threading.Tasks;
using Application;
using Logic;

namespace UI.MenuItems
{
    class FindOwnerByEmail : IMenuItem
    {
        public bool Activate(SmartMenu smartMenu)
        {
            Controller ctrl = new Controller();

            string firstName = Request.String($"First name");
            string email = Request.String($"Email");

            Owner owner = ctrl.FindOwnerByEmail(firstName, email);

            if (owner is null)
            {
                Console.WriteLine("None found");
            }
            else
            {
                Console.WriteLine($"{owner.FirstName} {owner.LastName}");
            }

            Console.ReadKey(true);

            return false;
        }

        public override string ToString() => "Find owner by email";
    }
}
