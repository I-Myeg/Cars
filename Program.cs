using System.Text;
using Cars;
using Cars.DataBase;
using Cars.Mapping;
using Cars.Services;
using Cars.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(CarMappingProfile), typeof(EngineMappingProfile), typeof(ManafacturerMappingProfile));


builder.Services.AddNpgsql<DatabaseContext>(
    connectionString: "Host=localhost;Port=5433;Username=postgres;Password=root;Database=cars-db");
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<EngineService>();
builder.Services.AddScoped<ColorService>();
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<ManafacturerService>();

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Encoding.RegisterProvider(new CustomEncodingProvider());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();