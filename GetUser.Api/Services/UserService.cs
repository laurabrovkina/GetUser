using GetUser.Api.Contracts;
using GetUser.Api.Mappers;
using GetUser.Api.Models;
using GetUser.Api.UserHttpClient;

namespace GetUser.Api.Services;

public class UserService : IUserService
{
    private readonly IUserClient _userClient;
    private readonly MapperlyMapper _mapper;

    public UserService(IUserClient userClient)
    {
        _userClient = userClient;
        _mapper = new MapperlyMapper();
    }

    public async Task<UserDto> GetCurrentUserAsync()
    {
        var user = await _userClient.GetCurrentAuthUserAsync();
        ArgumentNullException.ThrowIfNull(user);
        
        var userDto = _mapper.MapToUserDto(user);
        return userDto;
    }
    
    public async Task<UserDto> GetUserAsync(int userId)
    {
        var user = await _userClient.GetUserAsync(userId);
        ArgumentNullException.ThrowIfNull(user);
        
        var userDto = _mapper.MapToUserDto(user);
        return userDto;
    }

    public async Task<IEnumerable<UserDto>?> GetAllAsync(GetUsersOptions? options = null)
    {
        var response = await _userClient.GetUsersAsync(options);
        ArgumentNullException.ThrowIfNull(response);
        
        var usersDto = response.Users.Select(_mapper.MapToUserDto);
        return usersDto;
    }

    public async Task<UserDto> CreateUserAsync(CreateUserRequest request)
    {
        var user = _mapper.MapCreateUserRequestToUser(request);
        var response = await _userClient.AddUserAsync(user);
        ArgumentNullException.ThrowIfNull(response);
        
        var userDto = _mapper.MapToUserDtoSkipSomeProperties(user);
        return userDto;
    }
}