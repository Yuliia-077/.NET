using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Collections;

namespace Lab
{
    class Student : Person, IDateAndCopy
    {
        public Person Person
        {
            get => Person;
            set => Person = value;
        }
        
        private Education education;

        public Education Education
        {
            get => education;
            set => education = value;
        }

        private int numberOfGroup;

        public int NumberOfGroup
        {
            get => numberOfGroup;
            set 
            {
                if(value <= 100 && value >= 699)
                {
                    throw new Exception("The number of group must be 100 to 699!");
                }
                else
                {
                    numberOfGroup = value;
                }
            }
        }

        private ArrayList exams = new ArrayList();

        public ArrayList Exams
        {
            get => exams;
            set => exams = value;
        }

        private ArrayList tests = new ArrayList();

        public ArrayList Tests
        {
            get => tests;
            set => tests = value;
        }

        public Student(string firstName, string surname, DateTime dateOfBirth, Education education, int numberOfGroup, ArrayList exams, ArrayList tests):base(firstName, surname, dateOfBirth)
        {
            Education = education;
            NumberOfGroup = numberOfGroup;
            Exams = exams;
            Tests = tests;
        }

        public Student() : base()
        {
            Education = Education.SecondEducation;
            NumberOfGroup = 1;
            exams.Add(new Exam());
            tests.Add(new Test());
        }

        public double AverageValue
        {
            get
            {
                double sum = 0;
                foreach (Exam x in exams)
                {
                    sum += x.mark;
                }
                return sum / exams.Count;

            }

        }

        public bool this[Education education]
        {
            get
            {
                return education == Education;
            }
        }

        public void AddExams(params Exam[] exams)
        {
            for (int i = 0; i < exams.Length; i++)
            {
                this.exams.Add(exams[i]);
            }
        }

        public override string ToString()
        {
            string str;
            str = base.ToString() + " " + Education + " " + NumberOfGroup;
            foreach (Exam ex in Exams)
            {
                str += " " + ex.ToString();
            }
            foreach (Test t in Tests)
            {
                str += " " + t.ToString();
            }
            return str;
        }

        public override string ToShortString()
        {
            return base.ToString() + " " + Education + " " + NumberOfGroup + " " + AverageValue;
        }

        public override bool Equals(object obj)
        {
            return obj is Student student && 
                   education == student.education &&
                   numberOfGroup == student.numberOfGroup &&
                   EqualityComparer<ArrayList>.Default.Equals(exams, student.exams) &&
                   EqualityComparer<ArrayList>.Default.Equals(tests, student.tests);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(education, numberOfGroup, exams, tests);
        }

        public static bool operator ==(Student left, Student right)
        {
            return EqualityComparer<Student>.Default.Equals(left, right);
        }

        public static bool operator !=(Student left, Student right)
        {
            return !(left == right);
        }

         public override object DeepCopy()
         {
             var other = (Student)this.MemberwiseClone();
             other.Exams = new ArrayList();
             foreach(Exam ex in Exams)
             {
                 other.Exams.Add(ex.DeepCopy());
             }
            other.Tests = new ArrayList();
            foreach(Test t in Tests)
            {
                other.Tests.Add(t.DeepCopy());
            }

             return other;
         }

        public IEnumerable GetExamsAndTests()
        {
            foreach (Exam ex in Exams)
            {
                yield return ex;

            }
            foreach (Test t in Tests)
            {
                yield return t;

            }
        }

        public IEnumerable GetExams(int mark)
        {
            foreach (Exam ex in Exams)
            {
                if (ex.mark > mark)
                {
                    yield return ex;
                }
            }
        }

    }
}
