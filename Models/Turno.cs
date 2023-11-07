using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeluqueriaAgendaServicio.web.Models;

public partial class Turno
{
    [Key]
    public int TurnoId { get; set; }

    public DateTime FechaTurno { get; set; }

    public TimeSpan HoraTurno { get; set; }
    [Display(Name = "Estado de Turno")]
    public int EstadoTurnoId { get; set; }
    
    public int? ClienteId { get; set; }
    [Display(Name ="Servicio")]
    public int? ServicioId { get; set; }

    public string? Observacion { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual EstadosTurno EstadoTurno { get; set; } = null!;

    public virtual Servicio? Servicio { get; set; }
}
