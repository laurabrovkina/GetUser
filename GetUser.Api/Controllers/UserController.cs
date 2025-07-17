using GetUser.Api.Models;
using GetUser.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace GetUser.Api.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("user/me")]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
        var currentUser = await _userService.GetUserAsync();
        return new ObjectResult(currentUser)
        {
            StatusCode = 200
        };
    }
}