using MALSharp.Models.Converters;
using System;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Anime;

/// <summary>
/// Object representing date of episode broadcast in Japan time.
/// </summary>
public class Broadcast
{
    /// <summary>
    /// Day of the week broadcast in Japan time.
    /// Day of the week or <see cref="DayOfTheWeek.Other"/>.
    /// </summary>
    [JsonPropertyName("day_of_the_week")]
    [JsonConverter(typeof(DayOfTheWeekConverter))]
    public DayOfTheWeek DayOfTheWeek { get; set; }

    [JsonPropertyName("start_time")]
    [JsonConverter(typeof(MALTimeOnlyConverter))]
    public TimeOnly? StartTime { get; set; }
}
