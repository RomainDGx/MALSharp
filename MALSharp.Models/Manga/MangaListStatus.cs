using MALSharp.Models.Converters;
using MALSharp.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Manga;

public class MangaListStatus
{
    [JsonPropertyName("status")]
    [JsonConverter(typeof(ReadingStatusConverter))]
    public ReadingStatus Status { get; set; }

    [JsonPropertyName("score")]
    public int Score { get; set; }

    /// <summary>
    /// 0 or the number of read volumes.
    /// </summary>
    [JsonPropertyName("num_volumes_read")]
    public int NumVolumesRead { get; set; }

    /// <summary>
    /// 0 or the number of read chapters.
    /// </summary>
    [JsonPropertyName("num_chapters_read")]
    public int NumChaptersRead { get; set; }

    /// <summary>
    /// If authorized user reads an manga again after completion, this field value is true.
    /// In this case, MyAnimeList treats the manga as 'reading' in the user's manga list.
    /// </summary>
    [JsonPropertyName("is_rereading")]
    public bool IsRereading { get; set; }

    [JsonPropertyName("start_date")]
    [JsonConverter(typeof(MALDateConverter))]
    public MALDate? StartDate { get; set; }

    [JsonPropertyName("finish_date")]
    [JsonConverter(typeof(MALDateConverter))]
    public MALDate? FinishDate { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("num_times_reread")]
    public int? NumTimesReread { get; set; }

    [JsonPropertyName("reread_value")]
    public int? RereadValue { get; set; }

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
