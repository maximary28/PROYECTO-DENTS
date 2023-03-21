using Proyecto_LP4.Shared.Wrapper;
using Proyecto_LP4.Shared.Request;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Proyecto_LP4.Server.Context;
using Proyecto_LP4.Server.Models;
using Microsoft.EntityFrameworkCore;
using Proyecto_LP4.Shared.Routes;

namespace Restaurante.Server.Endpoints.Pacientes;

using Request = PacienteCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(PacienteRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var paciente = await dbContext.Pacientes.FirstOrDefaultAsync(r => r.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
            if(paciente != null)
                return Respuesta.Fail($"Ya existe un paciente con el nombre '({request.Nombre})'.");
            #endregion
            paciente = Paciente.Crear(request);
            dbContext.Pacientes.Add(paciente);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(paciente.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}