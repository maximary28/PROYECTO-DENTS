using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_LP4.Server.Context;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Routes;
using Proyecto_LP4.Shared.Wrapper;

namespace Proyecto_LP4.Server.Endpoints.Tratamientos;


using Respuesta = ResultList<TratamientoRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Get(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(TratamientoRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var tratamientos = await dbContext.Tratamientos.Select(tratamiento => tratamiento.ToRecord())
        .ToListAsync(cancellationToken);
            return Respuesta.Success(tratamientos);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }
}