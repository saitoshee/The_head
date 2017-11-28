using System;

namespace ConsoleApp5
{
    class Program
    {
        enum Suits
        {
            Wands,
            Coins,
            Cups,
            Swords
        }
        private static string GetSuit(Suits suit)
        {
            return new[] { "жезлов", "монет", "кубков", "мечей" }[(int)suit];
        }


        static void Main(string[] args)
        {
            /*   var arr = new int[3];

               for (int i = 0; i <arr.Length; i++)
               {
                   arr[i] = (i + 1) * (i + 1);
               }
               
            string[] names = new string[3] {"File", "Edit", "Help" };
            // var [] names = new [3] {"File", "Edit", "Help" };
            // var [] arr1 = new object [3] {1,"wow",4}; object - тип прорадитель, но свалка

            foreach (var e in names)
                Console.WriteLine(e);
                */
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(GetSuit((Suits)i));

            }
            Console.ReadKey();
        }
    }
}
