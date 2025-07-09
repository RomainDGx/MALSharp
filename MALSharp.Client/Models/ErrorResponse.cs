using System.Text.Json.Serialization;

namespace MALSharp.Client;

internal class ErrorResponse
{
    [JsonPropertyName("error")]
    public required string Error { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
