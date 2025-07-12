using System.Collections.Generic;

namespace MALSharp.Client.Manga;

public class MangaListFieldsBuilder<TParent>
{
    readonly HashSet<string> _fields;
    readonly TParent _parent;
    MangaListStatusFieldsBuilder<MangaListFieldsBuilder<TParent>>? _myListStatus;


    internal MangaListFieldsBuilder(TParent parent)
    {
        _fields = [];
        _parent = parent;
        _myListStatus = null;
    }

    public TParent Parent => _parent;

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.AlternativeTitles"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddAlternativeTitles()
    {
        _fields.Add("alternative_titles");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.StartDate"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddStartDate()
    {
        _fields.Add("start_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.EndDate"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddEndDate()
    {
        _fields.Add("end_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Synopsis"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddSynopsis()
    {
        _fields.Add("synopsis");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Mean"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddMean()
    {
        _fields.Add("mean");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Rank"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddRank()
    {
        _fields.Add("rank");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Popularity"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddPopularity()
    {
        _fields.Add("popularity");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.NumListUsers"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddNumListUsers()
    {
        _fields.Add("num_list_users");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.NumScoringUsers"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddNumScoringUsers()
    {
        _fields.Add("num_scoring_users");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Nsfw"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddNsfw()
    {
        _fields.Add("nsfw");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Genres"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddGenres()
    {
        _fields.Add("genres");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.CreatedAt"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddCreatedAt()
    {
        _fields.Add("created_at");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.UpdatedAt"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddUpdatedAt()
    {
        _fields.Add("updated_at");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.MangaType"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddMangaType()
    {
        _fields.Add("media_type");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Status"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddStatus()
    {
        _fields.Add("status");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.MyListStatus"/> field.
    /// </summary>
    public MangaListStatusFieldsBuilder<MangaListFieldsBuilder<TParent>> AddMyListStatus()
    {
        return _myListStatus ??= new(this);
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.NumVolumes"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddNumVolumes()
    {
        _fields.Add("num_volumes");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.NumChapters"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddNumChapters()
    {
        _fields.Add("num_chapters");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Authors"/> field.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddAuthors()
    {
        _fields.Add("authors");
        return this;
    }

    /// <summary>
    /// Add all fields of <see cref="Models.Manga.Manga"/> available in list.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddAll()
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
    public MangaListFieldsBuilder<TParent> Clear()
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

        return string.Join(',', fields);
    }
}
