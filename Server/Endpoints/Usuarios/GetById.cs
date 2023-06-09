using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_LP4.Server.Context;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Routes;
using Proyecto_LP4.Shared.Wrapper;

namespace Proyecto_LP4.Server.Endpoints.Usuarios;
using Respuesta = Result<UsuarioRecord>;
using Request = UsuarioRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(UsuarioRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var usuario = await dbContext.Usuarios
            .Where(u => u.Id == request.Id)
            .Select(usuario => usuario.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(usuario == null)
            return Respuesta.Fail($"No fue posible encontrar el usuario '{request.Id}'");

            return Respuesta.Sucess(usuario);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}