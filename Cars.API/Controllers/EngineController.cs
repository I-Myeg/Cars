using Cars.Domain.Models;
using Cars.Domain.Parameters;
using Cars.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cars.API.Controllers;


[ApiController]
[Route("[controller]")]
public class EngineController : ControllerBase
{
    private readonly EngineService _engineService;

    public EngineController(EngineService engineService)
    {
        _engineService = engineService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<EngineModel>>> GetAll()
    {
        return await _engineService.GetAll();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<EngineModel>> Get(int id)
    {
        var engine = await _engineService.Get(id);
        if (engine is null)
            return NotFound();

        return engine;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(EngineCreateParameters createParameters)
    {
        await _engineService.Add(createParameters);
        
        return NoContent();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EngineUpdateParameters updateParameters)
    {
        await _engineService.Update(id, updateParameters);

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var engine = await _engineService.Get(id);

        if (engine is null)
            return NotFound();

        await _engineService.Delete(id);

        return NoContent();
    }
}