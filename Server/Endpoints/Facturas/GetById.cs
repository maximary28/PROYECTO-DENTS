using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_LP4.Server.Context;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Routes;
using Proyecto_LP4.Shared.Wrapper;

namespace Proyecto_LP4.Server.Endpoints.Facturas;
using Respuesta = Result<FacturaRecord>;
using Request = FacturaRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(FacturaRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var factura = await dbContext.Facturas
            .Where(f => f.Id == request.Id)
            .Select(factura => factura.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(factura == null)
            return Respuesta.Fail($"No fue posible encontrar la factura '{request.Id}'");

            return Respuesta.Sucess(factura);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}