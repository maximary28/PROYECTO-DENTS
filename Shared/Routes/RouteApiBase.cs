
namespace Proyecto_LP4.Shared.Routes;

public class RouteApiBase
{
    public const string API = "/api";
    public int Id { get; set; }
    public const string IdParameter = "{Id:int}";
}

public class CitaRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/citas";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}
public class FacturaRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/facturas";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}
public class PacienteRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/pacientes";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}
public class TratamientoRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/tratamientos";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}
public class UsuarioRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/usuarios";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}
public class UsuarioRolRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/usuariosroles";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}