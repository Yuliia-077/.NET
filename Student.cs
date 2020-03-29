using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1V1
{
    class Student
    {
        private Person studentData;
        public Person StudentData
        {
            get => studentData;
            set => studentData = value;
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
            set => numberOfGroup = value;
        }

        private Exam[] exams;
        public Exam[] Exams
        {
            get => exams;
            set => exams = value;
        }
        public Student(Person person, Education education, int numberOfGroup, Exam[] exams)
        {
            StudentData = person;
            Education = education;
            NumberOfGroup = numberOfGroup;
            Exams = exams;
        }
        public Student() : this(new Person(), Education.SecondEducation, 1, new Exam[] { new Exam() })
        { }
        public double AverageValue 
        {
            get 
            {
                double sum = 0;
                foreach(Exam x in exams)
                {
                    sum += x.mark;
                }
                return sum / exams.Length;
            
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
            Exam[] add = new Exam[this.exams.Length + exams.Length];
            for (int i = 0; i < this.exams.Length; i++)
            {
                add[i] = this.exams[i];
            }
            for (int i = 0; i < exams.Length; i++)
            {
                add[i + this.exams.Length] = exams[i];
            }
            Exams = add;
        }
        public override string ToString()
        {
            string str;
            str = studentData.ToString() + " " + Education + " " + NumberOfGroup;
            for (int i = 0; i < exams.Length; i++)
            {
                str += " " + exams[i].ToString();
            }
            return str;
        }
        public virtual string ToShortString()
        {
            return studentData.ToString() + " " + Education + " " + NumberOfGroup + " " + AverageValue;
        }

    }
}
