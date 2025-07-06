using MALSharp.Models.Converters;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Anime;

public class AnimeRole
{
    [JsonPropertyName("node")]
    public required Anime Anime { get; set; }

    [JsonPropertyName("role")]
    [JsonConverter(typeof(RoleConverter))]
    public Role Role { get; set; }
}
