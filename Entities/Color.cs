using Cars.Handbooks;
using Cars.Handbooks.Enums;

namespace Cars.Entities;

public class Color : Handbook<ColorOption>
{
    public Color(ColorOption id, string description) : base(id, description)
    {
    }
}