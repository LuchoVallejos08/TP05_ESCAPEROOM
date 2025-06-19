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

    [HttpPost]
    public IActionResult ResolverSala(string codigo){
        SalaEscape Sala = Objeto.StringToObject<SalaEscape>(HttpContext.Session.GetString("Escape"));
        bool ok= Sala.compararRespuesta(codigo);
        if(ok==false){
            ViewBag.MensajeError="INCORRECTO, REINTENTELO";
        }
        HttpContext.Session.SetString("Escape", Objeto.ObjectToString(Sala)); 
        return View("Sala"+ Sala.numeroSala);
    }
    
    
        [HttpPost]
        public IActionResult Pregunta5  (string respuesta) {
            ViewBag.Respuesta = respuesta;
            return View("b");

        }
[HttpPost]
        public IActionResult Pregunta6  (string Code) {
            ViewBag.CodigoS = Code;
            return View("Venom");

        }

    
}
