using System.Text.Json.Serialization;

namespace MALSharp.Client;

public class Ranking
{
    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    [JsonPropertyName("previous_rank")]
    public int? PreviousRank { get; set; }
}
