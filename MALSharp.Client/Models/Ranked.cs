using MALSharp.Models.Shared;
using System.Text.Json.Serialization;

namespace MALSharp.Client;

public class Ranked<T> where T : Node
{
    [JsonPropertyName("node")]
    public required T Node { get; set; }

    [JsonPropertyName("ranking")]
    public required Ranking Ranking { get; set; }
}
