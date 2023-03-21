using System.ComponentModel.DataAnnotations;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Request;

namespace Proyecto_LP4.Server.Models;

public class Cita
{
    [Key]
    public int Id { get; set; }
    public int PacienteId { get; set; }
    public virtual Paciente Paciente { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public int TratamientoId { get; set; }
    public virtual Tratamiento Tratamiento { get; set; } = null!;
    public DateTime ProximaCita { get; set; }
    public string Observaciones { get; set; } = null!;

     public static Cita Crear(CitaCreateRequest request)
    {
        return new Cita(){
            PacienteId = request.PacienteId,
            Fecha = request.Fecha,
            TratamientoId = request.TratamientoId,
            ProximaCita = request.ProximaCita,
            Observaciones = request.Observaciones
        };
    }

    public void Modificar(CitaUpdateRequest request)
    {
        if(PacienteId != request.PacienteId)
            PacienteId = request.PacienteId;
        if(Fecha != request.Fecha)
            Fecha = request.Fecha;
        if(TratamientoId != request.TratamientoId)
            TratamientoId = request.TratamientoId;
        if(ProximaCita != request.ProximaCita)
            ProximaCita = request.ProximaCita;
        if(Observaciones != request.Observaciones)
            Observaciones = request.Observaciones;
    }

    public CitaRecord ToRecord()
    {
        return new CitaRecord(Id, PacienteId, Paciente.ToRecord(), Fecha, TratamientoId, Tratamiento.ToRecord(), ProximaCita, Observaciones);
    }
}