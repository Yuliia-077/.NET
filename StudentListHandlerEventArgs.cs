using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class StudentListHandlerEventArgs: EventArgs
    {
        public string NameOfCollections { get; set; }
        public string TypeOfChange { get; set; }
        public Student Student { get; set; }
        public StudentListHandlerEventArgs(string nameOfCollections, string typeOfChange, Student student)
        {
            NameOfCollections = nameOfCollections;
            TypeOfChange = typeOfChange;
            Student = student;
        }
        public override string ToString()
        {
            return NameOfCollections + " " + TypeOfChange + " " + Student.ToShortString();
        }

    }
}
