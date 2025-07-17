using GetUser.Api.Mappers;
using GetUser.Api.Models;
using GetUser.Api.UserHttpClient;

namespace GetUser.Api.Services;

public class UserService : IUserService
{
    private readonly IUserClient _userClient;
    private readonly MapperlyMapper _mapper;

    public UserService(IUserClient userClient, MapperlyMapper mapper)
    {
        _userClient = userClient;
        _mapper = new MapperlyMapper();
    }

    public async Task<UserDto> GetUserAsync()
    {
        var user = await _userClient.GetCurrentAuthUserAsync();
        ArgumentNullException.ThrowIfNull(user);
        
        var userDto = _mapper.MapToUserDto(user);
        return userDto;
    }
}