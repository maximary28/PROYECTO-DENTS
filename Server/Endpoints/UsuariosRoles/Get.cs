using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_LP4.Server.Context;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Routes;
using Proyecto_LP4.Shared.Wrapper;

namespace Proyecto_LP4.Server.Endpoints.UsuariosRoles;


using Respuesta = ResultList<UsuarioRolRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Get(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(UsuarioRolRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var usuariosroles = await dbContext.UsuariosRoles.Select(usuariorol => usuariorol.ToRecord())
        .ToListAsync(cancellationToken);
            return Respuesta.Success(usuariosroles);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }
}