using Proyecto_LP4.Shared.Wrapper;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Routes;
using Proyecto_LP4.Client.Extensions;
using Proyecto_LP4.Shared.Request;
using System.Net.Http.Json;

namespace Proyecto_LP4.Client.Managers;

public interface ICitaManager
{
    Task<ResultList<CitaRecord>> GetAsync();
    Task<Result<int>> CreateAsync(CitaCreateRequest request);
    Task<Result<CitaRecord>> GetByIdAsync(int Id);
}

public class CitaManager : ICitaManager
{
    private readonly HttpClient httpClient;

    public CitaManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<CitaRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(CitaRouteManager.BASE);
            var resultado = await response.ToResultList<CitaRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<CitaRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(CitaCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(CitaRouteManager.BASE,request);
        return await response.ToResult<int>();
    }

    public async Task<Result<CitaRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(CitaRouteManager.BuildRoute(Id));
        return await response.ToResult<CitaRecord>();
    }
}