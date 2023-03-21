using System.ComponentModel.DataAnnotations;
using Proyecto_LP4.Shared.Records;
using Proyecto_LP4.Shared.Request;

namespace Proyecto_LP4.Server.Models;

public class Paciente
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string NombreTutor { get; set; } = null!;
    public string Ocupacion { get; set; } = null!;
    public string Sexo { get; set; } = null!;
    public int Edad { get; set; }
    public string Telefono { get; set; } = null!;
    public bool Fuma { get; set; }
    public bool PresionAlta { get; set; }
    public bool PresionBaja { get; set; }
    public bool Corazon { get; set; }
    public bool Diabetes { get; set; }
    public bool Riñones { get; set; }
    public bool FiebreReumatica { get; set; }
    public bool Epilepsia { get; set; }
    public bool Asma { get; set; }
    public bool DoloresDeCabeza { get; set; }
    public bool Falcemia { get; set; }
    public bool Anemia { get; set; }
    public bool Hemofilia { get; set; }
    public bool Medicamento { get; set; }
    public string MedicamentoDescripcion { get; set; } = null!;
    public bool Embarazo { get; set; }
    public bool Alergia { get; set; }
    public string AlergiaDescripcion { get; set; } = null!;

    public static Paciente Crear(PacienteCreateRequest request)
    {
        return new Paciente(){
            Nombre = request.Nombre,
            Direccion = request.Direccion,
            NombreTutor = request.NombreTutor,
            Ocupacion = request.Ocupacion,
            Sexo = request.Sexo,
            Edad = request.Edad,
            Telefono = request.Telefono,
            Fuma = request.Fuma,
            PresionAlta = request.PresionAlta,
            PresionBaja = request.PresionBaja,
            Corazon = request.Corazon,
            Diabetes = request.Diabetes,
            Riñones = request.Riñones,
            FiebreReumatica = request.FiebreReumatica,
            Epilepsia = request.Epilepsia,
            Asma = request.Asma,
            DoloresDeCabeza = request.DoloresDeCabeza,
            Falcemia = request.Falcemia,
            Anemia = request.Anemia,
            Hemofilia = request.Hemofilia,
            Medicamento = request.Medicamento,
            MedicamentoDescripcion = request.MedicamentoDescripcion,
            Embarazo = request.Embarazo,
            Alergia = request.Alergia,
            AlergiaDescripcion = request.AlergiaDescripcion
        };
    }

    public void Modificar(PacienteUpdateRequest request)
    {
        if(Nombre != request.Nombre)
            Nombre = request.Nombre;
        if(Direccion != request.Direccion)
            Direccion = request.Direccion;
        if(NombreTutor != request.NombreTutor)
            NombreTutor = request.NombreTutor;
        if(Ocupacion != request.Ocupacion)
            Ocupacion = request.Ocupacion;
        if(Sexo != request.Sexo)
            Sexo = request.Sexo;
        if(Edad != request.Edad)
            Edad = request.Edad;
        if(Telefono != request.Telefono)
            Telefono = request.Telefono;
        if(Fuma != request.Fuma)
            Fuma = request.Fuma;
        if(PresionAlta != request.PresionAlta)
            PresionAlta = request.PresionAlta;
        if(PresionBaja != request.PresionBaja)
            PresionBaja = request.PresionBaja;
        if(Corazon != request.Corazon)
            Corazon = request.Corazon;
        if(Diabetes = request.Diabetes)
            Diabetes = request.Diabetes;
        if(Riñones != request.Riñones)
            Riñones = request.Riñones;
        if(FiebreReumatica != request.FiebreReumatica)
            FiebreReumatica = request.FiebreReumatica;
        if(Epilepsia != request.Epilepsia)
            Epilepsia = request.Epilepsia;
        if(Asma != request.Asma)
            Asma = request.Asma;
        if(DoloresDeCabeza != request.DoloresDeCabeza)
            DoloresDeCabeza = request.DoloresDeCabeza;
        if(Falcemia != request.Falcemia)
            Falcemia = request.Falcemia;
        if(Anemia != request.Anemia)
            Anemia = request.Anemia;
        if(Hemofilia != request.Hemofilia)
            Hemofilia = request.Hemofilia;
        if(Medicamento != request.Medicamento)
            Medicamento = request.Medicamento;
        if(MedicamentoDescripcion != request.MedicamentoDescripcion)
            MedicamentoDescripcion = request.MedicamentoDescripcion;
        if(Embarazo != request.Embarazo)
            Embarazo = request.Embarazo;
        if(Alergia != request.Alergia)
            Alergia = request.Alergia;
        if(AlergiaDescripcion != request.AlergiaDescripcion)
            AlergiaDescripcion = request.AlergiaDescripcion;
    }

    public PacienteRecord ToRecord()
    {
        return new PacienteRecord(Id, Nombre, Direccion, NombreTutor, Ocupacion, Sexo, Edad, Telefono, Fuma, PresionAlta, PresionBaja, Corazon, Diabetes, Riñones, FiebreReumatica, Epilepsia, Asma, DoloresDeCabeza, Falcemia, Anemia, Hemofilia, Medicamento, MedicamentoDescripcion, Embarazo, Alergia, AlergiaDescripcion);
    }
}