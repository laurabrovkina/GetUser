using GetUser.Api.Contracts;
using GetUser.Api.Models;

namespace GetUser.Api.Services;

public interface IUserService
{
    Task<UserDto> GetCurrentUserAsync();
    Task<UserDto> GetUserAsync(int userId);
    Task<IEnumerable<UserDto>?> GetAllAsync(GetUsersOptions? options = null);
    Task<UserDto> CreateUserAsync(CreateUserRequest request);
}