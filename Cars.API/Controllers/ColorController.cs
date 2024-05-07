using Cars.Database.Entities;
using Cars.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cars.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColorController : ControllerBase
{
    private readonly ColorService _colorService;

    public ColorController(ColorService colorService)
    {
        _colorService = colorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Color>>> GetAllColors()
    {
        return await _colorService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Color>> GetColor(int id)
    {
        var color = await _colorService.Get(id);
        if (color == null)
        {
            return NotFound();
        }

        return color;
    }

    [HttpPost]
    public async Task<ActionResult<Color>> AddColor(Color color)
    {
        await _colorService.Add(color);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteColor(int id)
    {
        var color = await _colorService.Get(id);
        if (color is null)
            return NotFound();

        await _colorService.Delete(id);

        return NoContent();
    }

    [HttpPost("import")]
    public async Task<IActionResult> ImportColors(IFormFile file)
    {
        try
        {
            await _colorService.Import(file);
            return Ok("Import successful");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}