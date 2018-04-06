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

namespace lab_4
{
    class Program
    {
        public static void H_plane()
        {
            double a = 0, f = 10000000000, theta1 = -Consts.Pi, theta2 = 3.14, thetah = 5e-05; //a = 0.103, 0.137big
            double lambda = Consts.C_vel / f;
            FileStream data = new FileStream("D:\\GNUPL\\nakrap\\lab_2\\q\\H.dat", FileMode.Create); // don't forget change the name of dat file
            StreamWriter writer = new StreamWriter(data);
            double n_theta = theta1;
            double n_theta_g = (n_theta * 180) / Consts.Pi;
            double nowPnorm;
            double sinq, cosq, cosbig;
            Console.Write("a : ");
            string sa = Console.ReadLine(); // use dot for writing numbers
           a = Convert.ToDouble(sa);  
           Console.WriteLine(a);
            while (n_theta <= theta2)
            {
                sinq = Math.Sin(n_theta);
                cosq = Math.Cos(n_theta);
                cosbig = Math.Cos(Consts.Pi * a * sinq / lambda);
                nowPnorm = Math.Pow(lambda, 4) * Math.Pow(cosbig, 2) * Math.Pow((1 + cosq), 2) / 4 / Math.Pow((lambda * lambda - 4 * a * a * sinq * sinq), 2);
                n_theta += thetah;
                n_theta_g = (n_theta * 180) / Consts.Pi;
                writer.WriteLine(n_theta_g + "\t" + nowPnorm);
            }
           // Console.WriteLine("theta1: " + theta1 + "\t" + "n: " + n_theta_g);
        }

        public static void E_plane()
        {
            double b = 0, f = 10000000000, theta1 = -3.14, theta2 = 3.14, thetah = 5e-05; // b = 0.83. 0.09big
            double lambda = Consts.C_vel / f;
            FileStream data = new FileStream("D:\\GNUPL\\nakrap\\lab_2\\q\\E.dat", FileMode.Create);
            StreamWriter writer = new StreamWriter(data);
            Console.WriteLine(lambda);
            double n_theta = theta1;
            double n_theta_g = (n_theta * 180) / 3.14;
            double nowPnorm, now1, now,now2,newPnorm;
            Console.Write("b : ");
            string sa = Console.ReadLine(); // use dot for writing numbers
            b = Convert.ToDouble(sa);
            Console.WriteLine(b);
            double sinq, cosq, sinbig;
            while (n_theta <= theta2)
            {
                sinq = Math.Sin(n_theta_g);
                cosq = Math.Cos(n_theta_g);
                sinbig = Math.Sin((3.14 * b / lambda) * sinq);
                nowPnorm =  Math.Pow(lambda, 2) * Math.Pow(sinbig, 2) * Math.Pow((1 + cosq), 2) / ( 4 * 3.14 * 3.14 * b * b * sinq * sinq);
                //sin^2
  now1 =((1 + (((1/Math.Tan(3.14/lambda*b * sinq)) - (Math.Tan(3.14 / lambda * b * sinq))) / ((1 / Math.Tan(3.14 / lambda * b * sinq)) + 
                    (Math.Tan(3.14 / lambda * b * sinq)))) )/2);
                now = lambda * lambda * Math.Pow((1 + Math.Cos(n_theta_g)),2);
                now2 = ((1 + (((1 / Math.Tan(n_theta_g)) - Math.Tan(n_theta_g)) / ((1 / Math.Tan(n_theta_g)) - Math.Tan(n_theta_g)) )/ 2));
                newPnorm = (now1 * now )/ now2;
                n_theta += thetah;
                n_theta_g = (n_theta * 180) / 3.14;
                writer.WriteLine(n_theta_g + "\t" + newPnorm);
            }
        }

        static void Main(string[] args)
        {   
           // H_plane();
          E_plane();
            Console.ReadKey();
        }
    }
}
