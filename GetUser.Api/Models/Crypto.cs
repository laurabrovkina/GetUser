using System.Text.Json.Serialization;

namespace GetUser.Api.Models;

public class Crypto
{
    [JsonPropertyName("coin")]
    public string Coin { get; set; }

    [JsonPropertyName("wallet")]
    public string Wallet { get; set; }

    [JsonPropertyName("network")]
    public string Network { get; set; }
}