using MALSharp.Models.Anime;
using System.Text.Json;

namespace MALSharp.Models.Converters;

public class DayOfTheWeekConverter : BaseEnumConverter<DayOfTheWeek>
{
    public override DayOfTheWeek StringToEnum(string? value) => value switch
    {
        "monday" => DayOfTheWeek.Monday,
        "tuesday" => DayOfTheWeek.Tuesday,
        "wednesday" => DayOfTheWeek.Wednesday,
        "thursday" => DayOfTheWeek.Thursday,
        "friday" => DayOfTheWeek.Friday,
        "saturday" => DayOfTheWeek.Saturday,
        "sunday" => DayOfTheWeek.Sunday,
        "other" => DayOfTheWeek.Other,
        _ => throw new JsonException($"Invalid value '{value ?? "null"}' for enum {typeof(DayOfTheWeek).Name}.")
    };

    public override string EnumToString(DayOfTheWeek value) => value switch
    {
        DayOfTheWeek.Monday => "monday",
        DayOfTheWeek.Tuesday => "tuesday",
        DayOfTheWeek.Wednesday => "wednesday",
        DayOfTheWeek.Thursday => "thursday",
        DayOfTheWeek.Friday => "friday",
        DayOfTheWeek.Saturday => "saturday",
        DayOfTheWeek.Sunday => "sunday",
        DayOfTheWeek.Other => "other",
        _ => throw new JsonException($"Invalid value '{value}' for enum {typeof(DayOfTheWeek).Name}.")
    };
}
