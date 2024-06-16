using Cars.Database.Entities;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cars.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserModel userModel)
    {
        var user = new User
        {
            Email = userModel.Email,
            Password = userModel.Password,
            Role = userModel.Role
        };

        var result = await _userService.CreateUser(user);
        if (result == null)
            return BadRequest("User already exist");

        if (user.Email != null)
        {
            var token = _userService.GenerateJwtToken(user);
            
            return Ok(new { Token = token });
        }
        else
        {
            return BadRequest("User email cannot be null");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        var token = await _userService.Login(loginModel.Email, loginModel.Password);
        if (token == null)
            return Unauthorized("Invalid login");

        return Ok(new { token });
    }
}