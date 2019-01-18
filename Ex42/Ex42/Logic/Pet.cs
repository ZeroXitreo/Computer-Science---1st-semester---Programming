using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Pet
    {
        public readonly int Id;
        public readonly string Name;
        public readonly string Type;
        public readonly string Breed;
        public readonly string DOB;
        public readonly string Weight;
        public readonly string OwnerId;

        public Pet(int id, string name, string type, string breed, string dob, string weight, string ownerId)
        {
            Id = id;
            Name = name;
            Type = type;
            Breed = breed;
            DOB = dob;
            Weight = weight;
            OwnerId = ownerId;
        }
    }
}
