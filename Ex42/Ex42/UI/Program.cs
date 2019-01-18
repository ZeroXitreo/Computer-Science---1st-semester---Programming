using SmartMenuLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.MenuItems;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartMenu sm = new SmartMenu("Ex42", "Close program");

            sm.Attach(new InsertPet());
            sm.Attach(new ShowAllPets());
            sm.Attach(new AddAPetOWner());
            sm.Attach(new FindOwnerByLastName());
            sm.Attach(new FindOwnerByEmail());

            sm.Activate();
        }
    }
}
