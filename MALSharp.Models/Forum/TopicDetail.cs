using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Forum;

public class TopicDetail
{
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("posts")]
    public required List<Post> Posts { get; set; }

    [JsonPropertyName("poll")]
    public Poll? Poll { get; set; }
}
