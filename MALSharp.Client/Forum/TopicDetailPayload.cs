using MALSharp.Models.Forum;
using System.Text.Json.Serialization;

namespace MALSharp.Client.Forum;

internal class TopicDetailPayload
{
    [JsonPropertyName("data")]
    public required TopicDetail Topic { get; set; }

    [JsonPropertyName("paging")]
    public required Paging Paging { get; set; }
}
