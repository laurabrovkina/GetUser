using System.Text.Json.Serialization;

namespace GetUser.Api.AuthClient;

public class AccessTokenResponse
{
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; }
    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; set; }
}