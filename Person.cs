using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1V1
{
    class Person
    {
        private string firstName;
        public string FirstName
        { 
            get => firstName;
            set => firstName = value;
        }

        private string surname;
        public string Surname
        {
            get => surname;
            set => surname = value;
        }

        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set => dateOfBirth = value;
        }
        public Person(string firstName, string surname, DateTime dateOfBirth)
        {
            FirstName = firstName;
            Surname = surname;
            DateOfBirth = dateOfBirth;
        }
        public Person() : this("Dan", "Brown", new DateTime(1964, 6, 22))
        { }
        public int YearOfBirth
        {
            get => dateOfBirth.Year;
            set => dateOfBirth = new DateTime(value, dateOfBirth.Month, dateOfBirth.Day);
        }
        public override string ToString()
        {
            return FirstName + " " + Surname + " " + DateOfBirth;
        }
        virtual public string ToShortString()
        {
            return FirstName + " " + Surname;
        }
    }


}
