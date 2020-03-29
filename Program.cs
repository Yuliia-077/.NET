using System;

namespace Lab1V1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input number of rows and columns. Separators are '/', ',', ' ', '&':");
            string[] text = Console.ReadLine().Split('/', ',', ' ', '&');
            if (text == null || text.Length < 2)
            {
                return;
            }
            int.TryParse(text[0], out int nRows);
            int.TryParse(text[1], out int nColumns);
            int time, time1;

            Exam[] ex1 = new Exam[nRows * nColumns];
            for (int i = 0; i < nRows * nColumns; i++)
            {
                ex1[i] = new Exam();
            }
            time = Environment.TickCount;
            for (int i = 0; i < nRows * nColumns; i++)
            {
                ex1[i].nameOfExam = "C#";
                ex1[i].dateOfExam = new DateTime(29, 09, 10);
            }
            time1 = Environment.TickCount;
            Console.WriteLine($"Operation time for a one-dimensional array:{time1 - time}");

            Exam[,] ex2 = new Exam[nRows, nColumns];
            for (int i = 0; i < nRows; i++)
                for (int j = 0; j < nColumns; j++)
                {
                    ex2[i, j] = new Exam();
                }
            time = Environment.TickCount;
            for (int i = 0; i < nRows; i++)
                for (int j = 0; j < nColumns; j++)
                {
                    ex2[i, j].nameOfExam = "C#";
                    ex2[i, j].dateOfExam = new DateTime(29, 09, 10);
                }
            time1 = Environment.TickCount;
            Console.WriteLine($"Operation time for a two-dimensional array:{time1 - time}");

            int count = nColumns * nRows;
            Exam[][] ex3 = new Exam[(nRows + nColumns) / 2 + 1][];
            for (int i = 0; i < (nRows + nColumns) / 2 + 1; i++)
            {
                if (i < (nRows + nColumns) / 2)
                {
                    ex3[i] = new Exam[i + 1];
                    count -= i + 1;
                }
                else
                {
                    ex3[i] = new Exam[count];
                }
                for (int j = 0; j < ex3[i].Length; j++)
                {
                    ex3[i][j] = new Exam();
                }
            }
            time = Environment.TickCount;
            for (int i = 0; i < (nRows + nColumns) / 2 + 1; i++)
            {
                for (int j = 0; j < ex3[i].Length; j++)
                {
                    ex3[i][j].nameOfExam = "C#";
                    ex3[i][j].dateOfExam = new DateTime(29, 09, 10);
                }
            }
              
            time1 = Environment.TickCount;
            Console.WriteLine($"Operation time for a jogged array:{time1 - time}");
            Console.WriteLine();

            Student stud = new Student();
            Console.WriteLine(stud.ToShortString());
            Console.WriteLine(stud[Education.Bachelor]);
            Console.WriteLine(stud[Education.Master]);
            Console.WriteLine(stud[Education.SecondEducation]);
            Exam[] exams = new Exam[3];
            exams[0] = new Exam("Database", 95, new DateTime(2020, 6, 7));
            exams[1] = new Exam("Protection of inf", 92, new DateTime(2020, 6, 14));
            exams[2] = new Exam("English", 90, new DateTime(2020, 6, 22));
            stud.StudentData = new Person("Tom", "Sawyer", new DateTime(2000, 12, 12));
            stud.Education = Education.Bachelor;
            stud.NumberOfGroup = 311;
            stud.Exams = exams;
            Console.WriteLine(stud.ToString());
            stud.AddExams(new Exam("C#", 99, new DateTime(2020, 6, 10)), new Exam("1C", 92, new DateTime(2020, 12, 12)));
            Console.WriteLine(stud.ToString());

           


        }
    }
}
