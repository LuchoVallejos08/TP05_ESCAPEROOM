using Newtonsoft.Json;
namespace TP05_EscapeRoomSpiderman;

public class SalaEscape
{
    [JsonProperty]
    public int numeroSala{get; private set;}

    [JsonProperty]
    string [] respuesta = new string [6];
    public SalaEscape(){
    numeroSala = 1;
}
public void compararRespuesta(string ingreso)
{
    if (ingreso == respuesta[numeroSala]){
        numeroSala++;
    }
}
}

