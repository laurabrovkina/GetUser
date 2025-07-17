namespace GetUser.Api.Options;

public class JwtOptions
{
    public string Url { get; set; } = string.Empty;
    public int ExpiresInMins { get; set; } = 15;
}