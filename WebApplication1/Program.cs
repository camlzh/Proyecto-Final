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
        /// Controla la ejecución general del sistema.
        /// </summary>
        static void EjecutarSistemaReservas()
        {
            bool continuar = true;

            while (continuar)
            {
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
                        Console.WriteLine("Sistema finalizado.");
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }

        /// <summary>
        /// Muestra el menú principal.
        /// </summary>
        static void MostrarMenu()
        {
            Console.WriteLine("\n===== HOTEL =====");
            Console.WriteLine("1. Reservar habitación sencilla");
            Console.WriteLine("2. Reservar habitación doble");
            Console.WriteLine("3. Salir");
        }

        /// <summary>
        /// Lee la opción seleccionada.
        /// </summary>
        /// <returns>Opción elegida por el usuario.</returns>
        static int LeerOpcion()
        {
            Console.Write("Seleccione una opción: ");
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Procesa la reserva de una habitación.
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
        /// Solicita la cantidad de noches.
        /// </summary>
        /// <returns>Número de noches.</returns>
        static int LeerCantidadNoches()
        {
            Console.Write("Ingrese cantidad de noches: ");
            return int.Parse(Console.ReadLine());
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
        /// Calcula el total final.
        /// </summary>
        /// <param name="subtotal">Subtotal.</param>
        /// <param name="impuesto">Impuesto calculado.</param>
        /// <returns>Total a pagar.</returns>
        static double CalcularTotal(double subtotal, double impuesto)
        {
            return subtotal + impuesto;
        }

        /// <summary>
        /// Muestra el resumen de la reserva.
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
            Console.WriteLine("\n===== RESUMEN =====");
            Console.WriteLine($"Habitación: {habitacion}");
            Console.WriteLine($"Noches: {noches}");
            Console.WriteLine($"Subtotal: ${subtotal}");
            Console.WriteLine($"Impuesto: ${impuesto}");
            Console.WriteLine($"Total: ${total}");
        }
    }
}