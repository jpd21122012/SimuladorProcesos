using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorProcesos
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ingresa el numero de procesos");
            int Process = Convert.ToInt32(Console.ReadLine());
            List<int> list = new List<int>();
            for (int i = 0; i < Process; i++)
            {
                Console.WriteLine("Ingresa el numero de ciclos para el proceso " + (i + 1));
                list.Add(Convert.ToInt32(Console.ReadLine()));
            }
            Console.WriteLine("Iniciar procesos");
            Console.ReadKey();
            for (int i = 0; i < Process; i++)
            {
                Console.WriteLine("Se ha ejecutado el ciclo " + (i + 1));
                for (int j = 0; j < list.Count; j++)
                {
                    Random();
                }
                int rtemp = Ram();
                Console.WriteLine("El indice de la memoria es : " + rtemp);
                Console.WriteLine();
                rtemp += 1;
            }
            Console.ReadLine();
        }

        public static void Random()
        {
            int seed = unchecked(DateTime.Now.Ticks.GetHashCode());
            Random r = new Random(seed);
            Console.WriteLine(r.Next());
        }
        public static int Ram()
        {
            int seed = unchecked(DateTime.Now.Ticks.GetHashCode());
            Random r = new Random(seed);
            Console.WriteLine(r.Next(1, 1025));
            return r.Next(1, 1025);
        }
    }
}