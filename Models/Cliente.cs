using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeluqueriaAgendaServicio.web.Models;

public partial class Cliente
{
    [Key]
    public int ClienteId { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    public string Apellido { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    public string Nombre { get; set; } = null!;
    [Display(Name ="Fecha de Nacimiento")]
    public DateTime? FechaNacimiento { get; set; }
    [Display(Name = "Tipo de Documento")]
    [Required(ErrorMessage = "Campo obligatorio")]
    public string TipoDocumento { get; set; } = null!;
    [Display(Name = "Numero de Documento")]
    [Required(ErrorMessage = "Campo obligatorio")]
    public int NumeroDocumento { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    public string Calle { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    public int Altura { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    public string Barrio { get; set; } = null!;
    public string? Partido { get; set; }
    [Display(Name = "Provincia")]
    public int ProvinciaId { get; set; }
    [Display(Name = "Localidad")]
    public int LocalidadId { get; set; }
    [Display(Name = "Codigo Postal")]
    [Required(ErrorMessage = "Campo obligatorio")]
    public int CodigoPostal { get; set; }
    [Display(Name = "CUIL/CUIT")]
    public string? CuitCuil { get; set; }
    [Display(Name = "Razon Social")]
    public string? RazonSocial { get; set; }
    [Display(Name = "Correo Electronico")]
    [Required(ErrorMessage = "Campo obligatorio")]
    public string CorreoElectronico { get; set; } = null!;
    [Required(ErrorMessage ="Campo obligatorio")]
    public string Celular { get; set; } = null!;

    public string? Telefono { get; set; }

    public virtual Localidad? Localidad { get; set; } = null!;

    public virtual Provincia? Provincia { get; set; } = null!;

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
