using System.Text.Json.Serialization;

namespace MALSharp.Models.Anime;

public class Song
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("anime_id")]
    public int AnimeId { get; set; }

    [JsonPropertyName("text")]
    public required string Text { get; set; }
}
