using GetUser.Api.Models;

namespace GetUser.Api.UserHttpClient;

public class UserClient : IUserClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public UserClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<User?> GetCurrentAuthUserAsync()
    {
        var client = _httpClientFactory.CreateClient("UserClient");
        var user = await client.GetFromJsonAsync<User>("user/me");
        return user;
    }
}