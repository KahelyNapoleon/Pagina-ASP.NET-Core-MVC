using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeluqueriaAgendaServicio.web.Data;
using PeluqueriaAgendaServicio.web.Models;

namespace PeluqueriaAgendaServicio.web.Controllers
{
    public class TurnosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TurnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            int clienteid = 8;
            //Consulta Los datos de un cliente con sus relacion de de localidad y provincia
            var cliente = _context.Clientes.
                Include(c => c.Localidad).
                Include(c => c.Provincia).
                FirstOrDefault(m => m.ClienteId == clienteid); //Devuelve el primer elemento de una secuencia
            //o un valor predeterminado si la secuencia no contiene elementos.

            //Para poder enviar Datos del controlador a la vista(hay muchas maneras de hacerlo)
            //Se utilizara un Diccionario ViewData o ViewBag

            //Que es ViewData? Son objetos de tipo diccionario que sirven para pasar datos del controlador
            //a la vista y de la vista al controlador

            //ViewData =>pasara datos del controlador a la vista

            ViewData["SelectListTiposServicios"] = new SelectList(_context.TiposServicios, "TipoServicioId", "Descripcion");
            ViewData["SelectListServicios"] = new SelectList(_context.Servicios, "ServicioId", "Descripcion");

            var reservaTurno = new ReservaTurno();
            reservaTurno.Cliente = cliente;
            reservaTurno.Turno = new Turno();

            return View(reservaTurno);
        }

        public async Task<IActionResult> ObtenerServiciosPorTipoServicio(int tipoServicioId)
        {
            //Obtener los servicios que perteneneces a los tipos de servicios especificos 
            var servicios = await _context.Servicios
                .Where(s => s.TipoServicioId == tipoServicioId)
                .Select(s => new { s.TipoServicioId, s.Descripcion })
                .ToListAsync();

            return Json(servicios);
        }
    }
}
