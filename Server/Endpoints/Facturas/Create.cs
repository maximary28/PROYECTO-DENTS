using Proyecto_LP4.Shared.Wrapper;
using Proyecto_LP4.Shared.Request;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Proyecto_LP4.Server.Context;
using Proyecto_LP4.Server.Models;
using Microsoft.EntityFrameworkCore;
using Proyecto_LP4.Shared.Routes;

namespace Restaurante.Server.Endpoints.Facturas;

using Request = FacturaCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(FacturaRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var factura = await dbContext.Facturas.FirstOrDefaultAsync(r => r.CitaId == request.CitaId,cancellationToken);
            if(factura != null)
                return Respuesta.Fail($"Ya existe una factura de la cta'({request.CitaId})'.");
            #endregion
            factura = Factura.Crear(request);
            dbContext.Facturas.Add(factura);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(factura.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}