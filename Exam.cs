using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1V1
{
    enum Education {Master, Bachelor, SecondEducation}
    class Exam
    {
        public string nameOfExam;
        public int mark;
        public DateTime dateOfExam;
        public Exam(string nameOfExam, int mark, DateTime dateOfExam)
        {
            this.nameOfExam = nameOfExam;
            this.mark = mark;
            this.dateOfExam = dateOfExam;
        }
        public Exam() : this("C#", 100, new DateTime(2020,6,12))
        { }
        public override string ToString()
        {
            return nameOfExam + " " + mark + " " + dateOfExam;
        }
    }
}
