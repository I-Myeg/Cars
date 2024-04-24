using System.Globalization;
using System.Text;
using Cars.DataBase;
using Cars.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Cars.Services;

public class CountryService
{
    private readonly DatabaseContext _context;

    public CountryService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<Country>> GetAll()
    {
        return await _context.Countries
            .AsNoTracking()
            .ToListAsync();
    }
    
    public async Task<Country> Get(int id)
    {
        return await _context.Countries.FindAsync();
    }
    
    public async Task Add(Country country)
    {
        await _context.Countries.AddAsync(country);
        await _context.SaveChangesAsync();
    }
    
    public async Task Delete(int id)
    {
        var country = await _context.Countries.FindAsync(id);
        if (country != null)
        {
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task Import(IFormFile file)
    {
        using (var reader = new StreamReader(file.OpenReadStream(), Encoding.GetEncoding("Windows-1251")))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
               {
                   Delimiter = ";"
               }))
        {
            // Пропускаем первую строку, так как она содержит заголовки
            csv.Read();
            csv.ReadHeader();

            while (csv.Read())
            {
                
                var id = csv.GetField<int>("id_country");
                var code = csv.GetField<string>("code_country");
                var description = csv.GetField<string>("unit_country");

                if (!_context.Countries.Any(c => c.Code == code))
                {
                    var country = new Country {Id = id, Code = code, Description = description };
                    _context.Countries.Add(country);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}