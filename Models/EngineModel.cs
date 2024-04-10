namespace Cars.Models;

public class EngineModel
{
    public int EngineId { get; set; }
    public decimal EngineCapacity { get; set; }
    public int Power { get; set; }
    public string? EngineConfiguration { get; set; }
    public int Torque { get; set; }
}