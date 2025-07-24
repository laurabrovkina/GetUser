using GetUser.Api.Models;

namespace GetUser.Api.Contracts;

public class UsersResponse
{
    public IEnumerable<User> Users { get; set; } = [];
}