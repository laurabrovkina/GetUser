using GetUser.Api.Models;

namespace GetUser.Api.UserHttpClient;

public interface IUserClient
{
    Task<User?> GetCurrentAuthUserAsync();
}