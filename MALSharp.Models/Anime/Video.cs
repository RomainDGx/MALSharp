using MALSharp.Models.Converters;
using System;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Anime;

public class Video
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("url")]
    public required Uri Url { get; set; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(UnixMillisecondsDateTimeConverter))]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof (UnixMillisecondsDateTimeConverter))]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("thumbnail")]
    public required Uri Thumbnail { get; set; }
}
