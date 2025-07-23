using GetUser.Api.Models;

namespace GetUser.Api.Services;

public interface IUserService
{
    Task<UserDto> GetUserAsync();
    Task<IEnumerable<UserDto>?> GetAllAsync(GetUsersOptions options);
}