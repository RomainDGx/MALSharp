using MALSharp.Models.Converters;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Anime;

public class AnimeSeason
{
    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("season")]
    [JsonConverter(typeof(SeasonConverter))]
    public Season Season { get; set; }
}
