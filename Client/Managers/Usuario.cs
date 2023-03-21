using Proyecto_LP4.Shared.Wrapper;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Routes;
using Proyecto_LP4.Client.Extensions;
using Proyecto_LP4.Shared.Request;
using System.Net.Http.Json;

namespace Proyecto_LP4.Client.Managers;

public interface IUsuarioManager
{
    Task<ResultList<UsuarioRecord>> GetAsync();
    Task<Result<int>> CreateAsync(UsuarioCreateRequest request);
    Task<Result<UsuarioRecord>> GetByIdAsync(int Id);
}

public class UsuarioManager : IUsuarioManager
{
    private readonly HttpClient httpClient;

    public UsuarioManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<UsuarioRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(UsuarioRouteManager.BASE);
            var resultado = await response.ToResultList<UsuarioRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<UsuarioRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(UsuarioCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(UsuarioRouteManager.BASE,request);
        return await response.ToResult<int>();
    }

    public async Task<Result<UsuarioRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(UsuarioRouteManager.BuildRoute(Id));
        return await response.ToResult<UsuarioRecord>();
    }
}