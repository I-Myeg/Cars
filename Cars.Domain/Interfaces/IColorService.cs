using Cars.Database.Entities;
using Microsoft.AspNetCore.Http;

namespace Cars.Domain.Interfaces;

public interface IColorService
{
    Task<List<Color>> GetAll();
    Task<Color> Get(int id);
    Task Add(Color color);
    Task Delete(int id);
    Task Import(IFormFile file);
}