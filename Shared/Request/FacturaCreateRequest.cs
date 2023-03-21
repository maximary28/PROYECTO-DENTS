
using System.ComponentModel.DataAnnotations;

namespace Proyecto_LP4.Shared.Request;

public class FacturaCreateRequest
{
    [Required(ErrorMessage = "Ingrese un id valido")]
    public int CitaId { get; set; }
    [Required(ErrorMessage = "Ingrese un valor valido")]
    public float Abonado { get; set; }
    [Required(ErrorMessage = "Ingrese un valor valido")]
    public float BalancePendiente { get; set; }
}
