using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab
{
    class StudentCollection
    {
        private List<Student> Students { get; set; }
        public string NameOfCollection { get; set; }

        public delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);

        public event StudentListHandler StudentCountChanged;

        public event StudentListHandler StudentReferenceChanged;
        public StudentCollection() : this("Name", new List<Student>()) { }

        public StudentCollection(string collectionName, List<Student> listStudent)
        {
            NameOfCollection = collectionName;
            Students = listStudent;
        }
        public Student this[int index]
        {
            get { return Students[index]; }
            set { Students[index] = value;
                StudentListHandlerEventArgs slha = new StudentListHandlerEventArgs(NameOfCollection, "student was changed", value);
                StudentReferenceChanged?.Invoke(this, slha);
            }
        }

        public void AddDefaults()
        {
            StudentListHandlerEventArgs slha;
            if (Students == null)
            {
                Students = new List<Student>();
            }
            for (int i = 0; i < 3; i++)
            {
                NameOfCollection = "Collection";
                Student st = new Student();
                Students.Add(st);
                slha = new StudentListHandlerEventArgs(NameOfCollection, "add student", st);
                StudentCountChanged?.Invoke(this, slha);
            }
        }
        public void AddStudents(params Student[] st)
        {
            StudentListHandlerEventArgs slha;
            if (Students == null)
            {
                Students = new List<Student>();
            }
            foreach (Student s in st)
            {
                Students.Add(s);
                slha = new StudentListHandlerEventArgs(NameOfCollection, "add student", s);
                StudentCountChanged?.Invoke(this, slha);
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
        public bool Remove(int j)
        {
            StudentListHandlerEventArgs slha;
            if (j >= Students.Count) return false;
            else
            {
                Student st = Students[j];
                Students.Remove(st);
                slha = new StudentListHandlerEventArgs(NameOfCollection, "delete student", st);
                StudentCountChanged?.Invoke(this, slha);
                return true;
            }
        }

    }
}
