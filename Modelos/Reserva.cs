
using System;

namespace PLANAZO_POO_CSharp.Modelos;

public class Reserva
{
    public int Id { get; private set; }

    public Usuario Usuario { get; private set; }

    public Evento Evento { get; private set; }

    public int CantidadEntradas { get; private set; }

    public decimal ValorTotal { get; private set; }

    public string Estado { get; private set; }

    public Reserva(
        int id,
        Usuario usuario,
        Evento evento,
        int cantidadEntradas)
    {
        if (id <= 0)
            throw new ArgumentException(
                "El identificador debe ser mayor que cero.");

        if (usuario == null)
            throw new ArgumentNullException(
                nameof(usuario));

        if (evento == null)
            throw new ArgumentNullException(
                nameof(evento));

        if (cantidadEntradas <= 0)
            throw new ArgumentException(
                "La cantidad de entradas debe ser mayor que cero.");

        Id = id;
        Usuario = usuario;
        Evento = evento;
        CantidadEntradas = cantidadEntradas;

        ValorTotal =
            evento.CalcularPrecioFinal() * cantidadEntradas;

        Estado = "Activa";
    }

    public void Cancelar()
    {
        if (Estado == "Cancelada")
            throw new InvalidOperationException(
                "La reserva ya fue cancelada.");

        if (Estado != "Activa")
            throw new InvalidOperationException(
                "La reserva no se encuentra activa.");

        Evento.DevolverCupos(CantidadEntradas);

        Estado = "Cancelada";
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Reserva: {Id}");
        Console.WriteLine($"Usuario: {Usuario.Nombre}");
        Console.WriteLine($"Evento: {Evento.Nombre}");
        Console.WriteLine($"Entradas: {CantidadEntradas}");
        Console.WriteLine($"Valor total: {ValorTotal:C0}");
        Console.WriteLine($"Estado: {Estado}");
    }
}
