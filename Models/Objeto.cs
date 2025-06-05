using Newtonsoft.Json;
namespace TP05_EscapeRoomSpiderman.Models;
public static class Objeto
{
    public static string ObjectToString<T> (T? obj){
        return JsonConvert.SerializeObject(obj);
    }

    public static T? StringToObject<T>(string txt){
        if (string.IsNullOrEmpty(txt)) return default;
        else return JsonConvert.DeserializeObject<T>(txt);
    }
}