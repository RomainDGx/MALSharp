using System.Text.Json.Serialization;

namespace MALSharp.Models.Forum;

public class Subboard
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }
}
