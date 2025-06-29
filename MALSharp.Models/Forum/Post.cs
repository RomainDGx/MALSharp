using MALSharp.Models.Converters;
using System;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Forum;

public class Post
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("number")]
    public int Number { get; set; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(MALDateTimeConverter))]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("created_by")]
    public required AuthorWithAvatar CreatedBy { get; set; }

    [JsonPropertyName("body")]
    public required string Body { get; set; }

    [JsonPropertyName("signature")]
    public required string Signature { get; set; }
}
