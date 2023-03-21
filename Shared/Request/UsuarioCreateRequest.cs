
using System.ComponentModel.DataAnnotations;

namespace Proyecto_LP4.Shared.Request;

public class UsuarioCreateRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "Ingrese un Id valido")]
    public int UsuarioRolId { get; set; }
    [
        Required(ErrorMessage = "Ingrese un nombre valido"),
        MinLength(5, ErrorMessage = "El nombre debe poseer al menos 5 caracteres"),
        MaxLength(100, ErrorMessage = "El nombre debe poseer como maximo 100 caracteres")
    ]
    public string Nombre { get; set; } = null!;
    [
        Required(ErrorMessage = "Ingrese un nombre valido"),
        MinLength(3, ErrorMessage = "El nombre debe poseer al menos 3 caracteres"),
        MaxLength(100, ErrorMessage = "El nombre debe poseer como maximo 25 caracteres")
    ]
    public string NombreUsuario { get; set; } = null!;
    [
        Required(ErrorMessage = "Ingrese un contraseña valido"),
        MinLength(6, ErrorMessage = "La contraseña debe poseer al menos 6 caracteres"),
        MaxLength(100, ErrorMessage = "La contraseña debe poseer como maximo 25 caracteres")
    ]
    public string Password { get; set; } = null!;
}
