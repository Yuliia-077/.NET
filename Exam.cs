using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lab
{
    enum Education { Master, Bachelor, SecondEducation }
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

        public Exam() : this("C#", 100, new DateTime(2020, 6, 12))
        { }

        public override string ToString()
        {
            return nameOfExam + " " + mark + " " + dateOfExam;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Exam);
        }

        public bool Equals([AllowNull] Exam other)
        {
            return other != null &&
                   nameOfExam == other.nameOfExam &&
                   mark == other.mark &&
                   dateOfExam == other.dateOfExam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(nameOfExam, mark, dateOfExam);
        }

        public static bool operator ==(Exam left, Exam right)
        {
            return EqualityComparer<Exam>.Default.Equals(left, right);
        }

        public static bool operator !=(Exam left, Exam right)
        {
            return !(left == right);
        }

        public Exam DeepCopy()
        {
            Exam other = (Exam)this.MemberwiseClone();
            return other;
        }
    }
}
