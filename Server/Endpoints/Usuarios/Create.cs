using Proyecto_LP4.Shared.Wrapper;
using Proyecto_LP4.Shared.Request;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Proyecto_LP4.Server.Context;
using Proyecto_LP4.Server.Models;
using Microsoft.EntityFrameworkCore;
using Proyecto_LP4.Shared.Routes;

namespace Restaurante.Server.Endpoints.Usuarios;

using Request = UsuarioCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(UsuarioRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var usuario = await dbContext.Usuarios.FirstOrDefaultAsync(r => r.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
            if(usuario != null)
                return Respuesta.Fail($"Ya existe un usuario con el nombre '({request.Nombre})'.");
            #endregion
            usuario = Usuario.Crear(request);
            dbContext.Usuarios.Add(usuario);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(usuario.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}