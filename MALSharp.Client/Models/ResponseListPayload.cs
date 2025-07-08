using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MALSharp.Client;

internal class ResponseListPayload<T>
{
    [JsonPropertyName("data")]
    public required List<T> Data { get; set; }

    [JsonPropertyName("paging")]
    public required Paging Paging { get; set; }
}
