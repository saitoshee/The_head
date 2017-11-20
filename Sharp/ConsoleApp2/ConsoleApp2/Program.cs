// METHODS
using System;


namespace ConsoleApp2
{
    class Program
    {   /// <summary>
    /// Вычисляет округленное частное
    /// </summary>
    /// <param name="a">Делимое</param>
    /// <param name="b">Делитель</param>
    /// <returns>Округленное частное</returns>
        static int DivideAndRound(double a, double b)
        {
            return (int)Math.Round(a/b);
        }
        // Перегрузка

        static void WriteNum(int a)
        {
            Console.WriteLine("a is int");
            Console.WriteLine(a);
        }

        static void WriteNum(double a)
        {
            Console.WriteLine("a is double");
            Console.WriteLine(a);
        }


        static void Main(string[] args)
        {
            /*
             * long a = 2; // неявная конверсия в дабл
            WriteNum(a);
            Console.WriteLine(a);
            */
            DivideAndRound(5, 5);
            Console.ReadKey();
        }
    }
}
