namespace GetUser.Api.Models;

public class UsersResponse
{
    public IEnumerable<User> Users { get; set; } = new List<User>();
}