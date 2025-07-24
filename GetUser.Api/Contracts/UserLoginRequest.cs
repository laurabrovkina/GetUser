using System.Text.Json.Serialization;

namespace GetUser.Api.Contracts;

public class UserLoginRequest
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
}