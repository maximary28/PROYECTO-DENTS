using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_LP4.Server.Context;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Routes;
using Proyecto_LP4.Shared.Wrapper;

namespace Proyecto_LP4.Server.Endpoints.Tratamientos;
using Respuesta = Result<TratamientoRecord>;
using Request = TratamientoRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(TratamientoRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var tratamiento = await dbContext.Tratamientos
            .Where(t => t.Id == request.Id)
            .Select(tratamiento => tratamiento.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(tratamiento == null)
            return Respuesta.Fail($"No fue posible encontrar el tratamiento '{request.Id}'");

            return Respuesta.Sucess(tratamiento);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}