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
    class FindOwnerByLastName : IMenuItem
    {
        public bool Activate(SmartMenu smartMenu)
        {
            Controller ctrl = new Controller();

            string lastName = Request.String($"Last name");

            Owner owner = ctrl.FindOwnerByLastname(lastName);

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

        public override string ToString() => "Find owner by last name";
    }
}
