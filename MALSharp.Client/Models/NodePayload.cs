using MALSharp.Models.Shared;
using System.Text.Json.Serialization;

namespace MALSharp.Client;

internal class NodePayload<T> where T : Node
{
    [JsonPropertyName("node")]
    public required T Node { get; set; }
}
