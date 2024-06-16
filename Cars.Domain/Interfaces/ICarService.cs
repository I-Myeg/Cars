using Cars.Domain.Models;
using Cars.Domain.Parameters;

namespace Cars.Domain.Interfaces;

public interface ICarService
{
    Task<List<CarModel>> GetAll();
    Task<CarModel> Get(int id);
    Task Add(CarCreateParameters createParameters);
    Task Delete(int id);
    Task Update(int id, CarUpdateParameters updateParameters);
}