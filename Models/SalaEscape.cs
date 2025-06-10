using Newtonsoft.Json;
namespace TP05_EscapeRoomSpiderman;

public class SalaEscape
{
    [JsonProperty]
    public int numeroSala{get; private set;}

    [JsonProperty]
    private string [] respuesta = new string [6];
    public SalaEscape(){
    numeroSala = 1;
    respuesta[0]="80";
    respuesta[1]="O";
    respuesta[2]="O";
    respuesta[3]="O";
    respuesta[4]="O";
    respuesta[5]="O";
}
public void compararRespuesta(string ingreso)
{
    if (ingreso == respuesta[numeroSala-1]){
        numeroSala++;
    }
}

}

