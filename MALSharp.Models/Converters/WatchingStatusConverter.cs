using MALSharp.Models.Anime;
using System.Text.Json;

namespace MALSharp.Models.Converters;

public class WatchingStatusConverter : BaseEnumConverter<WatchingStatus>
{
    public override WatchingStatus StringToEnum(string? value) => value switch
    {
        "watching" => WatchingStatus.Watching,
        "completed" => WatchingStatus.Completed,
        "on_hold" => WatchingStatus.OnHold,
        "dropped" => WatchingStatus.Dropped,
        "plan_to_watch" => WatchingStatus.PlanToWatch,
        _ => throw new JsonException($"Invalid value '{value ?? "null"}' for enum {typeof(WatchingStatus).Name}.")
    };

    public override string EnumToString(WatchingStatus value) => value switch
    {
        WatchingStatus.Watching => "watching",
        WatchingStatus.Completed => "completed",
        WatchingStatus.OnHold => "on_hold",
        WatchingStatus.Dropped => "dropped",
        WatchingStatus.PlanToWatch => "plan_to_watch",
        _ => throw new JsonException($"Invalid value '{value}' for enum {typeof(WatchingStatus).Name}.")
    };
}
