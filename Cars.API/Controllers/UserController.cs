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
    public IActionResult Register(UserModel userModel)
    {
        try
        {
            _userService.RegisterUser(userModel);
            return Ok("User registered successfully.");
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] UserModel userModel)
    {
        var user = _userService.Authenticate(userModel.Email, userModel.Password);

        if (user == null)
        {
            return Unauthorized("Invalid email or password.");
        }

        return Ok(user);
    }

    [HttpGet("{email}")]
    public IActionResult GetUserByEmail(string email)
    {
        var user = _userService.GetUserByEmail(email);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        return Ok(user);
    }
}