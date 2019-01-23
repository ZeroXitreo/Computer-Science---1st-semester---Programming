using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveGUI
{
    public class Controller
    {
        private static Controller instance;
        private PersonRepository repository;
        public Person CurrentPerson { get; private set; }
        public int PersonCount { get; private set; }
        public int PersonIndex { get; private set; }

        private Controller()
        {
            CurrentPerson = null;
            repository = new PersonRepository();
            PersonCount = 0;
            PersonIndex = -1;
        }
        public static Controller GetInstance()
        {
            if (instance == null)
            {
                instance = new Controller();
            }
            return instance;
        }

        public void AddPerson()
        {
            Person person = new Person();
            CurrentPerson = person;
            repository.AddPerson(person);
            PersonCount = repository.Count;
            PersonIndex = PersonCount - 1;
        }

        public void DeletePerson()
        {
            if (CurrentPerson != null)
            {
                repository.RemovePerson(CurrentPerson);
                
                PersonCount = repository.Count;
                if (PersonIndex == PersonCount) // Vi har slettet bagerste person i repositoriet
                {
                    PersonIndex--;
                }

               CurrentPerson = repository.GetPersonAtIndex(PersonIndex);
            }
        }

        public void NextPerson()
        {
            if (PersonIndex < PersonCount - 1)
            {
                PersonIndex++;
                CurrentPerson = repository.GetPersonAtIndex(PersonIndex);
            }
        }
        public void PrevPerson()
        {
            if (PersonIndex > 0)
            {
                PersonIndex--;
                CurrentPerson = repository.GetPersonAtIndex(PersonIndex);
            }
        }


    }
}
