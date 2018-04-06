using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {

            /* int[] arr;
             arr = new int[5];
             for (int i = 2; i < arr.Length; i++)
             {
                 arr[i] = i * i;
                 Console.WriteLine(arr[i]);
             }


             foreach (int e in arr)
             {
                 Console.WriteLine(e);
             }
             */

            int[,] matrix = { { 1, -2 }, { 3, 1 }, { 1, 1 } };
            int[,] matrix1 = { { 4, 1 }, { 2, 2 }, { 2, 2 } };
            int[,] matrix2 = { { 0,0}, { 0,0},{0,0} }; ;
            int row, col;
            for (row = 0; row < matrix.GetLength(0); row++)
            {   for (col = 0; col < matrix.GetLength(1); col++)
                {

                    Console.Write(matrix[row,col]);
                }
            }
            Console.WriteLine();

            for (row = 0; row < matrix1.GetLength(0); row++)
            {
                for (col = 0; col < matrix1.GetLength(1); col++)
                {
                    Console.Write(matrix1[row, col]);

                }
            }
            Console.WriteLine();

            for (row = 0; row < matrix2.GetLength(0); row++)
            {
                for (col = 0; col < matrix2.GetLength(1); col++)
                {
                    matrix2[row, col] = matrix1[row, col] + matrix[row, col];
                    Console.Write(matrix2[row, col]);

                }
            }

            Console.ReadKey();
        }
    }
}
