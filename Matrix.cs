using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    class Matrix
    {
        public Matrix(int rows, int colums)
        {
            this.rows = rows;
            this.colums = colums;
            this.matrix = this.GenerateMatrix();
        }

        public int rows { get; set; }
        public int colums { get; set; }
        public int[,] matrix;
        public bool CheckMatrixs(Matrix matrix)
        {
            return this.colums == matrix.rows;
        }
        int[,] GenerateMatrix()
        {
            matrix = new int[rows, colums];
            Random random = new Random();
            for(int i=0; i< rows; i++)
            {
                for(int j=0; j<colums; j++)
                {
                    matrix[i, j] = random.Next(0, 10);
                }
            }
            return matrix;
        }
        public void output()
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j<colums; j++)
                {
                    Console.Write(matrix[i, j] + " ");

                }
                Console.WriteLine();
            }
        }
    }
}
