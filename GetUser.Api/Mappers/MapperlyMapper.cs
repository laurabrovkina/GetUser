using GetUser.Api.Models;
using Riok.Mapperly.Abstractions;

namespace GetUser.Api.Mappers;

[Mapper]
public partial class MapperlyMapper
{
    public partial UserDto MapToUserDto(User user);
    public partial IEnumerable<UserDto> MapToUserDto(IEnumerable<User> user);
}