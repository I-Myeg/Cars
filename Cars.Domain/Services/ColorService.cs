using System.Globalization;
using System.Text;
using Cars.Database.Database;
using Cars.Database.Entities;
using Cars.Database.Handbooks.Enums;
using Cars.Domain.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Cars.Domain.Services;


public class ColorService : IColorService
{
    private readonly DatabaseContext _context;

    public ColorService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<Color>> GetAll()
    {
        return await _context.Colors
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Color> Get(int id)
    {
        return await _context.Colors.FindAsync();
    }

    public async Task Add(Color color)
    {
        await _context.Colors.AddAsync(color);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var color = await _context.Colors.FindAsync(id);
        if (color != null)
        {
            _context.Colors.Remove(color);
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
                
                int id = csv.GetField<int>("Id");
                var code = csv.GetField<string>("Code");
                var description = csv.GetField<string>("Description");

                if (!_context.Colors.Any(c => c.Code == code))
                {
                    var color = new Color {Id = (ColorOption)id, Code = code, Description = description };
                    _context.Colors.Add(color);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}