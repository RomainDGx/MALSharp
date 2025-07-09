using System.Collections.Generic;

namespace MALSharp.Client.Anime;

public class UserAnimeListFieldsBuilder : IFieldsBuilder
{
    readonly HashSet<string> _fields;
    AnimeListStatusFieldsBuilder<UserAnimeListFieldsBuilder>? _myListStatus;
    AnimeListStatusFieldsBuilder<UserAnimeListFieldsBuilder>? _listStatus;

    public UserAnimeListFieldsBuilder()
    {
        _fields = [];
        _myListStatus = null;
        _listStatus = null;
    }

    bool IFieldsBuilder.IsEmpty => _fields.Count is 0 && _myListStatus is null;

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.AlternativeTitles"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddAlternativeTitles()
    {
        _fields.Add("alternative_titles");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.StartDate"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddStartDate()
    {
        _fields.Add("start_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.EndDate"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddEndDate()
    {
        _fields.Add("end_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Synopsis"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddSynopsis()
    {
        _fields.Add("synopsis");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Mean"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddMean()
    {
        _fields.Add("mean");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Rank"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddRank()
    {
        _fields.Add("rank");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Popularity"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddPopularity()
    {
        _fields.Add("popularity");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.NumListUsers"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddNumListUsers()
    {
        _fields.Add("num_list_users");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.NumScoringUsers"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddNumScoringUsers()
    {
        _fields.Add("num_scoring_users");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Nsfw"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddNsfw()
    {
        _fields.Add("nsfw");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Genres"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddGenres()
    {
        _fields.Add("genres");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.CreatedAt"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddCreatedAt()
    {
        _fields.Add("created_at");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.UpdatedAt"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddUpdatedAt()
    {
        _fields.Add("updated_at");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.AnimeType"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddAnimeType()
    {
        _fields.Add("media_type");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Status"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddStatus()
    {
        _fields.Add("status");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.MyListStatus"/> field.
    /// </summary>
    public AnimeListStatusFieldsBuilder<UserAnimeListFieldsBuilder> AddMyListStatus()
    {
        return _myListStatus ??= new(this);
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.NumEpisodes"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddNumEpisodes()
    {
        _fields.Add("num_episodes");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.StartSeason"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddStartSeason()
    {
        _fields.Add("start_season");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Broadcast"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddBroadcast()
    {
        _fields.Add("broadcast");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Source"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddSource()
    {
        _fields.Add("source");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.AverageEpisodeDuration"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddAverageEpisodeDuration()
    {
        _fields.Add("average_episode_duration");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Rating"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddRating()
    {
        _fields.Add("rating");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Studios"/> field.
    /// </summary>
    public UserAnimeListFieldsBuilder AddStudios()
    {
        _fields.Add("studios");
        return this;
    }

    /// <summary>
    /// Add <see cref="UserAnimeListItem.ListStatus"/> field.
    /// </summary>
    public AnimeListStatusFieldsBuilder<UserAnimeListFieldsBuilder> AddListStatus()
    {
        return _listStatus ??= new(this);
    }

    /// <summary>
    /// Add all fields of <see cref="Models.Anime.Anime"/> available in list.
    /// </summary>
    public UserAnimeListFieldsBuilder AddAll()
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
              .AddListStatus().AddAll().Parent;
    }

    /// <summary>
    /// Remove all previously added fields.
    /// </summary>
    public UserAnimeListFieldsBuilder Clear()
    {
        _fields.Clear();
        _myListStatus = null;
        _listStatus = null;
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
        if (_listStatus is not null)
        {
            var content = _listStatus.Build(explicitFields);
            if (content == string.Empty)
            {
                fields.Add($"list_status");
            }
            else
            {
                fields.Add($"list_status{{{content}}}");
            }
        }
        return string.Join(',', fields);
    }
}
