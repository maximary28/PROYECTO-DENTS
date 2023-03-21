
namespace Proyecto_LP4.Shared.Records;

public class PacienteRecord
{
    public PacienteRecord()
    {
        
    }
    public PacienteRecord(int id, string nombre, string direccion, string nombreTutor, string ocupacion, string sexo, int edad, string telefono, bool fuma, bool presionAlta, bool presionBaja, bool corazon, bool diabetes, bool riñones, bool fiebreReumatica, bool epilepsia, bool asma, bool doloresDeCabeza, bool falcemia, bool anemia, bool hemofilia, bool medicamento, string medicamentoDescripcion, bool embarazo, bool alergia, string alergiaDescripcion)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        NombreTutor = nombreTutor;
        Ocupacion = ocupacion;
        Sexo = sexo;
        Edad = edad;
        Telefono = telefono;
        Fuma = fuma;
        PresionAlta = presionAlta;
        PresionBaja = presionBaja;
        Corazon = corazon;
        Diabetes = diabetes;
        Riñones = riñones;
        FiebreReumatica = fiebreReumatica;
        Epilepsia = epilepsia;
        Asma = asma;
        DoloresDeCabeza = doloresDeCabeza;
        Falcemia = falcemia;
        Anemia = anemia;
        Hemofilia = hemofilia;
        Medicamento = medicamento;
        MedicamentoDescripcion = medicamentoDescripcion;
        Embarazo = embarazo;
        Alergia = alergia;
        AlergiaDescripcion = alergiaDescripcion;
    }

    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string NombreTutor { get; set; } = null!;
    public string Ocupacion { get; set; } = null!;
    public string Sexo { get; set; } = null!;
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
