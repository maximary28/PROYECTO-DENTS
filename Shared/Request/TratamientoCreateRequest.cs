
using System.ComponentModel.DataAnnotations;

namespace Proyecto_LP4.Shared.Request;

public class TratamientoCreateRequest
{
    [
        Required(ErrorMessage = "Ingrese un nombre valido"),
        MinLength(5, ErrorMessage = "El nombre debe poseer al menos 5 caracteres"),
        MaxLength(100, ErrorMessage = "El nombre debe poseer como maximo 100 caracteres")
    ]
    public string Nombre { get; set; } = null!;
    [
        Required(ErrorMessage = "Ingrese una descripcion valida valido")
    ]
    public string Descripcion { get; set; } = null!;
    [Required(ErrorMessage = "Ingrese un valor valido")]
    public float Precio { get; set; }
}
