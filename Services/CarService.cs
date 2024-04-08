using Cars.DataBase;
using Cars.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.Services;

public class CarService
{
    private readonly DatabaseContext _context;

    public CarService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<Car>> GetAll()
    {
        return await _context.Cars.ToListAsync();
    }

    public async Task<Car> Get(int id)
    {
        return await _context.Cars.FindAsync(id);
    }

    public async Task Add(Car car)
    {
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

    public async Task Update(Car car)
    {
        var existingCar = await _context.Cars.FindAsync(car.Id);
        if (existingCar != null)
        {
            existingCar.Model = car.Model;
            await _context.SaveChangesAsync();
        }
    }
}