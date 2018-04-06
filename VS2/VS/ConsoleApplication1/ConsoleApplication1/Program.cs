using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

static class Consts
{
    public const double Pi = 3.141592653589793238462643383279;
    public const int C_vel = 299792458;
}
namespace ConsoleApplication1
{
    class Program
    {


        static void Main(string[] args)
        {
 
           
            FileStream data = new FileStream("D:\\GNUPL\\Nakrap\\new_file.txt", FileMode.Create); //создаем файловый поток
            StreamWriter writer = new StreamWriter(data);
            for (int i = 0; i < 20; i+=5)
            {
                writer.WriteLine(i/3.2);
            }
            writer.Close();
        }
    }
}

