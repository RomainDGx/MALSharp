using MALSharp.Models.Manga;
using System.Text.Json.Serialization;

namespace MALSharp.Client.Manga;

public class UserMangaListItem
{
    [JsonPropertyName("node")]
    public required Models.Manga.Manga Manga { get; set; }

    [JsonPropertyName("list_status")]
    public MangaListStatus? ListStatus { get; set; }
}
