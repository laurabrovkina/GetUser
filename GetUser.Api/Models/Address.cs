using System.Text.Json.Serialization;

namespace GetUser.Api.Models;

public class Address
{
    [JsonPropertyName("address")]
    public string AddressAddress { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("stateCode")]
    public string StateCode { get; set; }

    [JsonPropertyName("postalCode")]
    public int PostalCode { get; set; }

    [JsonPropertyName("coordinates")]
    public Coordinates Coordinates { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }
}