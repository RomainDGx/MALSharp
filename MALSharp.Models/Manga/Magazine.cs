using System.Text.Json.Serialization;

namespace MALSharp.Models.Manga;

public class Magazine
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }
}
