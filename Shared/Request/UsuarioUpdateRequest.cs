
using System.ComponentModel.DataAnnotations;

namespace Proyecto_LP4.Shared.Request;

public class UsuarioUpdateRequest: UsuarioCreateRequest
{
    [   
        Required(ErrorMessage = "Ingrese un Id valido")
    ]
    public int Id { get; set; }
}
