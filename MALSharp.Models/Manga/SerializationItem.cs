using System.Text.Json.Serialization;

namespace MALSharp.Models.Manga;

public class SerializationItem
{
    [JsonPropertyName("node")]
    public required Magazine Magazine { get; set; }

    [JsonPropertyName("role")]
    public string? Role { get; set; }
}
