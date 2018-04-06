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
        /* плавный переход вариант Б*/
        public static void task_1b()
        {
            FileStream data = new FileStream("D:\\GNUPL\\nakrap\\1b.dat", FileMode.Create);
            StreamWriter writer = new StreamWriter(data);
            Complex f_min = 900000000, f_max = 4000000000, f_now, R, z_in = 50, z_out = 75, l = 0.17, f_step = 500000;
            Complex i = 0, lyambda = 0, ksvn, betta = 0,H;
            R = z_out / z_in;
            for (f_now = f_min; f_now.Real <= f_max.Real; f_now += f_step)
            { 
                lyambda = Consts.C_vel / f_now;
                betta = (2 * Consts.Pi) / lyambda;
                H = (Math.Sin(betta.Real * l.Real) / (2 * betta.Real * l.Real)) * Math.Log(R.Real);
                ksvn = (1 + Math.Abs(H.Real)) / (1 - Math.Abs(H.Real));
                writer.WriteLine((f_now / 1000000).Real + "\t" + ksvn.Real);
            }
        }

        /* с максимально плоской характеристикой */
        public static void task_c()
        {
            FileStream data = new FileStream("D:\\GNUPL\\nakrap\\3.dat", FileMode.Create);
            StreamWriter writer = new StreamWriter(data);

            Complex f_min = 900000000,
                    f_max = 4000000000,
                    f_now, f_step = 500000,
                    n = 3, z_out = 75, z_in = 50,
                    R, lambda, theta, L, l, l1, l2, ksvn;

            R = z_out / z_in;
            l1 = Consts.C_vel / f_min;
            l2 = Consts.C_vel / f_max;
            l = (l1 * l2) / (2 * (l1 + l2));
            for (f_now = f_min; f_now.Real <= f_max.Real; f_now += f_step)
            {
                lambda = Consts.C_vel / f_now;
                theta = (2 * Consts.Pi * l) / lambda;
                L = 1 + (Math.Pow((R.Real - 1), 2) / (4 * R.Real)) * Math.Pow((Math.Cos(theta.Real)), (2 * n.Real));
                ksvn = 2 * L.Real * (1 + Math.Sqrt((L.Real - 1) / L.Real)) - 1;
                writer.WriteLine((f_now / 1000000).Real + "\t" + ksvn.Real);
            }
        }

        /* трёхступенчатый чебышевский переход */
        public static void task_b()
        {
            FileStream data = new FileStream("D:\\GNUPL\\nakrap\\2.dat", FileMode.Create);
            StreamWriter writer4 = new StreamWriter(data);

            Complex f_min = 900000000,
                    f_max = 4000000000,
                    f_now, f_step = 500000,
                    n = 3, z_out = 75, z_in = 50,
                    R, S, l, l1, l2, theta, H, h, ksvn, L, Tn_0, lambda, z, arch, Tn,z1,x;

            R = z_out / z_in;
            l1 = Consts.C_vel / f_min;
            l2 = Consts.C_vel / f_max;

            l = (l1 * l2) / (2 * (l1 + l2));
            S = Math.Cos((2 * Consts.Pi * l.Real) / l2.Real);
            z = 1 / S;
            //  arch = Math.Log(z.Real + Math.Sqrt((z.Real*z.Real) - 1));
            //x = Math.Cosh(1.83);
            Tn_0 = Math.Abs((4 * (z.Real * z.Real * z.Real)) - (3 * z.Real)); 
            h = (R.Real - 1) / (2* Math.Sqrt(R.Real) * Tn_0.Real);
            Console.WriteLine("h: "+ h.Real + "\n" + "l: " + l.Real + "\n" + "S: " + Math.Abs(S.Real) );
            for (f_now = f_min; f_now.Real <= f_max.Real; f_now += f_step)
            {
                lambda = Consts.C_vel / f_now;
                theta = (2 * Consts.Pi * l) / lambda;
                z1 = Math.Cos(theta.Real) / S.Real;
                Tn = (4 * z1.Real * z1.Real * z1.Real) - (3 * z1.Real);
                L = 1 + h.Real * h.Real * Tn.Real * Tn.Real;

                //L = 1 + h.Real * h.Real * Tn.Real * Tn.Real;
                //ksvn = 2* L.Real * (1 + Math.Sqrt((L.Real - 1) / L.Real)) - 1;

                //  L = 1 + (Math.Pow((R.Real - 1), 2) / (4 * R.Real)) * Math.Pow((Math.Cos(theta.Real)), (2 * n.Real));
                ksvn = 2 * L.Real * (1 + Math.Sqrt((L.Real - 1) / L.Real)) - 1;
                writer4.WriteLine((f_now / 1000000).Real + "\t" + ksvn.Real);

            }
        }
        /* 4 */
        public static void task_d()
        {
            FileStream data = new FileStream("D:\\GNUPL\\Lab_2\\d.dat", FileMode.Create);
            StreamWriter writer5 = new StreamWriter(data);

            Complex f_min = 650000000,
                    f_max = 3500000000,
                    f_now, f_step = 500000,
                    n = 3, z_out = 75, z_in = 50,
                    R, S, l = 0.0565, l1, l2, theta, H, h, ksvn, L, Tn_0, lambda, z, arch, Tn, z1, x;

            R = z_out / z_in;
            l1 = Consts.C_vel / f_min;
            l2 = Consts.C_vel / f_max;

            // l = (l1 * l2) / (2 * (l1 + l2));
            S = Math.Cos((2 * Consts.Pi * l.Real) / l2.Real);
            z = 1 / S;
            //  arch = Math.Log(z.Real + Math.Sqrt((z.Real*z.Real) - 1));
            //x = Math.Cosh(1.83);
            Tn_0 = Math.Abs((4 * (z.Real * z.Real * z.Real)) - (3 * z.Real));
            h = (R.Real - 1) / (2 * Math.Sqrt(R.Real) * Tn_0.Real);

            for (f_now = f_min; f_now.Real <= f_max.Real; f_now += f_step)
            {
                lambda = Consts.C_vel / f_now;
                theta = (2 * Consts.Pi * l) / lambda;
                z1 = Math.Cos(theta.Real) / S.Real;
                Tn = (4 * z1.Real * z1.Real * z1.Real) - (3 * z1.Real);
                L = 1 + h.Real * h.Real * Tn.Real * Tn.Real;

                //L = 1 + h.Real * h.Real * Tn.Real * Tn.Real;
                //ksvn = 2* L.Real * (1 + Math.Sqrt((L.Real - 1) / L.Real)) - 1;

                //  L = 1 + (Math.Pow((R.Real - 1), 2) / (4 * R.Real)) * Math.Pow((Math.Cos(theta.Real)), (2 * n.Real));
                ksvn = 2 * L.Real * (1 + Math.Sqrt((L.Real - 1) / L.Real)) - 1;
                writer5.WriteLine((f_now / 1000000).Real + "\t" + ksvn.Real);

            }
        }
            static void Main(string[] args)
        {
            task_1b();
            task_c();
            task_b();
            task_d();

          Console.ReadLine();
        }
    }
    }
