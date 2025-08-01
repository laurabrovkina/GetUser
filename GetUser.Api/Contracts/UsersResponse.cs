using GetUser.Api.Models;

namespace GetUser.Api.Contracts;

public class UsersResponse : PagedResponse
{
    public IEnumerable<User> Users { get; set; } = [];
}