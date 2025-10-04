using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Número_pares_en_un_rango__for_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== NÚMEROS PARES EN UN RANGO ===\n");

            Console.Write("Ingrese el número de inicio: ");
            int inicio = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el número de fin: ");
            int fin = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nNúmeros pares entre {inicio} y {fin}:\n");

            for (int i = inicio; i <= fin; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
