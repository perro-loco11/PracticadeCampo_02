using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menú_de_figuras_geometricas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== CALCULADORA DE ÁREAS ===\n");
                Console.WriteLine("1. Área del cuadrado");
                Console.WriteLine("2. Área del triángulo");
                Console.WriteLine("3. Área del círculo");
                Console.WriteLine("4. Salir");
                Console.Write("\nSeleccione una opción: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        CalcularAreaCuadrado();
                        break;

                    case 2:
                        CalcularAreaTriangulo();
                        break;

                    case 3:
                        CalcularAreaCirculo();
                        break;

                    case 4:
                        Console.WriteLine("\n¡Gracias por usar el programa!");
                        break;

                    default:
                        Console.WriteLine("\nOpción inválida.");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 4);
        }

        static void CalcularAreaCuadrado()
        {
            Console.Write("\nIngrese el lado del cuadrado: ");
            double lado = Convert.ToDouble(Console.ReadLine());

            double area = lado * lado;

            Console.WriteLine($"\nÁrea del cuadrado: {area} unidades²");
            Console.ReadKey();
        }

        static void CalcularAreaTriangulo()
        {
            Console.Write("\nIngrese la base del triángulo: ");
            double baseTriangulo = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese la altura del triángulo: ");
            double altura = Convert.ToDouble(Console.ReadLine());

            double area = (baseTriangulo * altura) / 2;

            Console.WriteLine($"\nÁrea del triángulo: {area} unidades²");
            Console.ReadKey();
        }

        static void CalcularAreaCirculo()
        {
            Console.Write("\nIngrese el radio del círculo: ");
            double radio = Convert.ToDouble(Console.ReadLine());

            double area = Math.PI * radio * radio;

            Console.WriteLine($"\nÁrea del círculo: {area} unidades²");
            Console.ReadKey();
        }
    }
}
