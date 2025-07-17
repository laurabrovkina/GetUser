using System.Text;
using System.Text.Json;
using GetUser.Api.Models;
using GetUser.Api.Options;
using GetUser.Api.Utilities;
using Microsoft.Extensions.Options;

namespace GetUser.Api.AuthClient;

public class AuthApiClient : IAuthApiClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly JwtOptions _tokenOptions;

    public AuthApiClient(
        IHttpClientFactory httpClientFactory,
        IOptions<JwtOptions> tokenOptions)
    {
        _httpClientFactory = httpClientFactory;
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
        
        var client = _httpClientFactory.CreateClient("AuthClient");
        var httpContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "auth/login")
        {
            Content = httpContent
        };
        
        var response = await client.SendAsync(httpRequestMessage);
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

        services.AddHttpClient<IAuthApiClient, AuthApiClient>((sp, config) =>
        {
            var options = sp.GetRequiredService<IOptions<JwtOptions>>().Value;
            config.BaseAddress = new Uri(options.Url);
            config.Timeout = TimeSpan.FromSeconds(5);
        });
    }
}