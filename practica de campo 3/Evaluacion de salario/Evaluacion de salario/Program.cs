using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion_de_salario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EVALUACION DE SALARIO MENSUAL ===\n");

            // Solicitar el salario al usuario
            Console.Write("Ingrese el salario mensual del trabajador (S/): ");

            // Leer la entrada
            double salario = Convert.ToDouble(Console.ReadLine());

            // Validar que el salario sea positivo
            if (salario < 0)
            {
                Console.WriteLine("\nError: El salario no puede ser negativo.");
                return;
            }

            // Clasificar el salario según el rango
            string clasificacion;

            if (salario < 1200)
            {
                clasificacion = "Bajo";
            }
            else if (salario >= 1200 && salario <= 2500)
            {
                clasificacion = "Medio";
            }
            else
            {
                clasificacion = "Alto";
            }

            // Mostrar el resultado
            Console.WriteLine("\n--- RESULTADO ---");
            Console.WriteLine($"Salario ingresado: S/ {salario:N2}");
            Console.WriteLine($"Clasificación: {clasificacion}");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();

        }
    }
}
