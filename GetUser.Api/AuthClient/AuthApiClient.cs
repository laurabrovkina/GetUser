using System.Text;
using System.Text.Json;
using GetUser.Api.Models;
using GetUser.Api.Options;
using GetUser.Api.Utilities;
using Microsoft.Extensions.Options;

namespace GetUser.Api.AuthClient;

public class AuthApiClient : IAuthApiClient
{
    private readonly HttpClient _httpClient;
    private readonly JwtOptions _tokenOptions;

    public AuthApiClient(IOptions<JwtOptions> tokenOptions, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _tokenOptions = tokenOptions.Value;
    }

    public async Task<AccessTokenResponse> GetAccessToken(UserLoginRequest userLoginRequest)
    {
        var body = new
        {
            username = userLoginRequest.Username,
            password = userLoginRequest.Password,
            expiresInMins = _tokenOptions.ExpiresInMins
        };
        
        var httpContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "auth/login")
        {
            Content = httpContent
        };
        
        var response = await _httpClient.SendAsync(httpRequestMessage);
        response.EnsureSuccessStatusCode();
        var responseJsonString = await response.Content.ReadAsStringAsync();
        
        return responseJsonString.Deserialize<AccessTokenResponse>();
    }
}

public static class AuthApiClientExtensions
{
    public static void AddAuthClient(this IServiceCollection services, Action<JwtOptions>? configureOptions = null)
    {
        services.AddOptions<JwtOptions>()
            .BindConfiguration(nameof(JwtOptions))
            .ValidateOnStart();

        if (configureOptions is not null)
        {
            services.Configure(configureOptions);
        }

        services.AddHttpClient<IAuthApiClient, AuthApiClient>("AuthClient", (sp, config) =>
        {
            var options = sp.GetRequiredService<IOptions<JwtOptions>>().Value;
            config.BaseAddress = new Uri(options.Url);
            config.Timeout = TimeSpan.FromSeconds(5);
        });
    }
}