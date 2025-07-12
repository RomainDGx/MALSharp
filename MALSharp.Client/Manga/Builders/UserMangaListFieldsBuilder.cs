using System.Collections.Generic;

namespace MALSharp.Client.Manga;

public class UserMangaListFieldsBuilder : IFieldsBuilder
{
    readonly HashSet<string> _fields;
    MangaListStatusFieldsBuilder<UserMangaListFieldsBuilder>? _myListStatus;
    MangaListStatusFieldsBuilder<UserMangaListFieldsBuilder>? _listStatus;

    public UserMangaListFieldsBuilder()
    {
        _fields = [];
        _myListStatus = null;
        _listStatus = null;
    }

    bool IFieldsBuilder.IsEmpty => _fields.Count is 0 && _myListStatus is null;

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.AlternativeTitles"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddAlternativeTitles()
    {
        _fields.Add("alternative_titles");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.StartDate"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddStartDate()
    {
        _fields.Add("start_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.EndDate"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddEndDate()
    {
        _fields.Add("end_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Synopsis"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddSynopsis()
    {
        _fields.Add("synopsis");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Mean"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddMean()
    {
        _fields.Add("mean");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Rank"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddRank()
    {
        _fields.Add("rank");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Popularity"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddPopularity()
    {
        _fields.Add("popularity");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.NumListUsers"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddNumListUsers()
    {
        _fields.Add("num_list_users");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.NumScoringUsers"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddNumScoringUsers()
    {
        _fields.Add("num_scoring_users");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Nsfw"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddNsfw()
    {
        _fields.Add("nsfw");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Genres"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddGenres()
    {
        _fields.Add("genres");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.CreatedAt"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddCreatedAt()
    {
        _fields.Add("created_at");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.UpdatedAt"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddUpdatedAt()
    {
        _fields.Add("updated_at");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.MangaType"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddMangaType()
    {
        _fields.Add("media_type");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Status"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddStatus()
    {
        _fields.Add("status");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.MyListStatus"/> field.
    /// </summary>
    public MangaListStatusFieldsBuilder<UserMangaListFieldsBuilder> AddMyListStatus()
    {
        return _myListStatus ??= new(this);
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.NumVolumes"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddNumVolumes()
    {
        _fields.Add("num_volumes");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.NumChapters"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddNumChapters()
    {
        _fields.Add("num_chapters");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.Manga.Authors"/> field.
    /// </summary>
    public UserMangaListFieldsBuilder AddAuthors()
    {
        _fields.Add("authors");
        return this;
    }

    /// <summary>
    /// Add <see cref="UserMangaListItem.ListStatus"/> field.
    /// </summary>
    public MangaListStatusFieldsBuilder<UserMangaListFieldsBuilder> AddListStatus()
    {
        return _listStatus ??= new(this);
    }

    /// <summary>
    /// Add all fields of <see cref="Models.Manga.Manga"/> available in list.
    /// </summary>
    public UserMangaListFieldsBuilder AddAll()
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
              .AddListStatus().Parent;
    }

    /// <summary>
    /// Remove all previously added fields.
    /// </summary>
    public UserMangaListFieldsBuilder Clear()
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
                fields.Add("my_list_status");
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
                fields.Add("list_status");
            }
            else
            {
                fields.Add($"list_status{{{content}}}");
            }
        }
        return string.Join(',', fields);
    }
}
