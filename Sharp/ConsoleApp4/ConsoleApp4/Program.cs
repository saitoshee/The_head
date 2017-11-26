using System;
namespace ConsoleApp4
{
    enum Colors
    {
        Red,
        Green,
        Blue,
         //Yellow
    }

    class Program
    {
        static string GetName(Colors color)
        {
            if (color == Colors.Red) return "Красный";
            else if (color == Colors.Blue) return "Синий";
            else return "Зеленый";

           // throw new Exception("The color was unknown"); // Указатель на ошибку
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GetName(Colors.Blue));
            
            Console.ReadKey();
        }

    }
}
