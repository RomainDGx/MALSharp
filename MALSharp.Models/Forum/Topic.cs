using MALSharp.Models.Converters;
using System;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Forum;

public class Topic
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(MALDateTimeConverter))]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("created_by")]
    public required Author CreatedBy { get; set; }

    [JsonPropertyName("number_of_posts")]
    public int NumberOfPosts { get; set; }

    [JsonPropertyName("last_post_created_at")]
    [JsonConverter(typeof(MALDateTimeConverter))]
    public DateTime LastPostCreatedAt { get; set; }

    [JsonPropertyName("last_post_created_by")]
    public required Author LastPostCreatedBy { get; set; }

    [JsonPropertyName("is_locked")]
    public bool IsLocked { get; set; }
}
