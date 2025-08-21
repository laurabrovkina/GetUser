using System.Text;
using System.Text.Json;
using GetUser.Api.Contracts;
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
    
    public async Task<User?> GetUserAsync(int userId)
    {
        var user = await _httpClient.GetFromJsonAsync<User>($"user/{userId}");
        return user;
    }

    public async Task<UsersResponse?> GetUsersAsync(GetUsersOptions? options = null)
    {
        var url = options is not null 
            ? $"/users/search?limit={options.PageSize}&skip={options.Page}&q={options.Name}"
            : "/users";
        var users = await _httpClient.GetFromJsonAsync<UsersResponse>(url);
        return users;
    }

    public async Task<User?> AddUserAsync(User request)
    {
        const string url = "/users/add";
        var httpContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = httpContent
        };
        
        var response = await _httpClient.SendAsync(httpRequestMessage);
        response.EnsureSuccessStatusCode();
        
        var user = await response.Content.ReadFromJsonAsync<User>();
        return user;
    }
}