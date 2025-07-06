using System.Text.Json.Serialization;

namespace MALSharp.Models.Anime;

public class Studio
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }
}
