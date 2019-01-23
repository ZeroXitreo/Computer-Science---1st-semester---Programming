using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveGUI
{
    class PersonRepository
    {
        private List<Person> personList;

        public int Count
        {
            get { return personList.Count; }
        }

        public PersonRepository()
        {
            personList = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            personList.Add(person);
        }

        public Person GetPersonAtIndex(int index)
        {
            Person personResultat = null;
            if (index >= 0 && index < personList.Count)
            {
                personResultat = personList[index];
            }

            return personResultat;
        }
        public void RemovePersonAtIndex(int index)
        {
            if (index >= 0 && index < personList.Count)
            {
                personList.RemoveAt(index);
            }
        }
        public void RemovePerson(Person person)
        {
            if (person != null)
            {
                personList.Remove(person);
            }
        }

    }
}
