
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace PeluqueriaAgendaServicio.web.Models
{
    public class ReservaTurno
    {
        [Display(Name ="Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Display(Name ="Fecha de turno")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaTurno { get; set; }

        [Display(Name = "Hora de turno")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public TimeSpan HoraTurno { get; set; }
        public Turno Turno { get; set; }

        [Display(Name ="Tipo de Servicio")]
        public int TipoServicioId {  get; set; }

        [Display(Name ="Servicio")]
        public int ServicioId { get; set; }

        [Display(Name ="Observacion")]
        [DataType(DataType.MultilineText)]
        public string? Observacion { get; set; }
    }
}
