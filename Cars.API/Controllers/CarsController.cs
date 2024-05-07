using Cars.Domain.Models;
using Cars.Domain.Parameters;
using Cars.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cars.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CarsController : ControllerBase
{ 
    private readonly CarService _carService;
    public CarsController(CarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CarModel>>> GetAll()
    {
        return await _carService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CarModel>> Get(int id)
    {
        var car = await _carService.Get(id);
        if (car is null)
            return NotFound();

        return car;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CarCreateParameters createParameters)
    {
        await _carService.Add(createParameters);
        
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CarUpdateParameters updateParameters)
    {
        await _carService.Update(id, updateParameters);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var car = await _carService.Get(id);

        if (car is null)
            return NotFound();

        await _carService.Delete(id);

        return NoContent();
    }
}