using Proyecto_LP4.Shared.Wrapper;
using Proyecto_LP4.Shared.Request;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Proyecto_LP4.Server.Context;
using Proyecto_LP4.Server.Models;
using Microsoft.EntityFrameworkCore;
using Proyecto_LP4.Shared.Routes;

namespace Restaurante.Server.Endpoints.Citas;

using Request = CitaCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(CitaRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var cita = await dbContext.Citas.FirstOrDefaultAsync(r => r.Fecha == request.Fecha,cancellationToken);
            if(cita != null)
                return Respuesta.Fail($"Ya existe una cita con la fecha y hora '({request.Fecha})'.");
            #endregion
            cita = Cita.Crear(request);
            dbContext.Citas.Add(cita);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(cita.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}