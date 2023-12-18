using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PeluqueriaAgendaServicio.web.Models;

public partial class Turno
{
    [Key]
    public int TurnoId { get; set; }
    [Display(Name= "Fecha de Turno")]
    public DateTime FechaTurno { get; set; }
    [Display(Name ="Hora de Turno")]
    public TimeSpan HoraTurno { get; set; }
    [Display(Name = "Estado de Turno")]
    public int EstadoTurnoId { get; set; }
    [Display(Name ="Cliente")]
    public int? ClienteId { get; set; }
    [Display(Name ="Servicio")]
    public int? ServicioId { get; set; }

    public string? Observacion { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual EstadosTurno EstadoTurno { get; set; } = null!;
    public virtual TiposServicio TipoServicio { get; set;  } = null!;
    public virtual Servicio Servicio { get; set; } = null!;
}
