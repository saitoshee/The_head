// GlobalLocal
using System;

namespace ConsoleApp3
{
    class Program
    {
        //static int V; better use method
        static int DoWork()
        {
            return 10;
        }
        static void Main(string[] args)
        {
            var local = 0;
            Console.WriteLine(local);
            local = DoWork();
            Console.WriteLine(local);
            Console.ReadKey();
        }
    }
}
