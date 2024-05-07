namespace Cars.Database.Entities;

public class Car
{
    public int Id { get; set;  }
    public int ContryId { get; set; }
    
    public int Year { get; set; }
    public string? Model { get; set; }
    
    public int EngineId { get; set; }
    public int ManufacturerId { get; set; }
    
    public string? Transmission { get; set; }
    public int MaxSpeed { get; set; }
    public int Price { get; set; }
    public bool Airbags { get; set; }
    public string? Drive { get; set; }
    
    public int ColorId { get; set; }
    
    public Manufacturer Manufacturer { get; set; }
    public Engine Engine { get; set; }
}