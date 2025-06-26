using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP05_EscapeRoomSpiderman.Models;

namespace TP05_EscapeRoomSpiderman.Controllers;

public class HomeController : Controller
{
    private static List<Jugador> ranking = new List<Jugador>();
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Jugar(string nombre)
    {
        DateTime ahora = DateTime.Now;
        double segundos = ahora.Hour * 3600 + ahora.Minute * 60 + ahora.Second + ahora.Millisecond / 1000.0;

        Jugador jugador = new Jugador(nombre, segundos);
        HttpContext.Session.SetString("Jugador", Objeto.ObjectToString(jugador)); 

        SalaEscape Sala = new SalaEscape();
        HttpContext.Session.SetString("Escape", Objeto.ObjectToString(Sala)); 
        ViewBag.salaActual = Sala.numeroSala;
        return View("Sala1");
    }



    [HttpPost]
    public IActionResult ResolverSala(string codigo){
        SalaEscape Sala = Objeto.StringToObject<SalaEscape>(HttpContext.Session.GetString("Escape"));
        bool ok= Sala.compararRespuesta(codigo);
        if(ok==false){
            ViewBag.MensajeError="INCORRECTO, REINTENTELO";
        }
        else if (Sala.numeroSala == 4)
        {
        return RedirectToAction("Rankear");
        }
        HttpContext.Session.SetString("Escape", Objeto.ObjectToString(Sala)); 
        ViewBag.salaActual = Sala.numeroSala;
        return View("Sala"+ Sala.numeroSala);
    }
    
    public IActionResult Rankear(){
        Jugador jugador = Objeto.StringToObject<Jugador>(HttpContext.Session.GetString("Jugador"));
        DateTime ahora = DateTime.Now;
        double segundos = ahora.Hour * 3600 + ahora.Minute * 60 + ahora.Second + ahora.Millisecond / 1000.0;

        jugador.tiempo = (segundos - jugador.tiempo);

        Ranking.agregarJugador(jugador);
        
        return View("Resultado");


    }
    
}
