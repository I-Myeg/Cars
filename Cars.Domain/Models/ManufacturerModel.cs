namespace Cars.Domain.Models;

public class ManufacturerModel
{
    public int ManufacturerId { get; set; }
    public string? Fabricator { get; set; }
    public int DateOfFoundation { get; set; }
    public string? Director { get; set; }
    public int Workers { get; set; }
    public string? Branch { get; set; }
    public string? ContactInformation { get; set; }
    public List<CarModel> Cars { get; set; }
}