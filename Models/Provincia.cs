using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeluqueriaAgendaServicio.web.Models;

public partial class Provincia
{
    [Key]
    public int ProvinciaId { get; set; }
    [Required(ErrorMessage ="La descripcion es obligatoria")]
    [StringLength(30, ErrorMessage ="La descripcion no debe exceder los 30 caracteres")]
    [Display(Name = "Descripción")]
    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Localidad> Localidades { get; set; } = new List<Localidad>();
}
