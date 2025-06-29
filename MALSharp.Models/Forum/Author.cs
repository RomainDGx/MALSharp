using System.Text.Json.Serialization;

namespace MALSharp.Models.Forum;

public class Author
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }
}
