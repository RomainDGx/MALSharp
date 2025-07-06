using MALSharp.Models.Anime;
using System.Text.Json;

namespace MALSharp.Models.Converters;

public class SeasonConverter : BaseEnumConverter<Season>
{
    public override Season StringToEnum(string? value) => value switch
    {
        "winter" => Season.Winter,
        "spring" => Season.Spring,
        "summer" => Season.Summer,
        "fall" => Season.Fall,
        _ => throw new JsonException($"Invalid value '{value ?? "null"}' for enum {typeof(Season).Name}.")
    };

    public override string EnumToString(Season value) => value switch
    {
        Season.Winter => "winter",
        Season.Spring => "spring",
        Season.Summer => "summer",
        Season.Fall => "fall",
        _ => throw new JsonException($"Invalid value '{value}' for enum {typeof(Season).Name}.")
    };
}
