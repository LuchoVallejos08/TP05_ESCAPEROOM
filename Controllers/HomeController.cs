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
    public IActionResult JugarConNombre(string nombre)
    {
        TempData["NombreJugador"] = nombre;
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
        return RedirectToAction("ResultadoFinal");
        }
        HttpContext.Session.SetString("Escape", Objeto.ObjectToString(Sala)); 
        ViewBag.salaActual = Sala.numeroSala;
        return View("Sala"+ Sala.numeroSala);
    }
    
public IActionResult ResultadoFinal()
{
        var tiempoStr = HttpContext.Request.Query["tiempo"].ToString();
    System.Diagnostics.Debug.WriteLine($"Valor recibido en query 'tiempo': '{tiempoStr}'");


    string nombre = TempData["NombreJugador"]?.ToString() ?? "Anónimo";
    int tiempo = 0;

    // Intentar obtener el tiempo de la query string
    if (!int.TryParse(HttpContext.Request.Query["tiempo"], out tiempo))
    {
        tiempo = 0; // valor por defecto si no viene o no es válido
    }

    // Crear jugador y agregar al ranking
    Jugador jugador = new Jugador { Nombre = nombre, TiempoSegundos = tiempo };
    ranking.Add(jugador);

    // Ordenar ranking por tiempo ascendente
    var rankingOrdenado = ranking.OrderBy(j => j.TiempoSegundos).ToList();

    // Encontrar el puesto del jugador actual
    int puesto = rankingOrdenado.FindIndex(j => j.Nombre == nombre && j.TiempoSegundos == tiempo) + 1;

    // Formatear tiempo en mm:ss para mostrar
    string tiempoFormateado = $"{tiempo / 60:D2}:{tiempo % 60:D2}";

    // Pasar datos a la vista
    ViewBag.Nombre = nombre;
    ViewBag.Tiempo = tiempoFormateado;
    ViewBag.Puesto = puesto;
    ViewBag.Ranking = rankingOrdenado;

    return View("Resultado");
}

    
}
