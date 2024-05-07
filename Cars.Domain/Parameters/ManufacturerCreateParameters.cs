namespace Cars.Domain.Parameters;

public class ManufacturerCreateParameters
{
    public int ManufacturerId { get; set; }
    public string? Fabricator { get; set; }
    public int DateOfFoundation { get; set; }
    public string? Director { get; set; }
    public int Workers { get; set; }
    public string? Branch { get; set; }
    public string? ContactInformation { get; set; }
}