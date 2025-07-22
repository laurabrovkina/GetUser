using System.Text.Json.Serialization;

namespace GetUser.Api.Models;

public class Coordinates
{
    [JsonPropertyName("lat")]
    public double Lat { get; set; }

    [JsonPropertyName("lng")]
    public double Lng { get; set; }
}