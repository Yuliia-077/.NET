using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class StudentComparer: IComparer<Student>
    {
        public int Compare(Student s1, Student s2) 
        {
            return s1.AverageValue.CompareTo(s2.AverageValue);
        }
}
}
