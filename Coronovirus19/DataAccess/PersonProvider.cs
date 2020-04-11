using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Coronovirus19.DataAccess.Entities;

namespace Coronovirus19.DataAccess
{
    class PersonProvider
    {
        private readonly string _fileName;

        public PersonProvider(string fileName)
        {
            _fileName = fileName;
        }
        public Person[] GetPersons()
        {
            if (!File.Exists(_fileName))
            {
                return new Person[]{
                 new Person()
                 {
                     LastName="Pupkin", BirthDate = new DateTime(2000, 5, 15), Name = "Vasya", MiddleName="Ivanovich", BloodType = "AB", sex = Sex.Male, Address="Moscow"
                 },
                 new Person()
                 {
                     LastName="Ivanov", BirthDate = new DateTime(2000, 5, 15), Name = "Igor", MiddleName="Ivanovich", BloodType = "AB", sex = Sex.Male, Address="Spb"
                 }
                };
            }

            using (StreamReader sr = new StreamReader(_fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Person[]));
                return (Person[])serializer.Deserialize(sr);
            }
        }

        public void SavePersons(Person[] persons)
        {
            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Person[]));
                serializer.Serialize(sw, persons);
            }
        }
    }
}
