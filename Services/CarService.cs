using AutoMapper;
using Cars.DataBase;
using Cars.Entities;
using Cars.Models;
using Cars.Parameteres;
using Microsoft.EntityFrameworkCore;

namespace Cars.Services;

public class CarService
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public CarService(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CarModel>> GetAll()
    {
        var cars = await _context.Cars
            .AsNoTracking()
            .Include(p => p.Manafacturer)
            .ToListAsync();

        return _mapper.Map<List<CarModel>>(cars);
    }

    public async Task<CarModel> Get(int id)
    {
        var car = await _context.Cars
            .AsNoTracking()
            .Include(p => p.Manafacturer)
            .SingleOrDefaultAsync(p => p.Id == id);
        
        return _mapper.Map<CarModel>(car);
    }

    public async Task Add(CarCreateParameters createParameters)
    {
        var car = new Car()
        {
            ContryId = createParameters.ContryId,
            Year = createParameters.Year,
            Model = createParameters.Model,
            EngineId = createParameters.EngineId,
            ManafacturerId = createParameters.ManafacturerId,
            Transmission = createParameters.Transmission,
            MaxSpeed = createParameters.MaxSpeed,
            Price = createParameters.Price,
            Airbags = createParameters.Airbags,
            Drive = createParameters.Drive,
            ColorId = createParameters.ColorId
        };
        
        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car != null)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(int id, CarUpdateParameters updateParameters)
    {
        var existingCar = await _context.Cars.FindAsync(id);
        if (existingCar != null)
        {
            existingCar.ContryId = updateParameters.ContryId;
            existingCar.Year = updateParameters.Year;
            existingCar.Model = updateParameters.Model;
            existingCar.EngineId = updateParameters.EngineId;
            existingCar.ManafacturerId = updateParameters.ManafacturerId;
            existingCar.Transmission = updateParameters.Transmission;
            existingCar.MaxSpeed = updateParameters.MaxSpeed;
            existingCar.Price = updateParameters.Price;
            existingCar.Airbags = updateParameters.Airbags;
            existingCar.Drive = updateParameters.Drive;
            existingCar.ColorId = updateParameters.ColorId;
            await _context.SaveChangesAsync();
        }
    }
}