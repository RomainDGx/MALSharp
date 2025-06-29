using System;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Shared;

/// <summary>
/// Picture object, commonly representing an image with two resolutions.
/// </summary>
public class Picture
{
    [JsonPropertyName("large")]
    public Uri? Large { get; set; }

    [JsonPropertyName("medium")]
    public required Uri Medium { get; set; }
}
