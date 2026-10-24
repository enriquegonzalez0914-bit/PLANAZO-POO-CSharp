
namespace PLANAZO_POO_CSharp.Modelos;

public abstract class Evento
{
    public int Id { get; private set; }

    public string Nombre { get; private set; }

    public DateTime Fecha { get; private set; }

    public decimal PrecioBase { get; private set; }

    public int CapacidadMaxima { get; private set; }

    public int CuposDisponibles { get; private set; }

    public Evento(
        int id,
        string nombre,
        DateTime fecha,
        decimal precioBase,
        int capacidadMaxima)
    {
        if (id <= 0)
            throw new ArgumentException("El identificador debe ser mayor que cero.");

        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre del evento es obligatorio.");

        if (precioBase < 0)
            throw new ArgumentException("El precio no puede ser negativo.");

        if (capacidadMaxima <= 0)
            throw new ArgumentException("La capacidad debe ser mayor que cero.");

        Id = id;
        Nombre = nombre;
        Fecha = fecha;
        PrecioBase = precioBase;
        CapacidadMaxima = capacidadMaxima;
        CuposDisponibles = capacidadMaxima;
    }

    public abstract decimal CalcularPrecioFinal();

    public void ReservarCupos(int cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentException(
                "La cantidad debe ser mayor que cero.");

        if (cantidad > CuposDisponibles)
            throw new InvalidOperationException(
                "No hay suficientes cupos disponibles.");

        CuposDisponibles -= cantidad;
    }

    public void DevolverCupos(int cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentException(
                "La cantidad debe ser mayor que cero.");

        if (CuposDisponibles + cantidad > CapacidadMaxima)
            throw new InvalidOperationException(
                "No se pueden devolver más cupos de los disponibles.");

        CuposDisponibles += cantidad;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Fecha: {Fecha:dd/MM/yyyy}");
        Console.WriteLine($"Precio base: {PrecioBase:C0}");
        Console.WriteLine($"Precio final: {CalcularPrecioFinal():C0}");
        Console.WriteLine($"Capacidad: {CapacidadMaxima}");
        Console.WriteLine($"Cupos disponibles: {CuposDisponibles}");
    }
}
