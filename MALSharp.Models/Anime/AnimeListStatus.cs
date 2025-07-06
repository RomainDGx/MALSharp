using MALSharp.Models.Converters;
using MALSharp.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Anime;

/// <summary>
/// Status from users anime list.
/// </summary>
public class AnimeListStatus
{
    [JsonPropertyName("status")]
    [JsonConverter(typeof(WatchingStatusConverter))]
    public WatchingStatus Status { get; set; }

    [JsonPropertyName("score")]
    public int Score { get; set; }

    /// <summary>
    /// 0 or the number of watched episodes.
    /// </summary>
    [JsonPropertyName("num_episodes_watched")]
    public int NumEpisodesWatched { get; set; }

    /// <summary>
    /// If authorized user watches an anime again after completion, this field value is true.
    /// In this case, MyAnimeList treats the anime as 'watching' in the user's anime list.
    /// </summary>
    [JsonPropertyName("is_rewatching")]
    public bool IsRewatching { get; set; }

    [JsonPropertyName("start_date")]
    [JsonConverter(typeof(MALDateConverter))]
    public MALDate? StartDate { get; set; }

    [JsonPropertyName("finish_date")]
    [JsonConverter(typeof(MALDateConverter))]
    public MALDate? FinishDate { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("num_times_rewatched")]
    public int? NumTimesRewatched { get; set; }

    [JsonPropertyName("rewatch_value")]
    public int? RewatchValue { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    /// <summary>
    /// You cannot contain this field in a list.
    /// </summary>
    [JsonPropertyName("comments")]
    public string? Comments { get; set; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(MALDateTimeConverter))]
    public DateTime UpdatedAt { get; set; }
}
