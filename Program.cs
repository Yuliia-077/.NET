using System;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            Student studentCopy = (Student)student.DeepCopy();
            Console.WriteLine($"Real: {student.ToString()}");
            Console.WriteLine($"Copy: {studentCopy.ToString()}");
            string filename = "";
            Console.WriteLine("Enter a file name:");
            filename = Console.ReadLine();
            if(System.IO.File.Exists(filename))
            {
                student.Load(filename);
            }
            else 
            {
                System.IO.File.Create(filename);
                Console.WriteLine("File not found. File created"); 
            }
            Console.WriteLine(student.ToString());
            student.AddFromConsole();
            student.Save(filename);
            Console.WriteLine(student.ToString());
            Student.Load(filename, student);
            student.AddFromConsole();
            Student.Save(filename, student);
            Console.WriteLine(student.ToString());










        }
    }
}
