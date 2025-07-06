using MALSharp.Models.Anime;
using System.Text.Json;

namespace MALSharp.Models.Converters;

public class AnimeTypeConverter : BaseEnumConverter<AnimeType>
{
    public override AnimeType StringToEnum(string? value) => value switch
    {
        "unknown" => AnimeType.Unknown,
        "tv" => AnimeType.Tv,
        "ova" => AnimeType.Ova,
        "movie" => AnimeType.Movie,
        "special" => AnimeType.Special,
        "ona" => AnimeType.Ona,
        "music" => AnimeType.Music,
        "pv" => AnimeType.Pv,
        "cm" => AnimeType.Cm,
        "tv_special" => AnimeType.TvSpecial,
        _ => throw new JsonException($"Invalid value '{value ?? "null"}' for enum {typeof(AnimeType).Name}.")
    };

    public override string EnumToString(AnimeType value) => value switch
    {
        AnimeType.Unknown => "unknown",
        AnimeType.Tv => "tv",
        AnimeType.Ova => "ova",
        AnimeType.Movie => "movie",
        AnimeType.Special => "special",
        AnimeType.Ona => "ona",
        AnimeType.Music => "music",
        AnimeType.Pv => "pv",
        AnimeType.Cm => "cm",
        AnimeType.TvSpecial => "tv_special",
        _ => throw new JsonException($"Invalid value '{value}' for enum {typeof(AnimeType).Name}.")
    };
}
