using Cars.Models;
using Cars.Parameteres;
using Cars.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers;

[ApiController]
[Route("[controller]")]
public class ManafacturerController : ControllerBase
{
    private readonly ManafacturerService _manafacturerService;

    public ManafacturerController(ManafacturerService manafacturerService)
    {
        _manafacturerService = manafacturerService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ManafacturerModel>>> GetAll()
    {
        return await _manafacturerService.GetAll();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ManafacturerModel>> Get(int id)
    {
        var manafacturer = await _manafacturerService.Get(id);
        if (manafacturer is null)
            return NotFound();

        return manafacturer;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(ManafacturerCreateParameters createParameters)
    {
        await _manafacturerService.Add(createParameters);
        
        return NoContent();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ManafacturerUpdateParameters updateParameters)
    {
        await _manafacturerService.Update(id, updateParameters);

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var manafacturer = await _manafacturerService.Get(id);

        if (manafacturer is null)
            return NotFound();

        await _manafacturerService.Delete(id);

        return NoContent();
    }
}