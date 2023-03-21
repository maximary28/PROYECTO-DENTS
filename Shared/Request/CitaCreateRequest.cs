
using System.ComponentModel.DataAnnotations;

namespace Proyecto_LP4.Shared.Request;

public class CitaCreateRequest
{
    [Required(ErrorMessage = "Ingrese un id valido")]
    public int PacienteId { get; set; }
    [Required(ErrorMessage = "Ingrese una fecha valida")]
    public DateTime Fecha { get; set; }
    [Required(ErrorMessage = "Ingrese un id valido")]
    public int TratamientoId { get; set; }
    [Required(ErrorMessage = "Ingrese una fecha valida")]
    public DateTime ProximaCita { get; set; }
    public string Observaciones { get; set; } = null!;
}
