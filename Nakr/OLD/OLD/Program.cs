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
namespace OLD
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream data = new FileStream("D:\\GNUPL\\Nakrap\\OLD.dat", FileMode.Create); //создаем файловый поток
            StreamWriter writer = new StreamWriter(data);
            Complex f_min = 900000000, f_max = 4000000000, f_now, R, z_in = 50, z_out = 75, l = 0.16, f_step = 500000;
            Complex betta = 0, i = 0, lyambda = 0, ksvn;
            for (f_now = f_min; f_now.Real <= f_max.Real; f_now += f_step)
            {
                R = z_out / z_in;
                lyambda = Consts.C_vel / f_now;
                betta = (2 * Consts.Pi) / lyambda;
                ksvn = 1 + ((Math.Abs(Math.Sin(betta.Real * 0.16))) / (betta.Real * 0.16)) * Math.Log(R.Real);
               // ksvn = (1 + ((Math.Abs(Math.Sin(betta.Real * 0.17)) / betta.Real * 0.17) * Math.Log(R.Real))) / (1 - ((Math.Abs(Math.Sin(betta.Real * 0.17)) / betta.Real * 0.17) * Math.Log(R.Real)));
                writer.WriteLine((f_now / 1000000).Real + "\t" + ksvn.Real);
                // Console.WriteLine(f_now.Real.ToString());
                //writer.WriteLine(ksvn.Real);

            }
        }
    }
}
