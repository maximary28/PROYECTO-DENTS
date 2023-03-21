using Proyecto_LP4.Shared.Wrapper;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Routes;
using Proyecto_LP4.Client.Extensions;
using Proyecto_LP4.Shared.Request;
using System.Net.Http.Json;

namespace Proyecto_LP4.Client.Managers;

public interface IPacienteManager
{
    Task<ResultList<PacienteRecord>> GetAsync();
    Task<Result<int>> CreateAsync(PacienteCreateRequest request);
    Task<Result<PacienteRecord>> GetByIdAsync(int Id);
}

public class PacienteManager : IPacienteManager
{
    private readonly HttpClient httpClient;

    public PacienteManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<PacienteRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(PacienteRouteManager.BASE);
            var resultado = await response.ToResultList<PacienteRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<PacienteRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(PacienteCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(PacienteRouteManager.BASE,request);
        return await response.ToResult<int>();
    }

    public async Task<Result<PacienteRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(PacienteRouteManager.BuildRoute(Id));
        return await response.ToResult<PacienteRecord>();
    }
}