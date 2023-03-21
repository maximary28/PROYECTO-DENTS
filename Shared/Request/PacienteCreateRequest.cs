
using System.ComponentModel.DataAnnotations;

namespace Proyecto_LP4.Shared.Request;

public class PacienteCreateRequest
{
    [
        Required(ErrorMessage = "Ingrese un nombre valido"),
        MinLength(5, ErrorMessage = "El nombre debe poseer al menos 5 caracteres"),
        MaxLength(100, ErrorMessage = "El nombre debe poseer como maximo 100 caracteres")
    ]
    public string Nombre { get; set; } = null!;
    [
        Required(ErrorMessage = "Ingrese una dirección valido"),
        MinLength(5, ErrorMessage = "El dirección debe poseer al menos 10 caracteres"),
        MaxLength(100, ErrorMessage = "El dirección debe poseer como maximo 100 caracteres")
    ]
    public string Direccion { get; set; } = null!;
    [
        MinLength(5, ErrorMessage = "El nombre debe poseer al menos 5 caracteres"),
        MaxLength(100, ErrorMessage = "El nombre debe poseer como maximo 100 caracteres")
    ]
    public string NombreTutor { get; set; } = null!;
    public string Ocupacion { get; set; } = null!;
    [
        Required(ErrorMessage = "Ingrese el sexo")
    ]
    public string Sexo { get; set; } = null!;
    [Required(ErrorMessage = "Ingrese un valor valido")]
    public int Edad { get; set; }
    public string Telefono { get; set; } = null!;
    public bool Fuma { get; set; }
    public bool PresionAlta { get; set; }
    public bool PresionBaja { get; set; }
    public bool Corazon { get; set; }
    public bool Diabetes { get; set; }
    public bool Riñones { get; set; }
    public bool FiebreReumatica { get; set; }
    public bool Epilepsia { get; set; }
    public bool Asma { get; set; }
    public bool DoloresDeCabeza { get; set; }
    public bool Falcemia { get; set; }
    public bool Anemia { get; set; }
    public bool Hemofilia { get; set; }
    public bool Medicamento { get; set; }
    public string MedicamentoDescripcion { get; set; } = null!;
    public bool Embarazo { get; set; }
    public bool Alergia { get; set; }
    public string AlergiaDescripcion { get; set; } = null!;
}
