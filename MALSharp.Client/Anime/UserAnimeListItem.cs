using MALSharp.Models.Anime;
using System.Text.Json.Serialization;

namespace MALSharp.Client.Anime;

public class UserAnimeListItem
{
    [JsonPropertyName("node")]
    public required Models.Anime.Anime Anime { get; set; }

    [JsonPropertyName("list_status")]
    public AnimeListStatus? ListStatus { get; set; }
}
