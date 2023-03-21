﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_LP4.Server.Context;

#nullable disable

namespace ProyectoLP4.Server.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyecto_LP4.Server.Models.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProximaCita")
                        .HasColumnType("datetime2");

                    b.Property<int>("TratamientoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.HasIndex("TratamientoId");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("Proyecto_LP4.Server.Models.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Abonado")
                        .HasColumnType("real");

                    b.Property<float>("BalancePendiente")
                        .HasColumnType("real");

                    b.Property<int>("CitaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CitaId");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("Proyecto_LP4.Server.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Alergia")
                        .HasColumnType("bit");

                    b.Property<string>("AlergiaDescripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Anemia")
                        .HasColumnType("bit");

                    b.Property<bool>("Asma")
                        .HasColumnType("bit");

                    b.Property<bool>("Corazon")
                        .HasColumnType("bit");

                    b.Property<bool>("Diabetes")
                        .HasColumnType("bit");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DoloresDeCabeza")
                        .HasColumnType("bit");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<bool>("Embarazo")
                        .HasColumnType("bit");

                    b.Property<bool>("Epilepsia")
                        .HasColumnType("bit");

                    b.Property<bool>("Falcemia")
                        .HasColumnType("bit");

                    b.Property<bool>("FiebreReumatica")
                        .HasColumnType("bit");

                    b.Property<bool>("Fuma")
                        .HasColumnType("bit");

                    b.Property<bool>("Hemofilia")
                        .HasColumnType("bit");

                    b.Property<bool>("Medicamento")
                        .HasColumnType("bit");

                    b.Property<string>("MedicamentoDescripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreTutor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ocupacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PresionAlta")
                        .HasColumnType("bit");

                    b.Property<bool>("PresionBaja")
                        .HasColumnType("bit");

                    b.Property<bool>("Riñones")
                        .HasColumnType("bit");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Proyecto_LP4.Server.Models.Tratamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Tratamientos");
                });

            modelBuilder.Entity("Proyecto_LP4.Server.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioRolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioRolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Proyecto_LP4.Server.Models.UsuarioRol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PermisoParaCrear")
                        .HasColumnType("bit");

                    b.Property<bool>("PermisoParaEditar")
                        .HasColumnType("bit");

                    b.Property<bool>("PermisoParaEliminar")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("UsuariosRoles");
                });

            modelBuilder.Entity("Proyecto_LP4.Server.Models.Cita", b =>
                {
                    b.HasOne("Proyecto_LP4.Server.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_LP4.Server.Models.Tratamiento", "Tratamiento")
                        .WithMany()
                        .HasForeignKey("TratamientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");

                    b.Navigation("Tratamiento");
                });

            modelBuilder.Entity("Proyecto_LP4.Server.Models.Factura", b =>
                {
                    b.HasOne("Proyecto_LP4.Server.Models.Cita", "Cita")
                        .WithMany()
                        .HasForeignKey("CitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cita");
                });

            modelBuilder.Entity("Proyecto_LP4.Server.Models.Usuario", b =>
                {
                    b.HasOne("Proyecto_LP4.Server.Models.UsuarioRol", "UsuarioRol")
                        .WithMany()
                        .HasForeignKey("UsuarioRolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioRol");
                });
#pragma warning restore 612, 618
        }
    }
}