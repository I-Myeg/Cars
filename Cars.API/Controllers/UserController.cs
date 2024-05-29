using Cars.Database.Entities;
using Cars.Domain.Models;
using Cars.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cars.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
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
        if (!result)
            return BadRequest("User already exist");

        return Ok("User created successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserModel userModel)
    {
        var isValid = await _userService.ValidateUser(userModel.Email, userModel.Password);
        if (!isValid)
            return Unauthorized("Invalid login");

        return Ok("Login successful");

    }
}