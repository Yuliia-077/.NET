using System;
using System.Threading;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mat1 = new int[2];
            int[] mat2 = new int[2];
            Input(ref mat1, ref mat2);
            Matrix matrix1 = new Matrix(mat1[0], mat1[1]);
            Matrix matrix2 = new Matrix(mat2[0], mat2[1]);
            Counter counter = new Counter(matrix1, matrix2, 0, 0);
            while (counter.matrix1.CheckMatrixs(counter.matrix2)==false)
            {
                Console.WriteLine("Colums first matrix must equal rows second matrix");
                Input(ref mat1, ref mat2);
                counter.matrix1 = new Matrix(mat1[0], mat1[1]);
                counter.matrix2 = new Matrix(mat2[0], mat2[1]);

            }
            Console.WriteLine("Matrix 1:");
            counter.matrix1.output();
            Console.WriteLine("Matrix 2:");
            counter.matrix2.output();
            Matrix matrix = new Matrix(mat1[0], mat2[1]);
            Thread[,] threads = new Thread[mat1[0], mat2[1]];
            Console.WriteLine();
            for (int i = 0; i < mat1[0]; i++)
            {
                for (int j = 0; j < mat2[1]; j++)
                {
                    counter.x = i;
                    counter.y = j;
                    threads[i, j] = new Thread(counter.Dod);
                    threads[i, j].Start();
                    threads[i, j].Join();
                }
                Console.WriteLine();
            }
        }
        public static void Input(ref int[] mas1, ref int[] mas2)
        {
            Console.WriteLine("Input rows for matrix 1:");
            mas1[0] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input colums for matrix 1:");
            mas1[1] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input rows for matrix 2:");
            mas2[0] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input colums for matrix 2:");
            mas2[1] = Convert.ToInt32(Console.ReadLine());
        }
        
    }
}
