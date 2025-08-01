using GetUser.Api.Contracts;
using GetUser.Api.Models;
using Riok.Mapperly.Abstractions;

namespace GetUser.Api.Mappers;

[Mapper]
public partial class MapperlyMapper
{
    public partial UserDto MapToUserDto(User user);
    
    [MapProperty(nameof(UserDto.Limit), nameof(PagedResponse.PageSize))]
    [MapProperty(nameof(UserDto.Skip), nameof(PagedResponse.Page))]
    [MapProperty(nameof(UserDto.Total), nameof(PagedResponse.Total))]
    public partial UsersResponse MapToPagedResponse(UserDto users);
}