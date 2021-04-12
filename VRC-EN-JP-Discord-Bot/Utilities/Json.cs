using System.IO;
using Newtonsoft.Json;

public static class Json
{
    public static void Serialize(string filepath, object value, bool formatted = true)
    {
        Formatting formatting = formatted ? Formatting.Indented : Formatting.None;
        string json = JsonConvert.SerializeObject(value, formatting);
        File.WriteAllText(filepath, json);
    }

    public static T Deserialize<T>(string filepath)
    {
        string text = File.ReadAllText(filepath);
        return JsonConvert.DeserializeObject<T>(text);
    }
}