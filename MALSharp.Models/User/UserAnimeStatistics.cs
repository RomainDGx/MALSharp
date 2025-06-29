using System.Text.Json.Serialization;

namespace MALSharp.Models.User;

public class UserAnimeStatistics
{
    [JsonPropertyName("num_items_watching")]
    public int NumItemsWatching { get; set; }

    [JsonPropertyName("num_items_completed")]
    public int NumItemsCompleted { get; set; }

    [JsonPropertyName("num_items_on_hold")]
    public int NumItemsOnHold { get; set; }

    [JsonPropertyName("num_items_dropped")]
    public int NumItemsDropped { get; set; }

    [JsonPropertyName("num_items_plan_to_watch")]
    public int NumItemsPlanToWatch { get; set; }

    [JsonPropertyName("num_items")]
    public int NumItems { get; set; }

    [JsonPropertyName("num_days_watched")]
    public float NumDaysWatched { get; set; }

    [JsonPropertyName("num_days_watching")]
    public float NumDaysWatching { get; set; }

    [JsonPropertyName("num_days_completed")]
    public float NumDaysCompleted { get; set; }

    [JsonPropertyName("num_days_on_hold")]
    public float NumDaysOnHold { get; set; }

    [JsonPropertyName("num_days_dropped")]
    public float NumDaysDropped { get; set; }

    /// <summary>
    /// <see cref="NumDaysWatching"/> + <see cref="NumDaysCompleted"/> + <see cref="NumDaysOnHold"/> + <see cref="NumDaysDropped"/>
    /// </summary>
    [JsonPropertyName("num_days")]
    public float NumDays { get; set; }

    [JsonPropertyName("num_episodes")]
    public int NumEpisodes { get; set; }

    [JsonPropertyName("num_times_rewatched")]
    public int NumTimesRewatched { get; set; }

    [JsonPropertyName("mean_score")]
    public float MeanScore { get; set; }
}
