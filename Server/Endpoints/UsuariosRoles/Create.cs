using Proyecto_LP4.Shared.Wrapper;
using Proyecto_LP4.Shared.Request;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Proyecto_LP4.Server.Context;
using Proyecto_LP4.Server.Models;
using Microsoft.EntityFrameworkCore;
using Proyecto_LP4.Shared.Routes;

namespace Restaurante.Server.Endpoints.UsuarioRoles;

using Request = UsuarioRolCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(UsuarioRolRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var rol = await dbContext.UsuariosRoles.FirstOrDefaultAsync(r => r.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
            if(rol != null)
                return Respuesta.Fail($"Ya existe un rol con el nombre '({request.Nombre})'.");
            #endregion
            rol = UsuarioRol.Crear(request);
            dbContext.UsuariosRoles.Add(rol);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(rol.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}