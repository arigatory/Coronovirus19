using Coronovirus19.DataAccess;
using Coronovirus19.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coronovirus19.Models
{
    class PersonModel
    {
        public PersonModel()
        {
            _personProvider = new PersonProvider("Persons.xml");
            Load();
        }

        public Person[] Persons { get; set; }

        public event EventHandler PersonListChanged;

        public void Load()
        {
            Persons = _personProvider.GetPersons();
        }

        public void Save(Person[] persons)
        {
            foreach (Person person in persons)
            {
                person.LastName = "Mr. " + person.LastName;
            }
            _personProvider.SavePersons(persons);
            Persons = persons;
            SendMail();
            PersonListChanged?.Invoke(this, EventArgs.Empty);
        }

        private void SendMail()
        {
            
        }

        private readonly PersonProvider _personProvider;
    }
}
