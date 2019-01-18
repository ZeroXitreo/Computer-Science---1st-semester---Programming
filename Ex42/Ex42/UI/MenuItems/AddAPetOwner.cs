using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartMenuLibrary;
using System.Threading.Tasks;
using Application;

namespace UI.MenuItems
{
    class AddAPetOWner : IMenuItem
    {
        public bool Activate(SmartMenu smartMenu)
        {
            Controller ctrl = new Controller();

            string lastName = Request.String($"Last name");
            string firstName = Request.String($"First name");
            string phoneNumber = Request.String($"Phonenumber");
            string email = Request.String($"Email");

            ctrl.InsertPetOwner(lastName, firstName, phoneNumber, email);

            return false;
        }

        public override string ToString() => "Add a pet owner";
    }
}
