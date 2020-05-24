using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class JournalEntry
    {
        public string NameOfCollection { get; set; }
        public string InfAboutTypeOfChange { get; set; }
        public Student Student { get; set; }
        public JournalEntry(string nameOfCollection, string infAboutTypeOfChange, Student student)
        {
            NameOfCollection = nameOfCollection;
            InfAboutTypeOfChange = infAboutTypeOfChange;
            Student = student;
        }
        public override string ToString()
        {
            return NameOfCollection + " " + InfAboutTypeOfChange + " " + Student.ToShortString();
        }

    }
}
