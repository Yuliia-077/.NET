using System;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Exam[] ex = new Exam[3];
            ex[0] = new Exam("Database", 5, new DateTime(2020, 6, 7));
            ex[1] = new Exam("Protection of inf", 5, new DateTime(2020, 6, 14));
            ex[2] = new Exam("English", 2, new DateTime(2020, 6, 22));
            Person Tom1 = new Person("Tom", "Sawyer", new DateTime(2000, 12, 12));
            Person Tom2 = new Person("Tom", "Sawyer", new DateTime(2000, 12, 12));
            Console.WriteLine("Links are equal or not: " + Tom1.Equals(Tom2));
            Console.WriteLine("Hashcode Tom1: " + Tom1.GetHashCode());
            Console.WriteLine("Hashcode Tom2: " + Tom2.GetHashCode());
            Test[] t = new Test[3];
            t[0] = new Test("1C", true);
            t[1] = new Test("C#", false);
            t[2] = new Test("Application packages", true);
            Student Linda = new Student("Linda", "Rose", new DateTime(2000, 12, 12), Education.Bachelor, 311, new System.Collections.ArrayList(ex), new System.Collections.ArrayList(t));
            Console.WriteLine(Linda.ToString());
            Student LindaCopy = (Student)Linda.DeepCopy();
            Linda.FirstName = "Liza";
            Console.WriteLine("Original: " + Linda.ToString());
            Console.WriteLine("Copy: " + LindaCopy.ToString());
            try{ LindaCopy.NumberOfGroup = 999; }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            foreach (Exam e in Linda.GetExams(3))
            { Console.WriteLine(e); }
            
        }
    }
}
