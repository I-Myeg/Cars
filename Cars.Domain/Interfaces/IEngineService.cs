using Cars.Domain.Models;
using Cars.Domain.Parameters;

namespace Cars.Domain.Interfaces;

public interface IEngineService
{
    Task<List<EngineModel>> GetAll();
    Task<EngineModel> Get(int id);
    Task Add(EngineCreateParameters createParameters);
    Task Delete(int id);
    Task Update(int id, EngineUpdateParameters updateParameters);
}