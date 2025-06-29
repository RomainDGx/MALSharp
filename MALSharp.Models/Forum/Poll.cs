using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Forum;

public class Poll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("question")]
    public required string Question { get; set; }

    [JsonPropertyName("closed")]
    public bool Closed { get; set; }

    [JsonPropertyName("options")]
    public required List<PollOption> Options { get; set; }
}
