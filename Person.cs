using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lab
{
    class Person : IDateAndCopy, IComparable, IComparer<Person>
    {
        public virtual DateTime Date { get; set; }
        protected string firstName;

        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        protected string surname;

        public string Surname
        {
            get => surname;
            set => surname = value;
        }

        protected DateTime dateOfBirth;

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

        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }

        public bool Equals([AllowNull] Person other)
        {
            return other != null &&
                   firstName == other.firstName &&
                   surname == other.surname &&
                   dateOfBirth == other.dateOfBirth;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(firstName, surname, dateOfBirth);
        }

        public static bool operator ==(Person left, Person right)
        {
            return EqualityComparer<Person>.Default.Equals(left, right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }

        public virtual object DeepCopy()
        {
            var other = (Person)this.MemberwiseClone();
            return other;
        }

        public int CompareTo(object obj)
        {
            return Surname.CompareTo(obj.ToString());
        }

        public int Compare(Person person, Person person1)
        {
            return person.DateOfBirth.CompareTo(person1.DateOfBirth);
        }
    }
}
