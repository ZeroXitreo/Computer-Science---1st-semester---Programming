using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Controller
    {
        private OwnerRepo ownerRepo = new OwnerRepo();
        private PetRepo petRepo = new PetRepo();

        public Owner FindOwnerByLastname(string lastName)
        {
            return ownerRepo.FindOwnerByLastname(lastName);
        }

        public Owner FindOwnerByEmail(string firstName, string email)
        {
            return ownerRepo.FindOwnerByEmail(firstName, email);
        }

        public void InsertPet(string name, string type, string breed, string weight, string ownerId)
        {
            petRepo.InsertPet(name, type, breed, weight, ownerId);
        }

        public void InsertPetOwner(string lastName, string firstName, string phoneNumber, string email)
        {
            ownerRepo.InsertPetOwner(lastName, firstName, phoneNumber, email);
        }
        public List<Pet> ShowAllPets()
        {
            return petRepo.GetAllPets();
        }
    }
}
