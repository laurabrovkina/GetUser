namespace GetUser.Tests;

public class TokenOptions
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int ExpiresInMins { get; set; } = 15;
}