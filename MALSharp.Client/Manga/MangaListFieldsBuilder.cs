using System.Collections.Generic;

namespace MALSharp.Client.Manga;

public class MangaListFieldsBuilder : IFieldsBuilder
{
    readonly HashSet<string> _fields;
    MangaListStatusFieldsBuilder<MangaListFieldsBuilder>? _myListStatus;

    public MangaListFieldsBuilder()
    {
        _fields = [];
        _myListStatus = null;
    }

    bool IFieldsBuilder.IsEmpty => _fields.Count is 0 && _myListStatus is null;

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.AlternativeTitles"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddAlternativeTitles()
    {
        _fields.Add("alternative_titles");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.StartDate"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddStartDate()
    {
        _fields.Add("start_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.EndDate"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddEndDate()
    {
        _fields.Add("end_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Synopsis"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddSynopsis()
    {
        _fields.Add("synopsis");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Mean"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddMean()
    {
        _fields.Add("mean");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Rank"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddRank()
    {
        _fields.Add("rank");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Popularity"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddPopularity()
    {
        _fields.Add("popularity");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.NumListUsers"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddNumListUsers()
    {
        _fields.Add("num_list_users");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.NumScoringUsers"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddNumScoringUsers()
    {
        _fields.Add("num_scoring_users");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Nsfw"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddNsfw()
    {
        _fields.Add("nsfw");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Genres"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddGenres()
    {
        _fields.Add("genres");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.CreatedAt"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddCreatedAt()
    {
        _fields.Add("created_at");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.UpdatedAt"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddUpdatedAt()
    {
        _fields.Add("updated_at");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.MangaType"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddMangaType()
    {
        _fields.Add("media_type");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Status"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddStatus()
    {
        _fields.Add("status");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.MyListStatus"/> field.
    /// </summary>
    public MangaListStatusFieldsBuilder<MangaListFieldsBuilder> AddMyListStatus()
    {
        return _myListStatus ??= new(this);
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.NumVolumes"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddNumVolumes()
    {
        _fields.Add("num_volumes");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.NumChapters"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddNumChapters()
    {
        _fields.Add("num_chapters");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Authors"/> field.
    /// </summary>
    public MangaListFieldsBuilder AddAuthors()
    {
        _fields.Add("authors");
        return this;
    }

    /// <summary>
    /// Add all fields of <see cref="Models.Manga.Manga"/> available in list.
    /// </summary>
    public MangaListFieldsBuilder AddAll()
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
              .AddAuthors();
    }

    /// <summary>
    /// Remove all previously added fields.
    /// </summary>
    public MangaListFieldsBuilder Clear()
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
        return string.Join(',', fields);
    }
}
