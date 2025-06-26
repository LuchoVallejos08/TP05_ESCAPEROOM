using Newtonsoft.Json;
namespace TP05_EscapeRoomSpiderman
{
    public class Jugador
    {
        [JsonProperty]
        public string nombre { get; set; }
        
        [JsonProperty]
        public double tiempo { get; set; }

        public Jugador (string Nom, double time)
        {
            nombre = Nom;
            tiempo = time;
        }

    }
}