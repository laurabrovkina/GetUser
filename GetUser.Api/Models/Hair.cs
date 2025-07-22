using System.Text.Json.Serialization;

namespace GetUser.Api.Models;

public class Hair
{
    [JsonPropertyName("color")]
    public string Color { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}