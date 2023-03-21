using System.ComponentModel.DataAnnotations;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Request;

namespace Proyecto_LP4.Server.Models;

public class Factura
{
    [Key]
    public int Id { get; set; }
    public int CitaId { get; set; }
    public virtual Cita Cita { get; set; } = null!;
    public float Abonado { get; set; }
    public float BalancePendiente { get; set; }

    public static Factura Crear(FacturaCreateRequest request)
    {
        return new Factura(){
            CitaId = request.CitaId,
            Abonado = request.Abonado,
            BalancePendiente = request.BalancePendiente
        };
    }

    public void Modificar(FacturaUpdateRequest request)
    {
        if(CitaId != request.CitaId)
            CitaId = request.CitaId;
        if(Abonado != request.Abonado)
            Abonado = request.Abonado;
        if(BalancePendiente != request.BalancePendiente)
            BalancePendiente = request.BalancePendiente;
    }

    public FacturaRecord ToRecord()
    {
        return new FacturaRecord(Id, CitaId, Cita.ToRecord(), Abonado, BalancePendiente);
    }
}