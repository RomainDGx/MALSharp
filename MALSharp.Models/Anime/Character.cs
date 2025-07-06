using MALSharp.Models.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Anime;

public class Character
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("alternative_name")]
    public string? AlternativeName { get; set; }

    [JsonPropertyName("main_picture")]
    public Picture? MainPicture { get; set; }

    [JsonPropertyName("biography")]
    public string? Biography { get; set; }

    /// <summary>
    /// You cannot contain this field in a list.
    /// </summary>
    [JsonPropertyName("pictures")]
    public List<Picture>? Pictures { get; set; }

    /// <summary>
    /// You cannot contain this field in a list.
    /// </summary>
    [JsonPropertyName("animeography")]
    public List<AnimeRole>? Animeography { get; set; }

    [JsonPropertyName("num_favorites")]
    public int? NumFavorites { get; set; }
}
