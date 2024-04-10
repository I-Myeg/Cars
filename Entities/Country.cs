using Cars.Handbooks;
using Cars.Handbooks.Enums;

namespace Cars.Entities;

public class Country : Handbook<CountryOption>
{
    public Country(CountryOption id, string description) : base(id, description)
    {
    }
}