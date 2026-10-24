
namespace PLANAZO_POO_CSharp.Modelos;

public class Usuario
{
    public int Id { get; private set; }

    public string Nombre { get; private set; }

    public Usuario(int id, string nombre)
    {
        if (id <= 0)
            throw new ArgumentException(
                "El identificador debe ser mayor que cero.");

        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException(
                "El nombre del usuario es obligatorio.");

        Id = id;
        Nombre = nombre;
    }

    public override string ToString()
    {
        return $"{Id} - {Nombre}";
    }
}
