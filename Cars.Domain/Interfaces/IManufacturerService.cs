using Cars.Domain.Models;
using Cars.Domain.Parameters;

namespace Cars.Domain.Interfaces;

public interface IManufacturerService
{
    Task<List<ManufacturerModel>> GetAll();
    Task<ManufacturerModel> Get(int id);
    Task Add(ManufacturerCreateParameters createParameters);
    Task Delete(int id);
    Task Update(int id, ManufacturerUpdateParameters updateParameters);
}