using System.ComponentModel;

namespace Cars.Handbooks.Enums;

/// <summary>
///     Справочник "Стран"
/// </summary>
/// <param name="id"></param> 

public enum CountryOption
{
    [Description("Япония")]
    Japan = 100,
    [Description("Германия")]
    Germany = 101,
    [Description("США")]
    USA = 102,
    [Description("Южная Корея")]
    SouthKorea = 103,
    [Description("Италия")]
    Italy = 104,
    [Description("Россия")]
    Russia = 105,
    [Description("Франция")]
    France = 106,
    [Description("Швеция")]
    Sweden = 107,
    [Description("Чехия")]
    CzechRepublic = 108
}