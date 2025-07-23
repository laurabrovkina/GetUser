using GetUser.Api.Contracts;
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
    
    [HttpGet]
    [Route("users")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers([FromQuery] GetUsersRequest request)
    {
        var options = new GetUsersOptions
        {
            Name = request.Name,
            Page = request.Page,
            PageSize = request.PageSize
        };
        var users = await _userService.GetAllAsync(options);
        return new ObjectResult(users)
        {
            StatusCode = 200
        };
    }
}