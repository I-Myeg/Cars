using Cars.Entities;
using Cars.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers;

[ApiController]
[Route("[controller]")]
public class CarsControllers : ControllerBase
{ 
    private readonly CarService _carService;

    public CarsControllers(CarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Car>>> GetAll()
    {
        return await _carService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Car>> Get(int id)
    {
        var car = await _carService.Get(id);
        if (car == null)
            return NotFound();

        return car;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Car car)
    {
        await _carService.Add(car);
        return CreatedAtAction(nameof(Get), new { id = car.Id }, car);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Car car)
    {
        if (id != car.Id)
            return BadRequest();

        var existingCar = await _carService.Get(id);
        if (existingCar is null)
            return NotFound();

        await _carService.Update(car);

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