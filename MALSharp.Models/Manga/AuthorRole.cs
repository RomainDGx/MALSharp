using System.Text.Json.Serialization;

namespace MALSharp.Models.Manga;

public class AuthorRole
{
    [JsonPropertyName("node")]
    public required Author Author { get; set; }

    [JsonPropertyName("role")]
    public required string Role { get; set; }
}
