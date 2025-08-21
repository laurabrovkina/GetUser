using GetUser.Api.Contracts;
using GetUser.Api.Models;
using Riok.Mapperly.Abstractions;

namespace GetUser.Api.Mappers;

[Mapper]
public partial class MapperlyMapper
{
    public partial UserDto MapToUserDto(User user);
    
    [MapperIgnoreSource(nameof(User.Hair))]
    [MapperIgnoreSource(nameof(User.Company))]
    [MapperIgnoreSource(nameof(User.Address))]
    [MapperIgnoreSource(nameof(User.Crypto))]
    public partial UserDto MapToUserDtoSkipSomeProperties(User user);
    
    public partial UserResponse MapToUserResponse(User user);
    
    public partial User MapCreateUserRequestToUser(CreateUserRequest user);
    
    [MapProperty(nameof(UserDto.Limit), nameof(PagedResponse.PageSize))]
    [MapProperty(nameof(UserDto.Skip), nameof(PagedResponse.Page))]
    [MapProperty(nameof(UserDto.Total), nameof(PagedResponse.Total))]
    public partial UsersResponse MapToPagedResponse(UserDto users);
}