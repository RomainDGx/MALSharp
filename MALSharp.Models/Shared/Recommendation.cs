using System.Text.Json.Serialization;

namespace MALSharp.Models.Shared;

/// <summary>
/// Representation of anime or manga recommendation
/// </summary>
public class Recommendation<T> where T : Node
{
    [JsonPropertyName("node")]
    public required T Node { get; set; }

    [JsonPropertyName("num_recommendations")]
    public int NumRecommendations { get; set; }
}
