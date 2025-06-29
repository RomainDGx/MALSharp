using System.Text.Json.Serialization;

namespace MALSharp.Models.Forum;

public class PollOption
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("text")]
    public required string Text { get; set; }

    [JsonPropertyName("votes")]
    public int Votes { get; set; }
}
