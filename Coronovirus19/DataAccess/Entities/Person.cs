using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coronovirus19.DataAccess.Entities
{
    public class Person
    {
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Name { get; set; }
        public string BloodType { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex sex { get; set; }
        public string Address { get; set; }


    }

    public enum Sex
    {
        Male,Female
    }
}
