using System.Text.Json.Serialization;

namespace MALSharp.Models.Shared;

/// <summary>
/// Anime or Manga Genre.
/// </summary>
public class Genre
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }
}
