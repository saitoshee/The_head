using System;
using System.Globalization; // for CultureInfo

namespace Consol1
{
    class Program
        /*  Program or Console это классы у которых есть свои методы(статические)
            методы у переменных это динамические (str.Substring)    
     */
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string str1 = null; // отсутствие всякого значения
           /* string b = Console.ReadLine(); // ввод
                                           // wrong : char a = "5";
                                           // ввод числа с консоли - ввести строку и конвентировать в число и обратно
            int numb = int.Parse(b);
            numb += 1;
            b = numb.ToString();*/
            // double
            double num = double.Parse(str, CultureInfo.InvariantCulture); // Чтобы не зависило . или , разделяет число

           Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
