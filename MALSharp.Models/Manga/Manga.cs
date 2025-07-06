using MALSharp.Models.Converters;
using MALSharp.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Manga;

public class Manga : Node
{
    [JsonPropertyName("alternative_titles")]
    public AlternativeTitles? AlternativeTitles { get; set; }

    [JsonPropertyName("start_date")]
    [JsonConverter(typeof(MALDateConverter))]
    public MALDate? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    [JsonConverter(typeof(MALDateConverter))]
    public MALDate? EndDate { get; set; }

    /// <summary>
    /// Synopsis.
    /// The API strips BBCode tags from the result.
    /// </summary>
    [JsonPropertyName("synopsis")]
    public string? Synopsis { get; set; }

    /// <summary>
    /// Mean score.
    /// When the mean can not be calculated, such as when the number of user scores is small,
    /// the result does not include this field.
    /// </summary>
    [JsonPropertyName("mean")]
    public float? Mean { get; set; }

    /// <summary>
    /// When the rank can not be calculated, such as when the number of user scores is small,
    /// the result does not include this field. 
    /// </summary>
    [JsonPropertyName("rank")]
    public int? Rank { get; set; }

    [JsonPropertyName("popularity")]
    public int? Popularity { get; set; }

    /// <summary>
    /// Number of users who have this work in their list.
    /// </summary>
    [JsonPropertyName("num_list_users")]
    public int? NumListUsers { get; set; }

    [JsonPropertyName("num_scoring_users")]
    public int? NumScoringUsers { get; set; }

    [JsonPropertyName("nsfw")]
    [JsonConverter(typeof(NsfwConverter))]
    public Nsfw? Nsfw { get; set; }

    [JsonPropertyName("genres")]
    public List<Genre>? Genres { get; set; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(MALDateTimeConverter))]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(MALDateTimeConverter))]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("media_type")]
    [JsonConverter(typeof(MangaTypeConverter))]
    public MangaType? MangaType { get; set; }

    /// <summary>
    /// Publishing status.
    /// </summary>
    [JsonPropertyName("status")]
    [JsonConverter(typeof(MangaStatusConverter))]
    public MangaStatus? Status { get; set; }

    [JsonPropertyName("my_list_status")]
    public MangaListStatus? MyListStatus { get; set; }

    /// <summary>
    /// If unknown, it is 0.
    /// </summary>
    [JsonPropertyName("num_volumes")]
    public int? NumVolumes { get; set; }

    /// <summary>
    /// If unknown, it is 0.
    /// </summary>
    [JsonPropertyName("num_chapters")]
    public int? NumChapters { get; set; }

    [JsonPropertyName("authors")]
    public List<AuthorRole>? Authors { get; set; }

    /// <summary>
    /// You cannot contain this field in a list.
    /// </summary>
    [JsonPropertyName("pictures")]
    public List<Picture>? Pictures { get; set; }

    /// <summary>
    /// The API strips BBCode tags from the result.
    /// You cannot contain this field in a list.
    /// </summary>
    [JsonPropertyName("background")]
    public string? Background { get; set; }

    /// <summary>
    /// You cannot contain this field in a list.
    /// </summary>
    [JsonPropertyName("related_anime")]
    public List<Relation<Anime.Anime>>? RelatedAnime { get; set; }

    /// <summary>
    /// You cannot contain this field in a list.
    /// </summary>
    [JsonPropertyName("related_manga")]
    public List<Relation<Manga>>? RelatedManga { get; set; }

    /// <summary>
    /// Summary of recommended manga for those who like this manga.
    /// You cannot contain this field in a list.
    /// </summary>
    [JsonPropertyName("recommendations")]
    public List<Recommendation<Manga>>? Recommendations { get; set; }

    [JsonPropertyName("serialization")]
    public List<SerializationItem>? Serialization { get; set; }
}
