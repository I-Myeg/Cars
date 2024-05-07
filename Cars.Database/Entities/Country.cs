using Cars.Database.Handbooks.Enums;

namespace Cars.Database.Entities;

public class Country
{
    public CountryOption Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
}
