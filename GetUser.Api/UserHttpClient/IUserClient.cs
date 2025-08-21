using GetUser.Api.Contracts;
using GetUser.Api.Models;

namespace GetUser.Api.UserHttpClient;

public interface IUserClient
{
    Task<User?> GetCurrentAuthUserAsync();
    Task<User?> GetUserAsync(int userId);
    Task<UsersResponse?> GetUsersAsync(GetUsersOptions? options = null);
    Task<User?> AddUserAsync(User request);
}