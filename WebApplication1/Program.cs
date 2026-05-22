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
                        ProcesarReserva("Suite Premium", 300000);
                        break;

                    case 4:
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
        /// Muestra el título principal.
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
            Console.WriteLine("\n1. Habitación sencilla - $80.000");
            Console.WriteLine("2. Habitación doble - $150.000");
            Console.WriteLine("3. Suite premium - $300.000");
            Console.WriteLine("4. Salir");
        }

        /// <summary>
        /// Lee una opción válida.
        /// </summary>
        /// <returns>Opción seleccionada.</returns>
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

            double descuento = CalcularDescuento(subtotal, noches);

            double subtotalConDescuento = subtotal - descuento;

            double impuesto = CalcularImpuesto(subtotalConDescuento);

            double total = CalcularTotal(subtotalConDescuento, impuesto);

            MostrarResumen(
                tipoHabitacion,
                noches,
                subtotal,
                descuento,
                impuesto,
                total);
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
        /// Calcula descuento según cantidad de noches.
        /// </summary>
        /// <param name="subtotal">Subtotal de la reserva.</param>
        /// <param name="noches">Cantidad de noches.</param>
        /// <returns>Valor del descuento.</returns>
        static double CalcularDescuento(double subtotal, int noches)
        {
            if (noches >= 5)
            {
                return subtotal * 0.15;
            }

            return 0;
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
        /// <param name="descuento">Descuento aplicado.</param>
        /// <param name="impuesto">Impuesto.</param>
        /// <param name="total">Total final.</param>
        static void MostrarResumen(
            string habitacion,
            int noches,
            double subtotal,
            double descuento,
            double impuesto,
            double total)
        {
            Console.WriteLine("\n========== RESUMEN ==========");
            Console.WriteLine($"Habitación : {habitacion}");
            Console.WriteLine($"Noches     : {noches}");
            Console.WriteLine($"Subtotal   : ${subtotal}");
            Console.WriteLine($"Descuento  : ${descuento}");
            Console.WriteLine($"Impuesto   : ${impuesto}");
            Console.WriteLine($"Total      : ${total}");
            Console.WriteLine("=============================");
        }

        /// <summary>
        /// Pausa la consola hasta que el usuario presione ENTER.
        /// </summary>
        static void PausarPantalla()
        {
            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}