using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperaturaS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double celcius, fahrenheit, kelvin;

            Console.Write("Ingrese la temperatura en grados celcius: ");
            celcius = double.Parse(Console.ReadLine());

            fahrenheit = (celcius * 9 / 5) + 32;
            kelvin = (celcius + 273.15);

            Console.WriteLine("La temperaura en fahrenheit es: {0}", fahrenheit);
            Console.WriteLine("La temperatura en kelvin es: {0}", kelvin);

            Console.ReadKey();
        }
    }
}
