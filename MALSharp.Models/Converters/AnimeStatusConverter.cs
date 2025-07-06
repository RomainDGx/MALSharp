using MALSharp.Models.Anime;
using System.Text.Json;

namespace MALSharp.Models.Converters;

public class AnimeStatusConverter : BaseEnumConverter<AnimeStatus>
{
    public override AnimeStatus StringToEnum(string? value) => value switch
    {
        "finished_airing" => AnimeStatus.FinishedAiring,
        "currently_airing" => AnimeStatus.CurrentlyAiring,
        "not_yet_aired" => AnimeStatus.NotYetAired,
        _ => throw new JsonException($"Invalid value '{value ?? "null"}' for enum {typeof(AnimeStatus).Name}.")
    };

    public override string EnumToString(AnimeStatus value) => value switch
    {
        AnimeStatus.FinishedAiring => "finished_airing",
        AnimeStatus.CurrentlyAiring => "currently_airing",
        AnimeStatus.NotYetAired => "not_yet_aired",
        _ => throw new JsonException($"Invalid value '{value}' for enum {typeof(AnimeStatus).Name}.")
    };
}
