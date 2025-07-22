using System.Text.Json.Serialization;

namespace GetUser.Api.Models;

public class Bank
{
    [JsonPropertyName("cardExpire")]
    public string CardExpire { get; set; }

    [JsonPropertyName("cardNumber")]
    public string CardNumber { get; set; }

    [JsonPropertyName("cardType")]
    public string CardType { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("iban")]
    public string Iban { get; set; }
}