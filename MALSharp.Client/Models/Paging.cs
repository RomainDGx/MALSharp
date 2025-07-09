using System.Text.Json.Serialization;

namespace MALSharp.Client;

internal class Paging
{
    [JsonPropertyName("previous")]
    public string? Previous { get; set; }

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}
