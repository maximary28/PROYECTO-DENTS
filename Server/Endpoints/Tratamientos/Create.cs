using Proyecto_LP4.Shared.Wrapper;
using Proyecto_LP4.Shared.Request;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Proyecto_LP4.Server.Context;
using Proyecto_LP4.Server.Models;
using Microsoft.EntityFrameworkCore;
using Proyecto_LP4.Shared.Routes;

namespace Restaurante.Server.Endpoints.Tratamientos;

using Request = TratamientoCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(TratamientoRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var tratamiento = await dbContext.Tratamientos.FirstOrDefaultAsync(r => r.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
            if(tratamiento != null)
                return Respuesta.Fail($"Ya existe un tratamiento con el nombre '({request.Nombre})'.");
            #endregion
            tratamiento = Tratamiento.Crear(request);
            dbContext.Tratamientos.Add(tratamiento);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(tratamiento.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}