using System.Text.Json;

public static class Helper
{
    public static string GetJsonString(object obj)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        return JsonSerializer.Serialize(obj, options);
    }
}
