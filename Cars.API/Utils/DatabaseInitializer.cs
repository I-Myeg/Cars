using Cars.Database.Database;
using Cars.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.API.Utils;

public class DatabaseInitializer
{
    public static async Task InitializeAsync(DatabaseContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (await context.Users.AnyAsync())
        {
            return;
        }

        var roles = new List<Role>
        {
            new Role {Name = "Admin"},
            new Role{Name = "User"}
        };
        
        context.Roles.AddRange(roles);

        var users = new List<User>
        {
            new User { Email = "Admin", Password = BCrypt.Net.BCrypt.HashPassword("admin"), Role = roles[0] },
            new User { Email = "User", Password = BCrypt.Net.BCrypt.HashPassword("user"), Role = roles[1] }
        };
        
        context.Users.AddRange(users);
        await context.SaveChangesAsync();
    }
}