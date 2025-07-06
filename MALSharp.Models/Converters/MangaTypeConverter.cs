using MALSharp.Models.Manga;
using System.Text.Json;

namespace MALSharp.Models.Converters;

public class MangaTypeConverter : BaseEnumConverter<MangaType>
{
    public override MangaType StringToEnum(string? value) => value switch
    {
        "unknown" => MangaType.Unknown,
        "manga" => MangaType.Manga,
        "novel" => MangaType.Novel,
        "one_shot" => MangaType.OneShot,
        "doujinshi" => MangaType.Doujinshi,
        "manhwa" => MangaType.Manhwa,
        "manhua" => MangaType.Manhua,
        "oel" => MangaType.Oel,
        "light_novel" => MangaType.LightNovel,
        _ => throw new JsonException($"Invalid value '{value ?? "null"}' for enum {typeof(MangaType).Name}.")
    };

    public override string EnumToString(MangaType value) => value switch
    {
        MangaType.Unknown => "unknown",
        MangaType.Manga => "manga",
        MangaType.Novel => "novel",
        MangaType.OneShot => "one_shot",
        MangaType.Doujinshi => "doujinshi",
        MangaType.Manhwa => "manhwa",
        MangaType.Manhua => "manhua",
        MangaType.Oel => "oel",
        MangaType.LightNovel => "light_novel",
        _ => throw new JsonException($"Invalid value '{value}' for enum {typeof(MangaType).Name}.")
    };
}
