using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;



static class Consts
{
    public const double Pi = 3.141592653589793238462643383279;
    public const int C_vel = 299792458;
}
namespace ConsoleApplication1
{
    class Program
    {
        /*public static double GetNums(double nums)
        {
            int f_min = 900; int f_max = 4000; double R; int z_in = 50; int z_out = 75; double num; double b;
            R = z_out / z_in;

            return R;
        }
        */

        /*public static void betta()
        {
            double la;
            int f_min = 900; int f_max = 100; //4000; 
            double R = 50 / 75;
            for (int i = f_min; i <= f_max; i+=10)
            {
                la = Consts.C_vel / i;
                b = (2 * Consts.Pi) / la;   
            }
            
        }
        */
        static void Main(string[] args)
        {
            FileStream data = new FileStream("D:\\GNUPL\\Nakrap\\new1.txt", FileMode.Create); //создаем файловый поток
            StreamWriter writer = new StreamWriter(data);
            Complex f_min = 900000000, f_max = 4000000000, f_now, R, z_in = 50, z_out = 75, l = 0.17, f_step = 500000;
            Complex betta = 0, i = 0, lyambda = 0, ksvn;
            for (f_now = f_min; f_now.Real <= f_max.Real; f_now += f_step)
            {   
                R = z_out / z_in;
                lyambda = Consts.C_vel / f_now;
                betta = (2 * Consts.Pi) / lyambda;
                ksvn = (1 + ((Math.Abs(Math.Sin(betta.Real * 0.17)) / betta.Real * 0.17) * Math.Log(R.Real))) / (1 - ((Math.Abs(Math.Sin(betta.Real * 0.17)) / betta.Real * 0.17) * Math.Log(R.Real)));
                writer.Write((f_now/1000000).Real.ToString());
               // Console.WriteLine(f_now.Real.ToString());
                writer.Write("      ");
                writer.WriteLine(ksvn.Real);

            }

           //Console.Read();



            //double max = GetNums(numbers);

        }

    }
}


/*
 *   FileStream data = new FileStream("D:\\GNUPL\\Nakrap\\new_file.txt", FileMode.Create); //создаем файловый поток
            StreamWriter writer = new StreamWriter(data);

            double b = 0;
            double la;
                int f_min = 900; int f_max = 100; //4000;
            for (int j = f_min; j <= f_max; j += 10)
            {
                
                
                la = Consts.C_vel / j;
                b = (2 * Consts.Pi) / la;
              

            }
            writer.WriteLine(b);
            writer.Close();
 */
