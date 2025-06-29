using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Shared;

public class AlternativeTitles
{
    [JsonPropertyName("synonyms")]
    public List<string>? Synonyms { get; set; }

    [JsonPropertyName("en")]
    public string? English { get; set; }

    [JsonPropertyName("ja")]
    public string? Japan { get; set; }
}
