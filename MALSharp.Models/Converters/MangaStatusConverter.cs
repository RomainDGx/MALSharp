using MALSharp.Models.Manga;
using System.Text.Json;

namespace MALSharp.Models.Converters;

public class MangaStatusConverter : BaseEnumConverter<MangaStatus>
{
    public override MangaStatus StringToEnum(string? value) => value switch
    {
        "finished" => MangaStatus.Finished,
        "currently_publishing" => MangaStatus.CurrentlyPublishing,
        "not_yet_published" => MangaStatus.NotYetPublished,
        _ => throw new JsonException($"Invalid value '{value ?? "null"}' for enum {typeof(MangaStatus).Name}.")
    };

    public override string EnumToString(MangaStatus value) => value switch
    {
        MangaStatus.Finished => "finished",
        MangaStatus.CurrentlyPublishing => "currently_publishing",
        MangaStatus.NotYetPublished => "not_yet_published",
        _ => throw new JsonException($"Invalid value '{value}' for enum {typeof(MangaStatus).Name}.")
    };
}
