using MALSharp.Models.Manga;
using System.Text.Json;

namespace MALSharp.Models.Converters;

public class ReadingStatusConverter : BaseEnumConverter<ReadingStatus>
{
    public static ReadingStatus Parse(string? value) => value switch
    {
        "reading" => ReadingStatus.Reading,
        "completed" => ReadingStatus.Completed,
        "on_hold" => ReadingStatus.OnHold,
        "dropped" => ReadingStatus.Dropped,
        "plan_to_read" => ReadingStatus.PlanToRead,
        _ => throw new JsonException($"Invalid value '{value ?? "null"}' for enum {typeof(ReadingStatus).Name}.")
    };

    public static string Format(ReadingStatus value) => value switch
    {
        ReadingStatus.Reading => "reading",
        ReadingStatus.Completed => "completed",
        ReadingStatus.OnHold => "on_hold",
        ReadingStatus.Dropped => "dropped",
        ReadingStatus.PlanToRead => "plan_to_read",
        _ => throw new JsonException($"Invalid value '{value}' for enum {typeof(ReadingStatus).Name}.")
    };

    protected override ReadingStatus ParseCore(string? value) => Parse(value);

    protected override string FormatCore(ReadingStatus value) => Format(value);
}
