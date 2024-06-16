using AutoMapper;
using Cars.Database.Database;
using Cars.Database.Entities;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Domain.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Cars.Domain.Services;

public class ManufacturerService : IManufacturerService
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public ManufacturerService(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ManufacturerModel>> GetAll()
    {
        var manufacturers = await _context.Manufacturers
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<List<ManufacturerModel>>(manufacturers);
    }

    public async Task<ManufacturerModel> Get(int id)
    {
        var manufacturer = await _context.Manufacturers
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<ManufacturerModel>(manufacturer);
    }

    public async Task Add(ManufacturerCreateParameters createParameters)
    {
        var manufacturer = new Manufacturer()
        {
            Fabricator = createParameters.Fabricator,
            DateOfFoundation = createParameters.DateOfFoundation,
            Director = createParameters.Director,
            Workers = createParameters.Workers,
            Branch = createParameters.Branch,
            ContactInformation = createParameters.ContactInformation
        };

        await _context.Manufacturers.AddAsync(manufacturer);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var manufacturer = await _context.Manufacturers.FindAsync(id);
        if (manufacturer != null)
        {
            _context.Manufacturers.Remove(manufacturer);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(int id, ManufacturerUpdateParameters updateParameters)
    {
        var existingManufacturer = await _context.Manufacturers.FindAsync(id);
        if (existingManufacturer != null)
        {
            existingManufacturer.Fabricator = updateParameters.Fabricator;
            existingManufacturer.DateOfFoundation = updateParameters.DateOfFoundation;
            existingManufacturer.Director = updateParameters.Director;
            existingManufacturer.Workers = updateParameters.Workers;
            existingManufacturer.Branch = updateParameters.Branch;
            existingManufacturer.ContactInformation = updateParameters.ContactInformation;
            await _context.SaveChangesAsync();
        }
    }
}