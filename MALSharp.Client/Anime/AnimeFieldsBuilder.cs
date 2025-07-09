using MALSharp.Client.Manga;
using System.Collections.Generic;

namespace MALSharp.Client.Anime;

public class AnimeFieldsBuilder : IFieldsBuilder
{
    readonly HashSet<string> _fields;
    AnimeListStatusFieldsBuilder<AnimeFieldsBuilder>? _myListStatus;
    AnimeListFieldsBuilder<AnimeFieldsBuilder>? _relatedAnime;
    MangaListFieldsBuilder<AnimeFieldsBuilder>? _relatedManga;
    AnimeListFieldsBuilder<AnimeFieldsBuilder>? _recommendations;

    public AnimeFieldsBuilder()
    {
        _fields = [];
        _myListStatus = null;
        _relatedAnime = null;
        _relatedManga = null;
        _recommendations = null;
    }
    
    bool IFieldsBuilder.IsEmpty => _fields.Count is 0
                                && _myListStatus is null
                                && _relatedAnime is null
                                && _relatedManga is null
                                && _recommendations is null;

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.AlternativeTitles"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddAlternativeTitles()
    {
        _fields.Add("alternative_titles");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.StartDate"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddStartDate()
    {
        _fields.Add("start_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.EndDate"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddEndDate()
    {
        _fields.Add("end_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Synopsis"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddSynopsis()
    {
        _fields.Add("synopsis");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Mean"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddMean()
    {
        _fields.Add("mean");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Rank"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddRank()
    {
        _fields.Add("rank");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Popularity"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddPopularity()
    {
        _fields.Add("popularity");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.NumListUsers"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddNumListUsers()
    {
        _fields.Add("num_list_users");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.NumScoringUsers"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddNumScoringUsers()
    {
        _fields.Add("num_scoring_users");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Nsfw"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddNsfw()
    {
        _fields.Add("nsfw");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Genres"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddGenres()
    {
        _fields.Add("genres");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.CreatedAt"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddCreatedAt()
    {
        _fields.Add("created_at");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.UpdatedAt"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddUpdatedAt()
    {
        _fields.Add("updated_at");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.AnimeType"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddAnimeType()
    {
        _fields.Add("media_type");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Status"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddStatus()
    {
        _fields.Add("status");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.MyListStatus"/> field.
    /// </summary>
    public AnimeListStatusFieldsBuilder<AnimeFieldsBuilder> AddMyListStatus()
    {
        return _myListStatus ??= new(this);
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.NumEpisodes"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddNumEpisodes()
    {
        _fields.Add("num_episodes");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.StartSeason"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddStartSeason()
    {
        _fields.Add("start_season");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Broadcast"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddBroadcast()
    {
        _fields.Add("broadcast");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Source"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddSource()
    {
        _fields.Add("source");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.AverageEpisodeDuration"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddAverageEpisodeDuration()
    {
        _fields.Add("average_episode_duration");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Rating"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddRating()
    {
        _fields.Add("rating");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Studios"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddStudios()
    {
        _fields.Add("studios");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Pictures"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddPictures()
    {
        _fields.Add("pictures");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Background"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddBackground()
    {
        _fields.Add("background");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.RelatedAnime"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<AnimeFieldsBuilder> AddRelatedAnime()
    {
        return _relatedAnime ??= new(this);
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.RelatedManga"/> field.
    /// </summary>
    public MangaListFieldsBuilder<AnimeFieldsBuilder> AddRelatedManga()
    {
        return _relatedManga ??= new(this);
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Recommendations"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<AnimeFieldsBuilder> AddRecommendations()
    {
        return _recommendations ??= new(this);
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Statistics"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddStatistics()
    {
        _fields.Add("statistics");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Videos"/> field.
    /// </summary>
    public AnimeFieldsBuilder AddVideos()
    {
        _fields.Add("videos");
        return this;
    }

    /// <summary>
    /// Add all fields of <see cref="Models.Anime.Anime"/>.
    /// </summary>
    public AnimeFieldsBuilder AddAll()
    {
        return AddAlternativeTitles()
              .AddStartDate()
              .AddEndDate()
              .AddSynopsis()
              .AddMean()
              .AddRank()
              .AddPopularity()
              .AddNumListUsers()
              .AddNumScoringUsers()
              .AddNsfw()
              .AddGenres()
              .AddCreatedAt()
              .AddUpdatedAt()
              .AddAnimeType()
              .AddStatus()
              .AddMyListStatus().AddAll().Parent
              .AddNumEpisodes()
              .AddStartSeason()
              .AddBroadcast()
              .AddSource()
              .AddAverageEpisodeDuration()
              .AddRating()
              .AddStudios()
              .AddPictures()
              .AddBackground()
              .AddRelatedAnime().AddAll().Parent
              .AddRelatedManga().AddAll().Parent
              .AddRecommendations().AddAll().Parent
              .AddStatistics()
              .AddVideos();
    }

    /// <summary>
    /// Remove all previously added fields.
    /// </summary>
    public AnimeFieldsBuilder Clear()
    {
        _fields.Clear();
        _myListStatus = null;
        _relatedAnime = null;
        _relatedManga = null;
        _recommendations = null;
        return this;
    }

    string IFieldsBuilder.Build(bool explicitFields)
    {
        var fields = new List<string>();

        if (explicitFields)
        {
            fields.AddRange(["id", "title", "main_picture"]);
        }
        fields.AddRange(_fields);

        if (_myListStatus is not null)
        {
            var content = _myListStatus.Build(explicitFields);
            if (content == string.Empty)
            {
                fields.Add("my_list_status");
            }
            else
            {
                fields.Add($"my_list_status{{{content}}}");
            }
        }
        if (_relatedAnime is not null)
        {
            var content = _relatedAnime.Build(explicitFields);
            if (content == string.Empty)
            {
                fields.Add($"related_anime");
            }
            else
            {
                fields.Add($"related_anime{{{content}}}");
            }
        }
        if (_relatedManga is not null)
        {
            var content = _relatedManga.Build(explicitFields);
            if (content == string.Empty)
            {
                fields.Add($"related_manga");
            }
            else
            {
                fields.Add($"related_manga{{{content}}}");
            }
        }
        if (_recommendations is not null)
        {
            var content = _recommendations.Build(explicitFields);
            if (content == string.Empty)
            {
                fields.Add($"recommendations");
            }
            else
            {
                fields.Add($"recommendations{{{content}}}");
            }
        }
        return string.Join(',', fields);
    }
}
