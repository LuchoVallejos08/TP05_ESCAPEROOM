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
    respuesta[1]="octavious";
    respuesta[2]="2";
    respuesta[3]="electro";
    respuesta[4]="b";
    respuesta[5]="venom";
}
public bool compararRespuesta(string ingreso)
{
    bool aux = false;
    if(ingreso != null){
    ingreso=ingreso.ToLower();
    if (ingreso == respuesta[numeroSala-1]){
        numeroSala++;
    aux = true;
    }
    }

    return aux;
}
}

