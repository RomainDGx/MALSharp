using System.Text.Json.Serialization;

namespace MALSharp.Models.Anime;

/// <summary>
/// Object representing list statistics of anime on MAL.
/// </summary>
public class AnimeStatistics
{
    [JsonPropertyName("num_list_users")]
    public int NumListUsers { get; set; }

    [JsonPropertyName("status")]
    public required AnimeStatisticsStatus Status { get; set; }
}
