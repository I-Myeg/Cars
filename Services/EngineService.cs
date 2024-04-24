using AutoMapper;
using Cars.DataBase;
using Cars.Entities;
using Cars.Models;
using Cars.Parameteres;
using Microsoft.EntityFrameworkCore;

namespace Cars.Services;

public class EngineService
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public EngineService(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EngineModel>> GetAll()
    {
        var engines = await _context.Engines
            .AsNoTracking()
            .Include(p => p.Cars)
            .ToListAsync();

        return _mapper.Map<List<EngineModel>>(engines);
    }

    public async Task<EngineModel> Get(int id)
    {
        var engine = await _context.Engines
            .AsNoTracking()
            .Include(p => p.Cars)
            .ToListAsync();

        return _mapper.Map<EngineModel>(engine);
    }

    public async Task Add(EngineCreateParameters createParameters)
    {
        var engine = new Engine()
        {
            EngineCapacity = createParameters.EngineCapacity,
            Power = createParameters.Power,
            EngineConfiguration = createParameters.EngineConfiguration,
            Torque = createParameters.Torque
        };

        await _context.Engines.AddAsync(engine);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var engine = await _context.Engines.FindAsync(id);
        if (engine != null)
        {
            _context.Engines.Remove(engine);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(int id, EngineUpdateParameters updateParameters)
    {
        var existingEngine = await _context.Engines.FindAsync(id);
        if (existingEngine != null)
        {
            existingEngine.EngineCapacity = updateParameters.EngineCapacity;
            existingEngine.Power = updateParameters.Power;
            existingEngine.EngineConfiguration = updateParameters.EngineConfiguration;
            existingEngine.Torque = updateParameters.Torque;
            await _context.SaveChangesAsync();
        }
    }
}