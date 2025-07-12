using System.Collections.Generic;

namespace MALSharp.Client.Anime;

public class AnimeListFieldsBuilder : IFieldsBuilder
{
    readonly HashSet<string> _fields;
    AnimeListStatusFieldsBuilder<AnimeListFieldsBuilder>? _myListStatus;

    public AnimeListFieldsBuilder()
    {
        _fields = [];
        _myListStatus = null;
    }

    bool IFieldsBuilder.IsEmpty => _fields.Count is 0 && _myListStatus is null;

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.AlternativeTitles"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddAlternativeTitles()
    {
        _fields.Add("alternative_titles");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.StartDate"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddStartDate()
    {
        _fields.Add("start_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.EndDate"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddEndDate()
    {
        _fields.Add("end_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Synopsis"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddSynopsis()
    {
        _fields.Add("synopsis");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Mean"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddMean()
    {
        _fields.Add("mean");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Rank"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddRank()
    {
        _fields.Add("rank");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Popularity"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddPopularity()
    {
        _fields.Add("popularity");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.NumListUsers"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddNumListUsers()
    {
        _fields.Add("num_list_users");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.NumScoringUsers"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddNumScoringUsers()
    {
        _fields.Add("num_scoring_users");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Nsfw"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddNsfw()
    {
        _fields.Add("nsfw");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Genres"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddGenres()
    {
        _fields.Add("genres");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.CreatedAt"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddCreatedAt()
    {
        _fields.Add("created_at");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.UpdatedAt"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddUpdatedAt()
    {
        _fields.Add("updated_at");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.AnimeType"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddAnimeType()
    {
        _fields.Add("media_type");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Status"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddStatus()
    {
        _fields.Add("status");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.MyListStatus"/> field.
    /// </summary>
    public AnimeListStatusFieldsBuilder<AnimeListFieldsBuilder> AddMyListStatus()
    {
        return _myListStatus ??= new(this);
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.NumEpisodes"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddNumEpisodes()
    {
        _fields.Add("num_episodes");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.StartSeason"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddStartSeason()
    {
        _fields.Add("start_season");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Broadcast"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddBroadcast()
    {
        _fields.Add("broadcast");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Source"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddSource()
    {
        _fields.Add("source");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.AverageEpisodeDuration"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddAverageEpisodeDuration()
    {
        _fields.Add("average_episode_duration");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Rating"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddRating()
    {
        _fields.Add("rating");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Studios"/> field.
    /// </summary>
    public AnimeListFieldsBuilder AddStudios()
    {
        _fields.Add("studios");
        return this;
    }

    /// <summary>
    /// Add all fields of <see cref="Models.Anime.Anime"/> available in list.
    /// </summary>
    public AnimeListFieldsBuilder AddAll()
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
              .AddStudios();
    }

    /// <summary>
    /// Remove all previously added fields.
    /// </summary>
    public AnimeListFieldsBuilder Clear()
    {
        _fields.Clear();
        _myListStatus = null;
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
                fields.Add($"my_list_status");
            }
            else
            {
                fields.Add($"my_list_status{{{content}}}");
            }
        }
        return string.Join(',', fields);
    }
}
