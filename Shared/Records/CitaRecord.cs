
namespace Proyecto_LP4.Shared.Records;

public class CitaRecord
{
    public CitaRecord()
    {
        
    }
    public CitaRecord(int id, int pacienteId, PacienteRecord paciente, DateTime fecha, int tratamientoId, TratamientoRecord tratamiento, DateTime proximaCita, string observaciones)
    {
        Id = id;
        PacienteId = pacienteId;
        Paciente = paciente;
        Fecha = fecha;
        TratamientoId = tratamientoId;
        Tratamiento = tratamiento;
        ProximaCita = proximaCita;
        Observaciones = observaciones;
    }

    public int Id { get; set; }
    public int PacienteId { get; set; }
    public virtual PacienteRecord Paciente { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public int TratamientoId { get; set; }
    public virtual TratamientoRecord Tratamiento { get; set; } = null!;
    public DateTime ProximaCita { get; set; }
    public string Observaciones { get; set; } = null!;
}
