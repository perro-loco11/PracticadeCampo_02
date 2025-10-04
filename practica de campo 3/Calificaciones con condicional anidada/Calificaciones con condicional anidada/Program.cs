using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calificaciones_con_condicional_anidada
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double nota1, nota2, nota3;
            double promedio;
            string calificacion;

            Console.WriteLine("=== CÁLCULO DE CALIFICACIONES ===\n");

            Console.Write("Ingrese la primera nota: ");
            nota1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese la segunda nota: ");
            nota2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese la tercera nota: ");
            nota3 = Convert.ToDouble(Console.ReadLine());

            promedio = (nota1 + nota2 + nota3) / 3;

            if (promedio >= 17)
            {
                calificacion = "Excelente";
            }
            else if (promedio >= 13 && promedio <= 16)
            {
                calificacion = "Bueno";
            }
            else if (promedio >= 10 && promedio <= 12)
            {
                calificacion = "Regular";
            }
            else
            {
                calificacion = "Deficiente";
            }

            Console.WriteLine("\n=== RESULTADO ===");
            Console.WriteLine($"Promedio: {promedio:F2}");
            Console.WriteLine($"Calificación: {calificacion}");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
