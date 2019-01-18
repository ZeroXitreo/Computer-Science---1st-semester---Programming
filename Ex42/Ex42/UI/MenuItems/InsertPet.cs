using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartMenuLibrary;
using System.Threading.Tasks;
using Application;

namespace UI.MenuItems
{
    class InsertPet : IMenuItem
    {
        public bool Activate(SmartMenu smartMenu)
        {
            Controller ctrl = new Controller();

            string name = Request.String("Name on the pet");
            string type = Request.String($"Type on {name}");
            string breed = Request.String($"Breed on {name}");
            string weight = Request.String($"Weight on {name}");
            string ownerId = Request.String($"Owner id on {name}");

            ctrl.InsertPet(name, type, breed, weight, ownerId);

            return false;
        }

        public override string ToString() => "Insert pet";
    }
}
