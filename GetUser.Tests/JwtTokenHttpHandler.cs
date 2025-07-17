using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace GetUser.Tests;

public class JwtTokenHttpHandler : DelegatingHandler
{
    private readonly TokenOptions _tokenOptions;
    private readonly IHttpClientFactory _httpClientFactory;

    public JwtTokenHttpHandler(
        IOptions<TokenOptions> tokenOptions,
        IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _tokenOptions = tokenOptions.Value;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await GetAuthToken();
        request.Headers.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, token);
        return await base.SendAsync(request, cancellationToken);
    }

    private async Task<string?> GetAuthToken()
    {
        var body = new
        {
            username = _tokenOptions.Username,
            password = _tokenOptions.Password,
            expiresInMins = _tokenOptions.ExpiresInMins
        };
        
        var httpContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://dummyjson.com/auth/login")
        {
            Content = httpContent
        };
        
        var client = _httpClientFactory.CreateClient("AuthClient");

        var response = await client.SendAsync(httpRequestMessage);
        response.EnsureSuccessStatusCode();

        var responseJsonString = await response.Content.ReadAsStringAsync();
        using var jsonDocument = JsonDocument.Parse(responseJsonString);
        return jsonDocument.RootElement.GetProperty("access_token").GetString();
    }
}