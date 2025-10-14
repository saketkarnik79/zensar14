using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoOOP.Demographics
{
    internal class Person
    {
        public int Id { get; private set; }

        public string? Name { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public Person(int id, string name, DateOnly datOfBirth)
        {
            Id = id;
            Name = name;
            DateOfBirth = datOfBirth;
        }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }

        public virtual string GetData()
        {
            return $"Id: {Id}, Name: {Name}, Date of Birth: {DateOfBirth}, Age: {Age}";
        }
    }
}
