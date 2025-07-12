using System.Collections.Generic;

namespace MALSharp.Client.Manga;

public class MangaListStatusFieldsBuilder<TParent>
{
    readonly HashSet<string> _fields;
    readonly TParent _parent;

    public MangaListStatusFieldsBuilder(TParent parent)
    {
        _fields = [];
        _parent = parent;
    }

    public TParent Parent => _parent;

    /// <summary>
    /// Add <see cref="Models.Manga.MangaListStatus.StartDate"/> field.
    /// </summary>
    public MangaListStatusFieldsBuilder<TParent> AddStartDate()
    {
        _fields.Add("start_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.MangaListStatus.FinishDate"/> field.
    /// </summary>
    public MangaListStatusFieldsBuilder<TParent> AddFinishDate()
    {
        _fields.Add("finish_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.MangaListStatus.Priority"/> field.
    /// </summary>
    public MangaListStatusFieldsBuilder<TParent> AddPriority()
    {
        _fields.Add("priority");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.MangaListStatus.NumTimesReread"/> field.
    /// </summary>
    public MangaListStatusFieldsBuilder<TParent> AddNumTimesReread()
    {
        _fields.Add("num_times_reread");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.MangaListStatus.RereadValue"/> field.
    /// </summary>
    public MangaListStatusFieldsBuilder<TParent> AddRereadValue()
    {
        _fields.Add("reread_value");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.MangaListStatus.Tags"/> field.
    /// </summary>
    public MangaListStatusFieldsBuilder<TParent> AddTags()
    {
        _fields.Add("tags");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Manga.MangaListStatus.Comments"/> field.
    /// </summary>
    public MangaListStatusFieldsBuilder<TParent> AddComments()
    {
        _fields.Add("comments");
        return this;
    }

    /// <summary>
    /// Add all fields of <see cref="Models.Manga.MangaListStatus"/>.
    /// </summary>
    public MangaListStatusFieldsBuilder<TParent> AddAll()
    {
        return AddStartDate()
              .AddFinishDate()
              .AddPriority()
              .AddNumTimesReread()
              .AddRereadValue()
              .AddTags()
              .AddComments();
    }

    /// <summary>
    /// Remove all previously added fields.
    /// </summary>
    public MangaListStatusFieldsBuilder<TParent> Clear()
    {
        _fields.Clear();
        return this;
    }

    internal string Build(bool explicitFields)
    {
        var fields = new List<string>();

        if (explicitFields)
        {
            fields.AddRange(["status", "score", "num_volumes_read", "num_chapters_read", "is_rereading", "updated_at"]);
        }
        fields.AddRange(_fields);

        return string.Join(',', fields);
    }
}
