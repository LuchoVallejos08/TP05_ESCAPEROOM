using Newtonsoft.Json;
namespace TP05_EscapeRoomSpiderman;

public static class Ranking
{
    [JsonProperty]
    public static List<Jugador> Leaderboard = new List<Jugador>();

    public static void agregarJugador(Jugador NuevoJugador){
        Leaderboard.Add(NuevoJugador);
        Leaderboard = Leaderboard.OrderBy(p => p.tiempo).ToList();
    }




}