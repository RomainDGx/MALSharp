using System.Collections.Generic;

namespace MALSharp.Client.Anime;

public class AnimeListStatusFieldsBuilder<TParent>
{
    readonly HashSet<string> _fields;
    readonly TParent _parent;

    internal AnimeListStatusFieldsBuilder(TParent parent)
    {
        _fields = [];
        _parent = parent;
    }

    public TParent Parent => _parent;

    /// <summary>
    /// Add <see cref="Models.Anime.AnimeListStatus.StartDate"/> field.
    /// </summary>
    public AnimeListStatusFieldsBuilder<TParent> AddStartDate()
    {
        _fields.Add("start_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.AnimeListStatus.FinishDate"/> field.
    /// </summary>
    public AnimeListStatusFieldsBuilder<TParent> AddFinishDate()
    {
        _fields.Add("finish_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.AnimeListStatus.Priority"/> field.
    /// </summary>
    public AnimeListStatusFieldsBuilder<TParent> AddPriority()
    {
        _fields.Add("priority");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.AnimeListStatus.NumTimesRewatched"/> field.
    /// </summary>
    public AnimeListStatusFieldsBuilder<TParent> AddNumTimesRewatched()
    {
        _fields.Add("num_times_rewatched");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.AnimeListStatus.RewatchValue"/> field.
    /// </summary>
    public AnimeListStatusFieldsBuilder<TParent> AddRewatchValue()
    {
        _fields.Add("rewatch_value");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.AnimeListStatus.Tags"/> field.
    /// </summary>
    public AnimeListStatusFieldsBuilder<TParent> AddTags()
    {
        _fields.Add("tags");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.AnimeListStatus.Comments"/> field.
    /// </summary>
    public AnimeListStatusFieldsBuilder<TParent> AddComments()
    {
        _fields.Add("comments");
        return this;
    }

    /// <summary>
    /// Add all fields of <see cref="Models.Anime.AnimeListStatus"/>.
    /// </summary>
    public AnimeListStatusFieldsBuilder<TParent> AddAll()
    {
        return AddStartDate()
              .AddFinishDate()
              .AddPriority()
              .AddNumTimesRewatched()
              .AddRewatchValue()
              .AddTags()
              .AddComments();
    }

    /// <summary>
    /// Remove all previously added fields.
    /// </summary>
    public AnimeListStatusFieldsBuilder<TParent> Clear()
    {
        _fields.Clear();
        return this;
    }

    internal string Build(bool explicitFields)
    {
        var fields = new List<string>();

        if (explicitFields)
        {
            fields.AddRange(["status", "score", "num_episodes_watched", "is_rewatching", "updated_at"]);
        }
        fields.AddRange(_fields);

        return string.Join(',', fields);
    }
}
