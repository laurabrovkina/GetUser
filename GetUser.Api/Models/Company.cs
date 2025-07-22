using System.Text.Json.Serialization;

namespace GetUser.Api.Models;

public class Company
{
    [JsonPropertyName("department")]
    public string Department { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("address")]
    public Address Address { get; set; }
}