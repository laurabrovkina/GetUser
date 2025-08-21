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
    public async Task<IActionResult> GetCurrentUser()
    {
        var currentUser = await _userService.GetCurrentUserAsync();
        return Ok(currentUser);
    }
    
    [HttpGet]
    [Route("user/{userId:int}")]
    public async Task<IActionResult> GetUser([FromRoute] int userId)
    {
        var userDto = await _userService.GetUserAsync(userId);
        return Ok(userDto);
    }
    
    [HttpGet]
    [Route("users")]
    public async Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest? request = null)
    {
        if (HttpContext.Request.Query.Count == 0)
        {
            request = null;
        }
        
        GetUsersOptions? options = null;
        if (request is not null)
        {
            options = new GetUsersOptions
            {
                Name = request.Name,
                Page = request.Page ?? 1,
                PageSize = request.PageSize ?? 10
            };
        }
        var users = await _userService.GetAllAsync(options);
        return Ok(users);
    }

    [HttpPost]
    [Route("users")]
    public async Task<IActionResult> CreateUser(CreateUserRequest userRequest)
    {
        var existingUser = await _userService.GetAllAsync();
        var matchingUser = existingUser?.FirstOrDefault(x => x.Username == userRequest.Username
                                                             && x.Email == userRequest.Email
                                                             && x.FirstName == userRequest.FirstName
                                                             && x.LastName == userRequest.LastName
                                                             && x.Age == userRequest.Age
                                                             && x.Gender == userRequest.Gender);
        if (matchingUser is not null)
        {
            throw new ApplicationException("User already exists");
        }
        
        var user = await _userService.CreateUserAsync(userRequest);
        return CreatedAtAction(nameof(GetUser), new { userId = user.Id }, user);
    }
}