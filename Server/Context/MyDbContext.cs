using Microsoft.EntityFrameworkCore;
using Proyecto_LP4.Server.Models;

namespace Proyecto_LP4.Server.Context;

public interface IMyDbContext
{
    DbSet<Cita> Citas { get; set; }
    DbSet<Factura> Facturas { get; set; }
    DbSet<Paciente> Pacientes { get; set; }
    DbSet<Tratamiento> Tratamientos { get; set; }
    DbSet<Usuario> Usuarios { get; set; }
    DbSet<UsuarioRol> UsuariosRoles { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class MyDbContext : DbContext, IMyDbContext
{
    private readonly IConfiguration config;

    public MyDbContext(IConfiguration _config)
    {
        config = _config;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(config.GetConnectionString("ProyectoLP4"));
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    #region Tablas de mi base de datos
    public DbSet<Cita> Citas { get; set; } = null!;
    public DbSet<Factura> Facturas { get; set; } = null!;
    public DbSet<Paciente> Pacientes { get; set; } = null!;
    public DbSet<Tratamiento> Tratamientos { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<UsuarioRol> UsuariosRoles { get; set; } = null!;
    #endregion
}