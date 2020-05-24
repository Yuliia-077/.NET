using System;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection studentCollection = new StudentCollection();
            studentCollection.AddStudents(TestCollections.Create(0), TestCollections.Create(1), TestCollections.Create(2), TestCollections.Create(3), TestCollections.Create(4), TestCollections.Create(5));
            Console.WriteLine("Student Collections:");
            Console.WriteLine(studentCollection.ToString());
            studentCollection.SortSurname();
            Console.WriteLine("Student Collections are sorted by surname:");
            Console.WriteLine(studentCollection.ToShortString());
            studentCollection.SortByBirthday();
            Console.WriteLine("Student Collections are sorted by birthday:");
            Console.WriteLine(studentCollection.ToShortString());
            studentCollection.SortAverageValue();
            Console.WriteLine("Student Collections are sorted by average mark:");
            Console.WriteLine(studentCollection.ToShortString());
            Console.WriteLine("Students are Master:");
            foreach (Student st in studentCollection.Masters)
            {
                Console.WriteLine(st.ToShortString());
            }
            Console.WriteLine("Max average mark:");
            Console.WriteLine(studentCollection.MaxAverageMark);
            Console.WriteLine("Group students:");
            foreach (Student student in studentCollection.AverageMarkGroup(1))
            {
                Console.WriteLine(student + "\n");
            }
            int count = 100;
            Console.WriteLine("Test Collections:");
            TestCollections testCollections = new TestCollections(count);
            int[] indexes = new int[] { 0, count - 1, (count - 1) / 2, count };
            testCollections.MeasureTime(indexes);
        }
    }
}
