using System;

namespace HotelReservas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EjecutarSistemaReservas();
        }

        /// <summary>
        /// Controla la ejecución principal del sistema hotelero.
        /// </summary>
        static void EjecutarSistemaReservas()
        {
            bool continuar = true;

            while (continuar)
            {
                MostrarTitulo();
                MostrarMenu();

                int opcion = LeerOpcion();

                switch (opcion)
                {
                    case 1:
                        ProcesarReserva("Habitación Sencilla", 80000);
                        break;

                    case 2:
                        ProcesarReserva("Habitación Doble", 150000);
                        break;

                    case 3:
                        Console.WriteLine("\nGracias por usar el sistema.");
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("\nOpción inválida.");
                        break;
                }

                PausarPantalla();
            }
        }

        /// <summary>
        /// Muestra el título principal del sistema.
        /// </summary>
        static void MostrarTitulo()
        {
            Console.WriteLine("\n====================================");
            Console.WriteLine("     SISTEMA DE RESERVAS HOTEL");
            Console.WriteLine("====================================");
        }

        /// <summary>
        /// Muestra el menú principal.
        /// </summary>
        static void MostrarMenu()
        {
            Console.WriteLine("\n1. Habitación sencilla");
            Console.WriteLine("2. Habitación doble");
            Console.WriteLine("3. Salir");
        }

        /// <summary>
        /// Lee una opción válida del menú.
        /// </summary>
        /// <returns>Opción seleccionada por el usuario.</returns>
        static int LeerOpcion()
        {
            int opcion;

            do
            {
                Console.Write("\nSeleccione una opción: ");

            } while (!int.TryParse(Console.ReadLine(), out opcion));

            return opcion;
        }

        /// <summary>
        /// Procesa la reserva seleccionada.
        /// </summary>
        /// <param name="tipoHabitacion">Nombre de la habitación.</param>
        /// <param name="precioNoche">Precio por noche.</param>
        static void ProcesarReserva(string tipoHabitacion, double precioNoche)
        {
            int noches = LeerCantidadNoches();

            double subtotal = CalcularSubtotal(precioNoche, noches);
            double impuesto = CalcularImpuesto(subtotal);
            double total = CalcularTotal(subtotal, impuesto);

            MostrarResumen(tipoHabitacion, noches, subtotal, impuesto, total);
        }

        /// <summary>
        /// Solicita una cantidad válida de noches.
        /// </summary>
        /// <returns>Cantidad de noches.</returns>
        static int LeerCantidadNoches()
        {
            int noches;

            do
            {
                Console.Write("Ingrese cantidad de noches: ");

            } while (!int.TryParse(Console.ReadLine(), out noches) || noches <= 0);

            return noches;
        }

        /// <summary>
        /// Calcula el subtotal de la reserva.
        /// </summary>
        /// <param name="precioNoche">Precio por noche.</param>
        /// <param name="noches">Cantidad de noches.</param>
        /// <returns>Subtotal calculado.</returns>
        static double CalcularSubtotal(double precioNoche, int noches)
        {
            return precioNoche * noches;
        }

        /// <summary>
        /// Calcula el impuesto hotelero.
        /// </summary>
        /// <param name="subtotal">Subtotal de la reserva.</param>
        /// <returns>Valor del impuesto.</returns>
        static double CalcularImpuesto(double subtotal)
        {
            return subtotal * 0.10;
        }

        /// <summary>
        /// Calcula el total final de la reserva.
        /// </summary>
        /// <param name="subtotal">Subtotal calculado.</param>
        /// <param name="impuesto">Impuesto calculado.</param>
        /// <returns>Total a pagar.</returns>
        static double CalcularTotal(double subtotal, double impuesto)
        {
            return subtotal + impuesto;
        }

        /// <summary>
        /// Muestra el resumen final de la reserva.
        /// </summary>
        /// <param name="habitacion">Tipo de habitación.</param>
        /// <param name="noches">Cantidad de noches.</param>
        /// <param name="subtotal">Subtotal.</param>
        /// <param name="impuesto">Impuesto.</param>
        /// <param name="total">Total final.</param>
        static void MostrarResumen(
            string habitacion,
            int noches,
            double subtotal,
            double impuesto,
            double total)
        {
            Console.WriteLine("\n========== RESUMEN ==========");
            Console.WriteLine($"Habitación : {habitacion}");
            Console.WriteLine($"Noches     : {noches}");
            Console.WriteLine($"Subtotal   : ${subtotal}");
            Console.WriteLine($"Impuesto   : ${impuesto}");
            Console.WriteLine($"Total      : ${total}");
            Console.WriteLine("=============================");
        }

        /// <summary>
        /// Pausa la pantalla hasta que el usuario presione ENTER.
        /// </summary>
        static void PausarPantalla()
        {
            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}