using MALSharp.Models.Converters;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Shared;

/// <summary>
/// Object representing relations between anime and/or manga.
/// </summary>
public class Relation<T> where T : Node
{
    [JsonPropertyName("node")]
    public required T Node { get; set; }

    /// <summary>
    /// Gets the type of the relationship between this work and related work.
    /// </summary>
    [JsonPropertyName("relation_type")]
    [JsonConverter(typeof(RelationTypeConverter))]
    public RelationType RelationType { get; set; }

    /// <summary>
    /// Gets the format of <see cref="RelationType"/> for human like "Alternative version".
    /// </summary>
    [JsonPropertyName("relation_type_formatted")]
    public required string RelationTypeFormatted { get; set; }
}
