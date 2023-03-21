
using System.ComponentModel.DataAnnotations;

namespace Proyecto_LP4.Shared.Request;

public class FacturaUpdateRequest: FacturaCreateRequest
{
    [   
        Required(ErrorMessage = "Ingrese un Id valido")
    ]
    public int Id { get; set; }
}
