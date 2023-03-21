
using System.ComponentModel.DataAnnotations;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Request;

namespace Proyecto_LP4.Server.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    public int UsuarioRolId { get; set; }
    public virtual UsuarioRol UsuarioRol { get; set;} = null!;
    public string Nombre { get; set; } = null!;
    public string NombreUsuario { get; set; } = null!;
    public string Password { get; set; } = null!;

    public static Usuario Crear(UsuarioCreateRequest request)
    {
        return new Usuario(){
            UsuarioRolId = request.UsuarioRolId,
            Nombre = request.Nombre,
            NombreUsuario = request.NombreUsuario,
            Password = request.Password
        };
    }

    public void Modificar(UsuarioUpdateRequest request)
    {
        if(UsuarioRolId != request.UsuarioRolId)
            UsuarioRolId = request.UsuarioRolId;
        if(Nombre != request.Nombre)
            Nombre = request.Nombre;
        if(NombreUsuario != request.NombreUsuario)
            NombreUsuario = request.NombreUsuario;
        if(Password != request.Password)
            Password = request.Password;
    }

    public UsuarioRecord ToRecord()
    {
        return new UsuarioRecord(Id, UsuarioRolId, UsuarioRol.ToRecord(), Nombre, NombreUsuario, Password);
    }
}