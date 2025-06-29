using MALSharp.Models.Converters;
using System;
using System.Text.Json.Serialization;

namespace MALSharp.Models.User;

public class UserInformation
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("picture")]
    public required Uri Picture { get; set; }

    [JsonPropertyName("gender")]
    public string? Gender { get; set; }

    [JsonPropertyName("birthday")]
    public DateOnly? BirthDay { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("joined_at")]
    [JsonConverter(typeof(MALDateTimeConverter))]
    public DateTime JoinedAt { get; set; }

    [JsonPropertyName("anime_statistics")]
    public UserAnimeStatistics? AnimeStatistics { get; set; }

    [JsonPropertyName("time_zone")]
    public string? TimeZone { get; set; }

    [JsonPropertyName("is_supporter")]
    public bool? IsSupporter { get; set; }
}
