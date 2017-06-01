using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimuladorProcesos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pedimos el numero de procesos a ejecutar
            Console.Write("No. Procesos a ejecutar: ");
            //Asignamos la entrada a un numero entero
            int Process = Convert.ToInt32(Console.ReadLine());
            /*Se crea una lista que contendra el 
            numero de ciclos de cada proceso
            */
            List<int> ciclos = new List<int>();
            //Se inicializa la varable de memoria RAM
            int ram = 0;
            /*Se obtiene el numero de ciclos para cada proceso
             * y los va añadiendo en la lista creada
            */
            for (int i = 0; i < Process; i++)
            {
                Console.WriteLine("No. Ciclos para el proceso: " + (i + 1));
                ciclos.Add(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine();
            }
            //El programa esta en espera para comenzar su ejecucion
            Console.WriteLine("Presiona una tecla para iniciar...");
            Console.ReadKey();
            //Hace una pequeña pausa antes de comenzar para liberar recursos
            Thread.Sleep(3000);
            //Se recorre cada proceso
            for (int j = 0; j < Process; j++)
            {
                Console.WriteLine("Iniciando nuevo proceso...");
                Thread.Sleep(3000);
                Console.WriteLine("Procesando...");
                Console.ForegroundColor = GetRandomConsoleColor();
                //Se obtiene la RAM utilizada actualmente
                ram = Ram();
                //Se recorre ahora para cada ciclo y se obtiene el espacio en memoria 
                //para cada ciclo
                for (int k = 0; k < ciclos[j]; k++)
                {
                    Console.Write("Iniciando el Proceso {0} tiene espacio en la direccion: 0x00000" +
                        ram + "   ", j);
                    Console.WriteLine("Ejecutando el proceso: {0}, y su ciclo: {1}", j + 1, k);
                    //Se manda a imprimir un numero aleatorio
                    Random();
                    ram++;
                }
                Console.WriteLine("+----------------------------------------------+");
                Thread.Sleep(2000);
                Console.WriteLine("Limpiando recursos...");
                //Se limpia la memoria y hace una pausa
                //ClearMemory();
                Thread.Sleep(1000);
                Console.WriteLine("Liberando espacio en memoria...");
                Thread.Sleep(2000);
                //Se inicia un nuevo proceso y hace una pausa
                //InitNewProcess();
                Console.WriteLine("Preparando ejecución de un nuevo proceso...");
                Thread.Sleep(3000);
                //Se libera la memoria cache y hace una pausa
                //CleanCache();
                Console.WriteLine("Limpiando caché...");
                Thread.Sleep(3000);
                Console.WriteLine("Liberando recursos...");
                Thread.Sleep(3000);
            }
            Console.ReadKey();
        }
        //Creacion de una variable constante aleatoria
        private static Random _random = new Random();
        /*
         * En el siguiente metodo obtiene un color de consola
         * aleatorio, para el cual pimero se enumeran todos los colores
         * predeterminados del sistema y a continuacion se obtiene uno de 
         * esos colores para asignarse a la variable _random
         */
        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }
        /*
         * En el siguiente metodo se hace un numero aleatorio para 
         * imprimirlo en pantalla a la hora de iterar en los procesos
         * Se crea una semilla para que estos numeros no se repitan
         */
        public static void Random()
        {
            int seed = unchecked(DateTime.Now.Ticks.GetHashCode());
            Random r = new Random(seed);
            Console.WriteLine(r.Next());
        }
        /*
         * Se obtiene un numero simulado de RAM mediante un
         * numero aleatorio
         */
        public static int Ram()
        {
            int seed = unchecked(DateTime.Now.Ticks.GetHashCode());
            Random r = new Random(seed);
            return r.Next(1, 1025);
        }
    }
}