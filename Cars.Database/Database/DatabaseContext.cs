using Cars.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.Database.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Engine> Engines { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    
    
}