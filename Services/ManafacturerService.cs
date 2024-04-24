using AutoMapper;
using Cars.DataBase;
using Cars.Entities;
using Cars.Models;
using Cars.Parameteres;
using Microsoft.EntityFrameworkCore;

namespace Cars.Services;

public class ManafacturerService
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public ManafacturerService(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ManafacturerModel>> GetAll()
    {
        var manafacturers = await _context.Manafacturers
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<List<ManafacturerModel>>(manafacturers);
    }

    public async Task<ManafacturerModel> Get(int id)
    {
        var manafacturer = await _context.Manafacturers
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<ManafacturerModel>(manafacturer);
    }

    public async Task Add(ManafacturerCreateParameters createParameters)
    {
        var manafacturer = new Manafacturer()
        {
            Fabricator = createParameters.Fabricator,
            DateOfFoundation = createParameters.DateOfFoundation,
            Director = createParameters.Director,
            Workers = createParameters.Workers,
            Branch = createParameters.Branch,
            ContactInformation = createParameters.ContactInformation
        };

        await _context.Manafacturers.AddAsync(manafacturer);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var manafacturer = await _context.Manafacturers.FindAsync(id);
        if (manafacturer != null)
        {
            _context.Manafacturers.Remove(manafacturer);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(int id, ManafacturerUpdateParameters updateParameters)
    {
        var existingManafacturer = await _context.Manafacturers.FindAsync(id);
        if (existingManafacturer != null)
        {
            existingManafacturer.Fabricator = updateParameters.Fabricator;
            existingManafacturer.DateOfFoundation = updateParameters.DateOfFoundation;
            existingManafacturer.Director = updateParameters.Director;
            existingManafacturer.Workers = updateParameters.Workers;
            existingManafacturer.Branch = updateParameters.Branch;
            existingManafacturer.ContactInformation = updateParameters.ContactInformation;
            await _context.SaveChangesAsync();
        }
    }
}