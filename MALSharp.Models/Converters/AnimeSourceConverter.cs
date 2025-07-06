using MALSharp.Models.Anime;
using System.Text.Json;

namespace MALSharp.Models.Converters;

public class AnimeSourceConverter : BaseEnumConverter<AnimeSource>
{
    public override AnimeSource StringToEnum(string? value) => value switch
    {
        "other" => AnimeSource.Other,
        "original" => AnimeSource.Original,
        "manga" => AnimeSource.Manga,
        "4_koma_manga" => AnimeSource.FourKomaManga,
        "web_manga" => AnimeSource.WebManga,
        "digital_manga" => AnimeSource.DigitalManga,
        "novel" => AnimeSource.Novel,
        "light_novel" => AnimeSource.LightNovel,
        "visual_novel" => AnimeSource.VisualNovel,
        "game" => AnimeSource.Game,
        "card_game" => AnimeSource.CardGame,
        "book" => AnimeSource.Book,
        "picture_book" => AnimeSource.PictureBook,
        "radio" => AnimeSource.Radio,
        "music" => AnimeSource.Music,
        "mixed_media" => AnimeSource.MixedMedia,
        _ => throw new JsonException($"Invalid value '{value ?? "null"}' for enum {typeof(AnimeSource).Name}.")
    };

    public override string EnumToString(AnimeSource value) => value switch
    {
        AnimeSource.Other => "other",
        AnimeSource.Original => "original",
        AnimeSource.Manga => "manga",
        AnimeSource.FourKomaManga => "4_koma_manga",
        AnimeSource.WebManga => "web_manga",
        AnimeSource.DigitalManga => "digital_manga",
        AnimeSource.Novel => "novel",
        AnimeSource.LightNovel => "light_novel",
        AnimeSource.VisualNovel => "visual_novel",
        AnimeSource.Game => "game",
        AnimeSource.CardGame => "card_game",
        AnimeSource.Book => "book",
        AnimeSource.PictureBook => "picture_book",
        AnimeSource.Radio => "radio",
        AnimeSource.Music => "music",
        AnimeSource.MixedMedia => "mixed_media",
        _ => throw new JsonException($"Invalid value '{value}' for enum {typeof(AnimeSource).Name}.")
    };
}
