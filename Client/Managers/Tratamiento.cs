using Proyecto_LP4.Shared.Wrapper;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Routes;
using Proyecto_LP4.Client.Extensions;
using Proyecto_LP4.Shared.Request;
using System.Net.Http.Json;

namespace Proyecto_LP4.Client.Managers;

public interface ITratamientoManager
{
    Task<ResultList<TratamientoRecord>> GetAsync();
    Task<Result<int>> CreateAsync(TratamientoCreateRequest request);
    Task<Result<TratamientoRecord>> GetByIdAsync(int Id);
}

public class TratamientoManager : ITratamientoManager
{
    private readonly HttpClient httpClient;

    public TratamientoManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<TratamientoRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(TratamientoRouteManager.BASE);
            var resultado = await response.ToResultList<TratamientoRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<TratamientoRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(TratamientoCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(TratamientoRouteManager.BASE,request);
        return await response.ToResult<int>();
    }

    public async Task<Result<TratamientoRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(TratamientoRouteManager.BuildRoute(Id));
        return await response.ToResult<TratamientoRecord>();
    }
}