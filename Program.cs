
using PLANAZO_POO_CSharp.Modelos;
using PLANAZO_POO_CSharp.Servicios;

class Program
{
    static GestorReservas gestor = new GestorReservas();

    static Usuario usuarioActual =
        new Usuario(1, "Carlos");

    static void Main()
    {
        RegistrarEventosIniciales();

        bool continuar = true;

        while (continuar)
        {
            MostrarMenu();

            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            try
            {
                switch (opcion)
                {
                    case "1":
                        gestor.MostrarEventos();
                        break;

                    case "2":
                        ConsultarEvento();
                        break;

                    case "3":
                        ReservarEntradas();
                        break;

                    case "4":
                        gestor.MostrarReservas();
                        break;

                    case "5":
                        CancelarReserva();
                        break;

                    case "6":
                        gestor.MostrarResumen();
                        break;

                    case "7":
                        ConsultarReservasUsuario();
                        break;

                    case "0":
                        continuar = false;
                        Console.WriteLine(
                            "Gracias por utilizar PLANAZO.");
                        break;

                    default:
                        Console.WriteLine(
                            "Opción incorrecta. Intente nuevamente.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Error: " + ex.Message);
            }

            if (continuar)
            {
                Console.WriteLine(
                    "\nPresione ENTER para continuar.");

                Console.ReadLine();
            }
        }
    }

    static void MostrarMenu()
    {
        Console.Clear();

        Console.WriteLine("================================");
        Console.WriteLine("       PLANAZO - EVENTOS");
        Console.WriteLine("================================");

        Console.WriteLine("1. Ver eventos disponibles");
        Console.WriteLine("2. Consultar evento");
        Console.WriteLine("3. Reservar entradas");
        Console.WriteLine("4. Ver reservas realizadas");
        Console.WriteLine("5. Cancelar una reserva");
        Console.WriteLine("6. Ver resumen de reservas");
        Console.WriteLine("7. Consultar reservas de usuario");
        Console.WriteLine("0. Salir");

        Console.WriteLine("================================");
    }

    static void RegistrarEventosIniciales()
    {
        gestor.RegistrarEvento(
            new Cine(
                1,
                "Avengers",
                new DateTime(2026, 11, 10),
                25000m,
                50));

        gestor.RegistrarEvento(
            new Cine(
                2,
                "Interestelar",
                new DateTime(2026, 11, 15),
                30000m,
                40));

        gestor.RegistrarEvento(
            new Concierto(
                3,
                "Concierto de Rock",
                new DateTime(2026, 12, 5),
                50000m,
                100));

        gestor.RegistrarEvento(
            new Concierto(
                4,
                "Concierto Pop",
                new DateTime(2026, 12, 12),
                80000m,
                150));

        gestor.RegistrarEvento(
            new Taller(
                5,
                "Taller de Fotografía",
                new DateTime(2026, 11, 20),
                60000m,
                30));

        gestor.RegistrarEvento(
            new Taller(
                6,
                "Taller de Pintura",
                new DateTime(2026, 11, 25),
                40000m,
                25));

        // Evento adicional del reto 1
        gestor.RegistrarEvento(
            new EventoDeportivo(
                7,
                "Torneo de Fútbol",
                new DateTime(2026, 12, 20),
                50000m,
                200));
    }

    static void ConsultarEvento()
    {
        Console.Write("Ingrese el ID del evento: ");

        int id = LeerEntero();

        Evento? evento = gestor.BuscarEvento(id);

        if (evento == null)
        {
            Console.WriteLine(
                "El evento no existe.");
            return;
        }

        evento.MostrarInformacion();
    }

    static void ReservarEntradas()
    {
        Console.WriteLine("\n===== NUEVA RESERVA =====");

        Console.Write("Ingrese el ID del evento: ");

        int idEvento = LeerEntero();

        Console.Write("Ingrese la cantidad de entradas: ");

        int cantidad = LeerEntero();

        Reserva reserva = gestor.CrearReserva(
            usuarioActual,
            idEvento,
            cantidad);

        Console.WriteLine(
            "\nReserva realizada correctamente.");

        reserva.MostrarInformacion();
    }

    static void CancelarReserva()
    {
        Console.WriteLine("\n===== CANCELAR RESERVA =====");

        Console.Write("Ingrese el ID de la reserva: ");

        int id = LeerEntero();

        gestor.CancelarReserva(id);
    }

    static void ConsultarReservasUsuario()
    {
        Console.WriteLine("\n===== CONSULTAR USUARIO =====");

        Console.WriteLine(usuarioActual);

        gestor.MostrarReservasUsuario(
            usuarioActual.Id);
    }

    static int LeerEntero()
    {
        while (true)
        {
            string? entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int numero))
            {
                return numero;
            }

            Console.WriteLine(
                "Debe ingresar un número entero.");

            Console.Write("Intente nuevamente: ");
        }
    }
}

