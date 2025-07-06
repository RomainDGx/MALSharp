using System.Text.Json.Serialization;

namespace MALSharp.Models.Manga;

public class Author
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public required string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public required string LastName { get; set; }
}
