using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suma_de_factoriales
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            long sumaTotal;

            Console.WriteLine("=== SUMA DE FACTORIALES ===\n");

            Console.Write("Ingrese un número N: ");
            n = Convert.ToInt32(Console.ReadLine());

            sumaTotal = 0;

            Console.WriteLine($"\nCalculando la suma de factoriales desde 1! hasta {n}!:\n");

            for (int i = 1; i <= n; i++)
            {
                long factorial;
                factorial = CalcularFactorial(i);

                Console.WriteLine($"{i}! = {factorial}");

                sumaTotal = sumaTotal + factorial;
            }

            Console.WriteLine($"\nSuma total: {sumaTotal}");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        static long CalcularFactorial(int numero)
        {
            long resultado;
            resultado = 1;

            for (int i = 1; i <= numero; i++)
            {
                resultado = resultado * i;
            }

            return resultado;
        }
    }
}
