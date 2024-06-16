using Cars.API;
using Cars.Database.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Apply migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<DatabaseContext>();
        context.Database.Migrate();
    }
    catch (Exception exception)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(exception, "An error occurrred while migrating the database");
    }
}

// Configure the HTTP request pipeline.
startup.Configure(app, builder.Environment);

app.Run();
