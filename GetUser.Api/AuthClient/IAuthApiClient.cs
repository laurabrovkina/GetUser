using GetUser.Api.Models;

namespace GetUser.Api.AuthClient;

public interface IAuthApiClient
{
    Task<AccessTokenResponse> GetAccessToken(UserLoginRequest userLoginRequest);
}