using Cars.Database.Entities;
using Microsoft.AspNetCore.Http;

namespace Cars.Domain.Interfaces;

public interface ICountryService
{
    Task<List<Country>> GetAll();
    Task<Country> Get(int id);
    Task Add(Country country);
    Task Delete(int id);
    Task Import(IFormFile file);
}