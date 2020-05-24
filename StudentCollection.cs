using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab
{
    class StudentCollection
    {
        private List<Student> Students { get; set; }

        public void AddDefaults()
        {
            if (Students == null)
            {
                Students = new List<Student>();
            }
            for (int i = 0; i < 3; i++)
            {
                Student st = new Student();
                Students.Add(st);
            }
        }
        public void AddStudents(params Student[] st)
        {
            if (Students == null)
            {
                Students = new List<Student>();
            }
            foreach (Student s in st)
            {
                Students.Add(s);
            }
        }
        public override string ToString()
        {
            string str = "";
            foreach (Student s in Students)
            {
                str += s.ToString() + "\n";
            }
            return str;
        }
        public string ToShortString()
        {
            string str = "";
            foreach (Student s in Students)
            {
                str += s.ToShortString() + s.Exams.Count + s.Tests.Count + "\n";
            }
            return str;
        }
        public void SortSurname()
        {
            Students.Sort();
        }
        public void SortByBirthday()
        {
            Students.Sort(new Person().Compare);
        }
        public void SortAverageValue()
        {
            Students.Sort(new StudentComparer());
        }
        public double MaxAverageMark
        {
            get { return Students.Max(mark => mark.AverageValue); }
        }
        public IEnumerable<Student> Masters
        {
            get { return Students.Where(education => education.Education == Education.Master); }
        }
        public List<Student> AverageMarkGroup(double value)
        {
            return Students.Where(mark => Math.Abs(mark.AverageValue - value) < 0.001).ToList();
        }
    }
}
