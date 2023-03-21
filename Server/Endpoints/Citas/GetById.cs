using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_LP4.Server.Context;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Routes;
using Proyecto_LP4.Shared.Wrapper;

namespace Proyecto_LP4.Server.Endpoints.Citas;
using Respuesta = Result<CitaRecord>;
using Request = CitaRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(CitaRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var cita = await dbContext.Citas
            .Where(c => c.Id == request.Id)
            .Select(cita => cita.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(cita == null)
            return Respuesta.Fail($"No fue posible encontrar la cita '{request.Id}'");

            return Respuesta.Sucess(cita);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}