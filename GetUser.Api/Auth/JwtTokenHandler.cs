using System.Net.Http.Headers;
using GetUser.Api.AuthClient;
using GetUser.Api.Models;
using GetUser.Api.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace GetUser.Api.Auth;

public class JwtTokenHandler : DelegatingHandler
{
    private readonly IAuthApiClient  _authApiClient;
    private readonly UserOptions _userOptions;

    public JwtTokenHandler(IAuthApiClient authApiClient, IOptions<UserOptions> userOptions)
    {
        _authApiClient = authApiClient;
        _userOptions = userOptions.Value;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _authApiClient.GetAccessToken(new UserLoginRequest
        {
            Username = _userOptions.Username,
            Password = _userOptions.Password
        });
        request.Headers.Authorization =
            new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, token.AccessToken);
        return await base.SendAsync(request, cancellationToken);
    }
}