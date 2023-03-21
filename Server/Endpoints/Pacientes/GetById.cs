using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_LP4.Server.Context;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Routes;
using Proyecto_LP4.Shared.Wrapper;

namespace Proyecto_LP4.Server.Endpoints.Pacientes;
using Respuesta = Result<PacienteRecord>;
using Request = PacienteRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(PacienteRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var paciente = await dbContext.Pacientes
            .Where(p => p.Id == request.Id)
            .Select(paciente => paciente.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(paciente == null)
            return Respuesta.Fail($"No fue posible encontrar el paciente '{request.Id}'");

            return Respuesta.Sucess(paciente);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}