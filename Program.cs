using System;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection studentCollection = new StudentCollection("Collection1", new System.Collections.Generic.List<Student>());
            StudentCollection studentCollection2 = new StudentCollection("Collection2", new System.Collections.Generic.List<Student>());
            Journal journal = new Journal();
            Journal journal2 = new Journal();
            studentCollection.StudentCountChanged += journal.OnStudentChanged;
            studentCollection.StudentReferenceChanged += journal.OnStudentChanged;
            studentCollection2.StudentCountChanged += journal2.OnStudentChanged;
            studentCollection2.StudentReferenceChanged += journal2.OnStudentChanged;
            System.Collections.Generic.List<Exam> ex = new System.Collections.Generic.List<Exam>();
            ex.Add(new Exam("Database", 5, new DateTime(2020, 6, 7)));
            ex.Add(new Exam("Protection of inf", 5, new DateTime(2020, 6, 14)));
            System.Collections.Generic.List<Test> t = new System.Collections.Generic.List<Test>();
            t.Add(new Test("1C", true));
            t.Add(new Test());
            Student Linda = new Student("Linda", "Rose", new DateTime(2000, 12, 12), Education.Bachelor, 311, ex, t);
            studentCollection.AddStudents(Linda);
            studentCollection2.AddStudents(Linda);
            Student Tom = new Student("Tom", "Sawyer", new DateTime(2000, 12, 12), Education.Master, 311, ex, t);
            studentCollection.AddStudents(Tom);
            studentCollection2.AddStudents(Tom);
            Person per = new Person();
            Student Dan = new Student(per.FirstName, per.Surname, per.DateOfBirth, Education.Master, 311, ex, t);
            studentCollection.Remove(1);
            studentCollection2.Remove(0);
            studentCollection[0] = Dan;
            studentCollection2[0] = Dan;
            Console.WriteLine(journal.ToString());
            Console.WriteLine(journal2.ToString());





        }
    }
}
