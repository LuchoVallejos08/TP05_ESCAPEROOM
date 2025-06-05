using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP05_EscapeRoomSpiderman.Models;

namespace TP05_EscapeRoomSpiderman.Controllers;

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
    public IActionResult Jugar()
    {
        SalaEscape Sala = new SalaEscape();
        HttpContext.Session.SetString("Escape", Objeto.ObjectToString(Sala)); 
        return View("Sala1");
    }
    public IActionResult ResolverSala(string Clave){
        SalaEscape Sala = Objeto.StringToObject<SalaEscape>(HttpContext.Session.GetString("Escape"));
        Sala.compararRespuesta("hola");
        HttpContext.Session.SetString("Escape", Objeto.ObjectToString(Sala)); 
        return View("Sala"+ Sala.numeroSala);
    }
    
    
        [HttpPost]
        public IActionResult login  (string respuesta) {
            ViewBag.Respuesta = respuesta;
            return View("bienvenido");

        }


    
}
