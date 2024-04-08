namespace Cars.Entities;

public class Manafacturer
{
    public int ManafacturerId { get; set; }
    public string? Fabricator { get; set; }
    public int DateOfFoundation { get; set; }
    public string? Director { get; set; }
    public int Workers { get; set; }
    public string? Branch { get; set; }
    public string? ContactInformation { get; set; }
    
    public List<Car> Cars { get; set; }
}