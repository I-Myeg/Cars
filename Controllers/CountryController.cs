﻿using Cars.Entities;
using Cars.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private readonly CountryService _countryService;

    public CountryController(CountryService countryService)
    {
        _countryService = countryService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Country>>> GetAllCountries()
    {
        return await _countryService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Country>> GetCountry(int id)
    {
        var country = await _countryService.Get(id);
        if (country == null)
        {
            return NotFound();
        }

        return country;
    }

    [HttpPost]
    public async Task<ActionResult<Country>> AddCountry(Country country)
    {
        await _countryService.Add(country);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        var country = await _countryService.Get(id);
        if (country is null)
            return NotFound();

        await _countryService.Delete(id);

        return NoContent();
    }

    [HttpPost("import")]
    public async Task<IActionResult> ImportCountries(IFormFile file)
    {
        try
        {
            await _countryService.Import(file);
            return Ok("Import successful");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}