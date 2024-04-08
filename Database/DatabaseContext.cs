using Cars.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.DataBase;

public class DatabaseContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Engine> Engines { get; set; }
    public DbSet<Manafacturer> Manafacturers { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    
    
}