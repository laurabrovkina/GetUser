using GetUser.Api.Contracts;
using GetUser.Api.Models;

namespace GetUser.Api.UserHttpClient;

public interface IUserClient
{
    Task<User?> GetCurrentAuthUserAsync();
    Task<UsersResponse?> GetUsersAsync(GetUsersOptions options);
}