using System.ComponentModel.DataAnnotations;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Request;

namespace Proyecto_LP4.Server.Models;

public class Tratamiento
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public float Precio { get; set; }

    public static Tratamiento Crear(TratamientoCreateRequest request)
    {
        return new Tratamiento(){
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Precio = request.Precio
        };
    }

    public void Modificar(TratamientoUpdateRequest request)
    {
        if(Nombre != request.Nombre)
            Nombre = request.Nombre;
        if(Descripcion != request.Descripcion)
            Descripcion = request.Descripcion;
        if(Precio != request.Precio)
            Precio = request.Precio;
    }

    public TratamientoRecord ToRecord()
    {
        return new TratamientoRecord(Id, Nombre, Descripcion, Precio);
    }
}