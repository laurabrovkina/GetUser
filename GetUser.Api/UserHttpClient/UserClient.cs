using GetUser.Api.Models;

namespace GetUser.Api.UserHttpClient;

public class UserClient : IUserClient
{
    private readonly HttpClient _httpClient;

    public UserClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<User?> GetCurrentAuthUserAsync()
    {
        var user = await _httpClient.GetFromJsonAsync<User>("user/me");
        return user;
    }

    public async Task<UsersResponse?> GetUsersAsync(GetUsersOptions options)
    {
        var url = $"/users/search?limit={options.PageSize}&skip={options.Page}&q={options.Name}";
        var users = await _httpClient.GetFromJsonAsync<UsersResponse>(url);
        return users;
    }
}