namespace GetUser.Api.Models;

public class UserDto
{
    public long Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public Uri Image { get; set; }
}