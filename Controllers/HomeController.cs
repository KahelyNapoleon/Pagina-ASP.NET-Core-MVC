using Microsoft.AspNetCore.Mvc; // De aqui pproviene la Clase Controller
using PeluqueriaAgendaServicio.web.Models;
using System.Diagnostics;

namespace PeluqueriaAgendaServicio.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View(); //Lleva al archivo Home >> Privacy.htmlcss
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}