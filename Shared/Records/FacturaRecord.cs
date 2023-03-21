
namespace Proyecto_LP4.Shared.Records;

public class FacturaRecord
{
    public FacturaRecord()
    {
        
    }
    public FacturaRecord(int id, int citaId, CitaRecord cita, float abonado, float balancePendiente)
    {
        Id = id;
        CitaId = citaId;
        Cita = cita;
        Abonado = abonado;
        BalancePendiente = balancePendiente;
    }

    public int Id { get; set; }
    public int CitaId { get; set; }
    public virtual CitaRecord Cita { get; set; } = null!;
    public float Abonado { get; set; }
    public float BalancePendiente { get; set; }
}
