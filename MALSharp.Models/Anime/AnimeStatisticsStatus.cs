using MALSharp.Models.Converters;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Anime;

public class AnimeStatisticsStatus
{
    [JsonPropertyName("watching")]
    [JsonConverter(typeof(MALStringToIntConverter))]
    public int Watching { get; set; }

    [JsonPropertyName("completed")]
    [JsonConverter(typeof(MALStringToIntConverter))]
    public int Completed { get; set; }

    [JsonPropertyName("on_hold")]
    [JsonConverter(typeof(MALStringToIntConverter))]
    public int On_hold { get; set; }

    [JsonPropertyName("dropped")]
    [JsonConverter(typeof(MALStringToIntConverter))]
    public int Dropped { get; set; }

    [JsonPropertyName("plan_to_watch")]
    [JsonConverter(typeof(MALStringToIntConverter))]
    public int PlanToWatch { get; set; }
}
