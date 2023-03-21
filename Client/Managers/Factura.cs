using Proyecto_LP4.Shared.Wrapper;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Routes;
using Proyecto_LP4.Client.Extensions;
using Proyecto_LP4.Shared.Request;
using System.Net.Http.Json;

namespace Proyecto_LP4.Client.Managers;

public interface IFacturaManager
{
    Task<ResultList<FacturaRecord>> GetAsync();
    Task<Result<int>> CreateAsync(FacturaCreateRequest request);
    Task<Result<FacturaRecord>> GetByIdAsync(int Id);
}

public class FacturaManager : IFacturaManager
{
    private readonly HttpClient httpClient;

    public FacturaManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<FacturaRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(FacturaRouteManager.BASE);
            var resultado = await response.ToResultList<FacturaRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<FacturaRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(FacturaCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(FacturaRouteManager.BASE,request);
        return await response.ToResult<int>();
    }

    public async Task<Result<FacturaRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(FacturaRouteManager.BuildRoute(Id));
        return await response.ToResult<FacturaRecord>();
    }
}