namespace Cars.Models;

public class CarModel
{
    public int Id { get; set;  }
    public int Year { get; set; }
    public string? Model { get; set; }
    public string? Transmission { get; set; }
    public int MaxSpeed { get; set; }
    public int Price { get; set; }
    public bool Airbags { get; set; }
    public string? Drive { get; set; }
    public string? Fabricator { get; set; }
    public EngineModel Engine { get; set; }
}