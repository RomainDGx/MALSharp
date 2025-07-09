using MALSharp.Models.Anime;
using MALSharp.Models.Converters;
using System.Text.Json.Serialization;

namespace MALSharp.Client.Anime;

public class AnimeCharacter
{
    [JsonPropertyName("node")]
    public required Character Character { get; set; }

    [JsonPropertyName("role")]
    [JsonConverter(typeof(RoleConverter))]
    public Role Role { get; set; }
}
