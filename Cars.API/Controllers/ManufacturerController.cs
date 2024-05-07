using Cars.Domain.Models;
using Cars.Domain.Parameters;
using Cars.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cars.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ManufacturerController : ControllerBase
{
    private readonly ManufacturerService _manufacturerService;

    public ManufacturerController(ManufacturerService manufacturerService)
    {
        _manufacturerService = manufacturerService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ManufacturerModel>>> GetAll()
    {
        return await _manufacturerService.GetAll();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ManufacturerModel>> Get(int id)
    {
        var manufacturer = await _manufacturerService.Get(id);
        if (manufacturer is null)
            return NotFound();

        return manufacturer;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(ManufacturerCreateParameters createParameters)
    {
        await _manufacturerService.Add(createParameters);
        
        return NoContent();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ManufacturerUpdateParameters updateParameters)
    {
        await _manufacturerService.Update(id, updateParameters);

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var manufacturer = await _manufacturerService.Get(id);

        if (manufacturer is null)
            return NotFound();

        await _manufacturerService.Delete(id);

        return NoContent();
    }
}