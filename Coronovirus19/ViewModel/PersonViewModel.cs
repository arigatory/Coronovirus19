using Coronovirus19.DataAccess.Entities;
using Coronovirus19.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coronovirus19.ViewModel
{
    public class PersonViewModel
    {
        public PersonViewModel()
        {
            _personModel = new PersonModel();
            _personModel.PersonListChanged += (sender, e) => ReloadPersons();
            ReloadPersons();
            Sexes = new List<Sex>();
            foreach (object item in Enum.GetValues(typeof(Sex)))
            {
                Sexes.Add((Sex)item);
            }
        }

        public List<Person> Persons { get; private set; }

        public Person CurrentPerson { get; set; }
        public List<Sex> Sexes { get; }
        public void Add()
        {
            Persons.Add(new Person());
        }

        public void Delete()
        {
            Persons.Remove(CurrentPerson);
        }
        
        // validation shoul be also here
        public void Save()
        {
            _personModel.Save(Persons.ToArray());
        }

        private void ReloadPersons()
        {
            Persons = new List<Person>(_personModel.Persons);
        }

        private readonly PersonModel _personModel;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
