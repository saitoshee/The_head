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
            
            
            //double max = GetNums(numbers);
            FileStream data = new FileStream("D:\\GNUPL\\Nakrap\\new_file.txt", FileMode.Create); //создаем файловый поток
            StreamWriter writer = new StreamWriter(data);

            
            double la;
                int f_min = 900; int f_max = 100; //4000;
            for (int j = f_min; j <= f_max; j += 10)
            {
                double b = 0;
                la = Consts.C_vel / j;
                b = (2 * Consts.Pi) / la;
                writer.WriteLine(b);
            }
            writer.Close();
        }
    }
}
/*File.Delete("D:\\GNUPL\\Nakrap\\new_file.txt"); // очищает файл
 for (int i = 0; i < 10; i++)
 {

     File.AppendAllText("D:\\GNUPL\\Nakrap\\new_file.txt", i.ToString());
 }
*/

/*
    int task_a(dcomlpex f_min, dcomlpex f_max, dcomlpex f_step, dcomlpex l, dcomlpex Z_in, dcomlpex Z_out)
    {
        dcomlpex R = Z_in / Z_out; cout << "\nR=" << R << "\n";
        dcomlpex lambda, f_now, beta_0, ksvn;
        std::ofstream file_task_a; file_task_a.open("file_task_a.dat");
        file_task_a << std::setprecision(11)
            << "#f_min=" << f_min << "Hz;"
            << "\n#f_max=" << f_max << "Hz;"
            << "\n#f_step=" << f_step << "Hz;"
            << "\n#l=" << l << "m;"
            << "\n#Z_in=" << Z_in << "Om;"
            << "\n#Z_out=" << Z_out << "Om;\n";
        file_task_a << "#f, Hz; KSVN\n";
        for (f_now = f_min; real(f_now) <= real(f_max); f_now += f_step)
        {
            lambda = C_velosity / f_now;
            beta_0 = 2.* PI / lambda;
            ksvn = 1. + ((abs(sin(beta_0 * l))) / (beta_0 * l)) * log(R);
            file_task_a << real(f_now) << "\t" << real(ksvn) << "\n";
        }
        file_task_a.close();
        return 1;
    }
    */

