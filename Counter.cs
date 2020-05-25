using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lab7
{
    class Counter
    {
        public Matrix matrix1 { get; set; }
        public Matrix matrix2 { get; set; }

        static object locker = new object();

        public Counter(Matrix matrix1, Matrix matrix2, int x, int y)
        {
            this.matrix1 = matrix1;
            this.matrix2 = matrix2;
            this.x = x;
            this.y = y;
        }

        public int x { get; set; }
        public int y { get; set; }
        public void Dod()
        {
            lock(locker)
            {
                int sum = 0;
                for (int k = 0; k < matrix1.colums; k++)
                {
                    sum += matrix1.matrix[x, k] * matrix2.matrix[k, y];
                }
                Console.Write(sum + " ");
            }
        }
    }
}
