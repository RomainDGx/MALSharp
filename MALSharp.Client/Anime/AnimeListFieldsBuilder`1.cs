using System.Collections.Generic;

namespace MALSharp.Client.Anime;

public class AnimeListFieldsBuilder<TParent>
{
    readonly HashSet<string> _fields;
    readonly TParent _parent;
    AnimeListStatusFieldsBuilder<AnimeListFieldsBuilder<TParent>>? _myListStatus;

    internal AnimeListFieldsBuilder(TParent parent)
    {
        _fields = [];
        _parent = parent;
        _myListStatus = null;
    }

    internal bool IsEmpty => _fields.Count is 0 && _myListStatus is null;

    public TParent Parent => _parent;

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.AlternativeTitles"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddAlternativeTitles()
    {
        _fields.Add("alternative_titles");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.StartDate"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddStartDate()
    {
        _fields.Add("start_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.EndDate"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddEndDate()
    {
        _fields.Add("end_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Synopsis"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddSynopsis()
    {
        _fields.Add("synopsis");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Mean"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddMean()
    {
        _fields.Add("mean");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Rank"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddRank()
    {
        _fields.Add("rank");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Popularity"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddPopularity()
    {
        _fields.Add("popularity");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.NumListUsers"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddNumListUsers()
    {
        _fields.Add("num_list_users");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.NumScoringUsers"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddNumScoringUsers()
    {
        _fields.Add("num_scoring_users");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Nsfw"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddNsfw()
    {
        _fields.Add("nsfw");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Genres"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddGenres()
    {
        _fields.Add("genres");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.CreatedAt"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddCreatedAt()
    {
        _fields.Add("created_at");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.UpdatedAt"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddUpdatedAt()
    {
        _fields.Add("updated_at");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.AnimeType"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddAnimeType()
    {
        _fields.Add("media_type");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Status"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddStatus()
    {
        _fields.Add("status");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.MyListStatus"/> field.
    /// </summary>
    public AnimeListStatusFieldsBuilder<AnimeListFieldsBuilder<TParent>> AddMyListStatus()
    {
        return _myListStatus ??= new(this);
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.NumEpisodes"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddNumEpisodes()
    {
        _fields.Add("num_episodes");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.StartSeason"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddStartSeason()
    {
        _fields.Add("start_season");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Broadcast"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddBroadcast()
    {
        _fields.Add("broadcast");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Source"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddSource()
    {
        _fields.Add("source");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.AverageEpisodeDuration"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddAverageEpisodeDuration()
    {
        _fields.Add("average_episode_duration");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Rating"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddRating()
    {
        _fields.Add("rating");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Anime.Studios"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddStudios()
    {
        _fields.Add("studios");
        return this;
    }

    /// <summary>
    /// Add all fields of <see cref="Models.Anime.Anime.Studios"/> available in list.
    /// </summary>
    public AnimeListFieldsBuilder<TParent> AddAll()
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
    public AnimeListFieldsBuilder<TParent> Clear()
    {
        _fields.Clear();
        _myListStatus = null;
        return this;
    }

    internal string Build(bool explicitFields)
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
