
using PLANAZO_POO_CSharp.Modelos;

namespace PLANAZO_POO_CSharp.Servicios;

public class GestorReservas
{
    private List<Evento> eventos = new List<Evento>();

    private List<Reserva> reservas = new List<Reserva>();

    private int siguienteReserva = 1;

    public void RegistrarEvento(Evento evento)
    {
        if (evento == null)
            throw new ArgumentNullException(nameof(evento));

        foreach (Evento existente in eventos)
        {
            if (existente.Id == evento.Id)
                throw new InvalidOperationException(
                    "Ya existe un evento con ese identificador.");
        }

        eventos.Add(evento);
    }

    public void MostrarEventos()
    {
        Console.WriteLine("\n===== EVENTOS DISPONIBLES =====");

        foreach (Evento evento in eventos)
        {
            evento.MostrarInformacion();
            Console.WriteLine("----------------------------");
        }
    }

    public Evento? BuscarEvento(int id)
    {
        foreach (Evento evento in eventos)
        {
            if (evento.Id == id)
                return evento;
        }

        return null;
    }

    public Reserva CrearReserva(
        Usuario usuario,
        int idEvento,
        int cantidad)
    {
        if (usuario == null)
            throw new ArgumentNullException(nameof(usuario));

        if (cantidad <= 0)
            throw new ArgumentException(
                "La cantidad debe ser mayor que cero.");

        Evento? evento = BuscarEvento(idEvento);

        if (evento == null)
            throw new InvalidOperationException(
                "El evento no existe.");

        if (cantidad > evento.CuposDisponibles)
            throw new InvalidOperationException(
                "No hay suficientes cupos disponibles.");

        evento.ReservarCupos(cantidad);

        try
        {
            Reserva reserva = new Reserva(
                siguienteReserva,
                usuario,
                evento,
                cantidad);

            reservas.Add(reserva);

            siguienteReserva++;

            return reserva;
        }
        catch
        {
            evento.DevolverCupos(cantidad);
            throw;
        }
    }

    public Reserva? BuscarReserva(int id)
    {
        foreach (Reserva reserva in reservas)
        {
            if (reserva.Id == id)
                return reserva;
        }

        return null;
    }

    public void MostrarReservas()
    {
        Console.WriteLine("\n===== RESERVAS REALIZADAS =====");

        if (reservas.Count == 0)
        {
            Console.WriteLine(
                "No existen reservas registradas.");
            return;
        }

        foreach (Reserva reserva in reservas)
        {
            reserva.MostrarInformacion();
            Console.WriteLine("----------------------------");
        }
    }

    public void CancelarReserva(int id)
    {
        Reserva? reserva = BuscarReserva(id);

        if (reserva == null)
            throw new InvalidOperationException(
                "La reserva no existe.");

        reserva.Cancelar();

        Console.WriteLine(
            "Reserva cancelada correctamente.");
    }

    public void MostrarReservasUsuario(int idUsuario)
    {
        bool encontrada = false;

        Console.WriteLine(
            "\n===== RESERVAS DEL USUARIO =====");

        foreach (Reserva reserva in reservas)
        {
            if (reserva.Usuario.Id == idUsuario)
            {
                reserva.MostrarInformacion();

                Console.WriteLine("----------------------------");

                encontrada = true;
            }
        }

        if (!encontrada)
        {
            Console.WriteLine(
                "El usuario no tiene reservas.");
        }
    }

    public void MostrarResumen()
    {
        int reservasActivas = 0;

        int entradasReservadas = 0;

        decimal valorTotal = 0;

        foreach (Reserva reserva in reservas)
        {
            if (reserva.Estado == "Activa")
            {
                reservasActivas++;

                entradasReservadas +=
                    reserva.CantidadEntradas;

                valorTotal += reserva.ValorTotal;
            }
        }

        Console.WriteLine("\n===== RESUMEN DE RESERVAS =====");

        Console.WriteLine(
            $"Reservas activas: {reservasActivas}");

        Console.WriteLine(
            $"Entradas reservadas: {entradasReservadas}");

        Console.WriteLine(
            $"Valor total: {valorTotal:C0}");
    }
}
