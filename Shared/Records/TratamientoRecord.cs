
namespace Proyecto_LP4.Shared.Records;

public class TratamientoRecord
{
    public TratamientoRecord()
    {
        
    }
    public TratamientoRecord(int id, string nombre, string descripcion, float precio)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;
    }

    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public float Precio { get; set; }
}
