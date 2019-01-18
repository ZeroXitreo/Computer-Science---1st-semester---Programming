using Application;
using Logic;
using SmartMenuLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.MenuItems
{
    class ShowAllPets : IMenuItem
    {
        public bool Activate(SmartMenu smartMenu)
        {
            Console.Clear();
            Controller ctrl = new Controller();

            List<Pet> pets = ctrl.ShowAllPets();

            foreach (Pet pet in pets)
            {
                Console.WriteLine(pet.Name);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);

            return false;
        }

        public override string ToString() => "Show all pets";
    }
}
