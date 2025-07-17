using System.Text.Json;

namespace GetUser.Api.Utilities;

public static class Extensions
{
    public static T Deserialize<T>(this string jsonString)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        var deserialized = JsonSerializer.Deserialize<T>(jsonString, options);
        return deserialized is null
            ? throw new JsonException($"Expected non-null json deserialization result of {nameof(jsonString)}: {jsonString}")
            : deserialized;
    }
}