using MALSharp.Client.Anime;
using System.Collections.Generic;

namespace MALSharp.Client.Manga;

public class MangaFieldsBuilder : IFieldsBuilder
{
    readonly HashSet<string> _fields;
    MangaListStatusFieldsBuilder<MangaFieldsBuilder>? _myListStatus;
    AnimeListFieldsBuilder<MangaFieldsBuilder>? _relatedAnime;
    MangaListFieldsBuilder<MangaFieldsBuilder>? _relatedManga;
    MangaListFieldsBuilder<MangaFieldsBuilder>? _recommendations;

    public MangaFieldsBuilder()
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
    /// Add <see cref="Models.Manga.Manga.AlternativeTitles"/> field.
    /// </summary>
    public MangaFieldsBuilder AddAlternativeTitles()
    {
        _fields.Add("alternative_titles");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.StartDate"/> field.
    /// </summary>
    public MangaFieldsBuilder AddStartDate()
    {
        _fields.Add("start_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.EndDate"/> field.
    /// </summary>
    public MangaFieldsBuilder AddEndDate()
    {
        _fields.Add("end_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Synopsis"/> field.
    /// </summary>
    public MangaFieldsBuilder AddSynopsis()
    {
        _fields.Add("synopsis");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Mean"/> field.
    /// </summary>
    public MangaFieldsBuilder AddMean()
    {
        _fields.Add("mean");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Rank"/> field.
    /// </summary>
    public MangaFieldsBuilder AddRank()
    {
        _fields.Add("rank");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Popularity"/> field.
    /// </summary>
    public MangaFieldsBuilder AddPopularity()
    {
        _fields.Add("popularity");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.NumListUsers"/> field.
    /// </summary>
    public MangaFieldsBuilder AddNumListUsers()
    {
        _fields.Add("num_list_users");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.NumScoringUsers"/> field.
    /// </summary>
    public MangaFieldsBuilder AddNumScoringUsers()
    {
        _fields.Add("num_scoring_users");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Nsfw"/> field.
    /// </summary>
    public MangaFieldsBuilder AddNsfw()
    {
        _fields.Add("nsfw");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Genres"/> field.
    /// </summary>
    public MangaFieldsBuilder AddGenres()
    {
        _fields.Add("genres");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.CreatedAt"/> field.
    /// </summary>
    public MangaFieldsBuilder AddCreatedAt()
    {
        _fields.Add("created_at");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.UpdatedAt"/> field.
    /// </summary>
    public MangaFieldsBuilder AddUpdatedAt()
    {
        _fields.Add("updated_at");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.MangaType"/> field.
    /// </summary>
    public MangaFieldsBuilder AddMangaType()
    {
        _fields.Add("media_type");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Status"/> field.
    /// </summary>
    public MangaFieldsBuilder AddStatus()
    {
        _fields.Add("status");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.MyListStatus"/> field.
    /// </summary>
    public MangaListStatusFieldsBuilder<MangaFieldsBuilder> AddMyListStatus()
    {
        return _myListStatus ??= new(this);
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.NumVolumes"/> field.
    /// </summary>
    public MangaFieldsBuilder AddNumVolumes()
    {
        _fields.Add("num_volumes");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.NumChapters"/> field.
    /// </summary>
    public MangaFieldsBuilder AddNumChapters()
    {
        _fields.Add("num_chapters");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Authors"/> field.
    /// </summary>
    public MangaFieldsBuilder AddAuthors()
    {
        _fields.Add("authors");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Pictures"/> field.
    /// </summary>
    public MangaFieldsBuilder AddPictures()
    {
        _fields.Add("pictures");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Background"/> field.
    /// </summary>
    public MangaFieldsBuilder AddBackground()
    {
        _fields.Add("background");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.RelatedAnime"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<MangaFieldsBuilder> AddRelatedAnime()
    {
        return _relatedAnime ??= new(this);
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.RelatedManga"/> field.
    /// </summary>
    public MangaListFieldsBuilder<MangaFieldsBuilder> AddRelatedManga()
    {
        return _relatedManga ??= new(this);
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Recommendations"/> field.
    /// </summary>
    public MangaListFieldsBuilder<MangaFieldsBuilder> AddRecommendations()
    {
        return _relatedManga ??= new(this);
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Serialization"/> field.
    /// </summary>
    public MangaFieldsBuilder AddSerialization()
    {
        _fields.Add("serialization");
        return this;
    }

    /// <summary>
    /// Add all fields of <see cref="Models.Manga.Manga"/> available in list.
    /// </summary>
    public MangaFieldsBuilder AddAll()
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
              .AddMangaType()
              .AddStatus()
              .AddMyListStatus().AddAll().Parent
              .AddNumVolumes()
              .AddNumChapters()
              .AddAuthors()
              .AddPictures()
              .AddBackground()
              .AddRelatedAnime().AddAll().Parent
              .AddRelatedManga().AddAll().Parent
              .AddRecommendations().AddAll().Parent
              .AddSerialization();
    }

    /// <summary>
    /// Remove all previously added fields.
    /// </summary>
    public MangaFieldsBuilder Clear()
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
