using MALSharp.Models.Converters;
using MALSharp.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Anime;

/// <summary>
/// Model of anime fetched from MyAnimeList.
/// </summary>
public class Anime : Node
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
    [JsonConverter(typeof(AnimeTypeConverter))]
    public AnimeType? AnimeType { get; set; }

    /// <summary>
    /// Airing status.
    /// </summary>
    [JsonPropertyName("status")]
    [JsonConverter(typeof(AnimeStatusConverter))]
    public AnimeStatus? Status { get; set; }

    /// <summary>
    /// Status of user's anime list. If there is no access token, the API excludes this field.
    /// </summary>
    [JsonPropertyName("my_list_status")]
    public AnimeListStatus? MyListStatus { get; set; }

    /// <summary>
    /// The total number of episodes of this series. If unknown, it is 0.
    /// </summary>
    [JsonPropertyName("num_episodes")]
    public int? NumEpisodes { get; set; }

    [JsonPropertyName("start_season")]
    public AnimeSeason? StartSeason { get; set; }

    [JsonPropertyName("broadcast")]
    public Broadcast? Broadcast { get; set; }

    /// <summary>
    /// Original work.
    /// </summary>
    [JsonPropertyName("source")]
    [JsonConverter(typeof(AnimeSourceConverter))]
    public AnimeSource? Source { get; set; }

    /// <summary>
    /// Average length of episode in seconds.
    /// </summary>
    [JsonPropertyName("average_episode_duration")]
    [JsonConverter(typeof(TimeSpanConverter))]
    public TimeSpan? AverageEpisodeDuration { get; set; }

    [JsonPropertyName("rating")]
    [JsonConverter(typeof(RatingConverter))]
    public Rating? Rating { get; set; }

    [JsonPropertyName("studios")]
    public List<Studio>? Studios { get; set; }

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
    public List<Relation<Anime>>? RelatedAnime { get; set; }

    /// <summary>
    /// You cannot contain this field in a list.
    /// </summary>
    [JsonPropertyName("related_manga")]
    public List<Relation<Manga.Manga>>? RelatedManga { get; set; }

    /// <summary>
    /// Summary of recommended anime for those who like this anime.
    /// You cannot contain this field in a list.
    /// </summary>
    [JsonPropertyName("recommendations")]
    public List<Recommendation<Anime>>? Recommendations { get; set; }

    /// <summary>
    /// You cannot contain this field in a list.
    /// </summary>
    [JsonPropertyName("statistics")]
    public AnimeStatistics? Statistics { get; set; }

    /// <summary>
    /// You cannot contain this field in a list.
    /// </summary>
    [JsonPropertyName("videos")]
    public List<Video>? Videos { get; set; }
}
