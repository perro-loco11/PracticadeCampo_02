using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_TrabajoCampo
{
    internal class Program
    {
        



        
            // Variables estáticas para mantener el estado del cajero y el cliente
            private static decimal saldoActual = 1000.00m; // Saldo inicial S/. 1000
            private static int intentosFallidosRetiro = 0;
            private const int MAX_INTENTOS_FALLIDOS = 3; // Límite de intentos fallidos
            private const decimal MAX_RETIRO_POR_OPERACION = 500.00m; // Límite de retiro por operación
            private static bool operacionBloqueada = false;

            // Punto de entrada principal del programa (debe ser static)
            public static void Main()
            {
                // Bucle principal del menú que se ejecuta hasta que el usuario decida salir o la operación se bloquee
                while (true)
                {
                    if (operacionBloqueada)
                    {
                        MostrarBloqueoOperacion(); // Muestra el mensaje de bloqueo
                        break; // Sale del bucle y finaliza el programa
                    }

                    MostrarMenu(); // Muestra las opciones del menú
                    string entrada = Console.ReadLine();

                    if (int.TryParse(entrada, out int opcion))
                    {
                        switch (opcion)
                        {
                            case 1:
                                RealizarRetiro();
                                break;
                            case 2:
                                ConsultarSaldo(); // Opción para consultar saldo
                                break;
                            case 3:
                                RealizarDeposito();
                                break;
                            case 4:
                                MostrarMensajeSalida(); // Opción para salir
                                return; // Sale del método Main y finaliza la aplicación
                            default:
                                MostrarErrorOpcionInvalida(); // Mensaje para opción no válida
                                break;
                        }
                    }
                    else
                    {
                        MostrarErrorOpcionInvalida();
                    }

                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            // --- MÉTODOS VOID (Mostrar mensajes / información) ---

            public static void MostrarMenu()
            {
                Console.WriteLine("=== MENÚ DEL CAJERO ===");
                Console.WriteLine("1. Retirar dinero");
                Console.WriteLine("2. Consultar saldo");
                Console.WriteLine("3. Depositar dinero");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
            }

            public static void ConsultarSaldo()
            {
                Console.WriteLine($"\nSaldo actual: S/. {saldoActual:N2}"); // Muestra el saldo actual
            }

            public static void MostrarRetiroExitoso(decimal nuevoSaldo)
            {
                Console.WriteLine("\nRetiro exitoso.");
                Console.WriteLine($"Nuevo saldo: S/. {nuevoSaldo:N2}");
                // Reiniciar el contador de intentos fallidos al tener éxito
                intentosFallidosRetiro = 0;
            }

            public static void MostrarDepositoExitoso(decimal nuevoSaldo)
            {
                Console.WriteLine("\nDepósito exitoso.");
                Console.WriteLine($"Nuevo saldo: S/. {nuevoSaldo:N2}");
            }

            public static void MostrarErrorRetiro(int intentos)
            {
                Console.WriteLine("\nError: Monto inválido o excede límites.");
                Console.WriteLine("Intente nuevamente.");
                Console.WriteLine($"Intentos fallidos: {intentos}"); // Muestra el contador de fallos
            }

            public static void MostrarErrorDeposito()
            {
                Console.WriteLine("\nError: El monto a depositar debe ser mayor a S/. 0.00.");
            }

            public static void MostrarBloqueoOperacion()
            {
                Console.WriteLine("\nDemasiados intentos fallidos. Operación bloqueada."); // Bloqueo a los 3 intentos fallidos
            }

            public static void MostrarErrorOpcionInvalida()
            {
                Console.WriteLine("\nError: Opción no válida. Por favor, seleccione un número del 1 al 4.");
            }

            public static void MostrarMensajeSalida()
            {
                Console.WriteLine("\nGracias por usar el Cajero Automático. ¡Hasta pronto!");
            }

            // --- MÉTODOS CON RETURN (Validación y actualización de estado) ---

            public static bool ValidarMontoRetiro(decimal monto)
            {
                // El retiro no puede ser mayor a S/. 500 por operación
                if (monto > MAX_RETIRO_POR_OPERACION)
                {
                    return false;
                }

                // El retiro no puede superar el saldo disponible
                if (monto > saldoActual)
                {
                    return false;
                }

                // El monto debe ser positivo y razonable (no incluido en las reglas, pero buena práctica)
                if (monto <= 0)
                {
                    return false;
                }

                return true;
            }

            public static bool ValidarMontoDeposito(decimal monto)
            {
                // Validar que el monto sea mayor a 0
                return monto > 0;
            }

            public static decimal ActualizarSaldoRetiro(decimal monto)
            {
                // Se asume que ValidarMontoRetiro ya fue llamado y retornó true
                saldoActual -= monto;
                return saldoActual; // Retorna el nuevo saldo
            }

            public static decimal ActualizarSaldoDeposito(decimal monto)
            {
                // Se asume que ValidarMontoDeposito ya fue llamado y retornó true
                saldoActual += monto;
                return saldoActual; // Retorna el nuevo saldo
            }

            // --- Métodos de Control de Flujo (Lógica de la operación) ---

            public static void RealizarRetiro()
            {
                Console.Write("Ingrese el monto a retirar: ");
                string entradaMonto = Console.ReadLine();

                if (decimal.TryParse(entradaMonto, out decimal monto) && ValidarMontoRetiro(monto))
                {
                    // Retiro exitoso: Actualizar saldo y mostrar mensaje
                    decimal nuevoSaldo = ActualizarSaldoRetiro(monto);
                    MostrarRetiroExitoso(nuevoSaldo);
                }
                else
                {
                    // Retiro inválido: Incrementar contador de intentos fallidos
                    intentosFallidosRetiro++;

                    MostrarErrorRetiro(intentosFallidosRetiro);

                    // Bloquear el retiro a los 3 intentos fallidos
                    if (intentosFallidosRetiro >= MAX_INTENTOS_FALLIDOS)
                    {
                        operacionBloqueada = true;
                    }
                }
            }

            public static void RealizarDeposito()
            {
                Console.Write("Ingrese el monto a depositar: ");
                string entradaMonto = Console.ReadLine();

                if (decimal.TryParse(entradaMonto, out decimal monto) && ValidarMontoDeposito(monto))
                {
                    // Depósito exitoso: Actualizar saldo y mostrar mensaje
                    decimal nuevoSaldo = ActualizarSaldoDeposito(monto);
                    MostrarDepositoExitoso(nuevoSaldo);
                    // Si el depósito es exitoso, se reinicia el contador de intentos fallidos de retiro
                    intentosFallidosRetiro = 0;
                }
                else
                {
                    // Depósito inválido: Mostrar error
                    MostrarErrorDeposito();
                }
            }
        }
    }
    

