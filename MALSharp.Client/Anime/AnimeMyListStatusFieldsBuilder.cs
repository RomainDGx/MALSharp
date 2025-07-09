using System.Collections.Generic;

namespace MALSharp.Client.Anime;

public class AnimeMyListStatusFieldsBuilder<TParent>
{
    readonly HashSet<string> _fields;
    readonly TParent _parent;

    internal AnimeMyListStatusFieldsBuilder(TParent parent)
    {
        _fields = [];
        _parent = parent;
    }

    public TParent Parent => _parent;

    /// <summary>
    /// Add <see cref="Models.Anime.AnimeListStatus.StartDate"/> field.
    /// </summary>
    public AnimeMyListStatusFieldsBuilder<TParent> AddStartDate()
    {
        _fields.Add("start_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.AnimeListStatus.FinishDate"/> field.
    /// </summary>
    public AnimeMyListStatusFieldsBuilder<TParent> AddFinishDate()
    {
        _fields.Add("finish_date");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.AnimeListStatus.Priority"/> field.
    /// </summary>
    public AnimeMyListStatusFieldsBuilder<TParent> AddPriority()
    {
        _fields.Add("priority");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.AnimeListStatus.NumTimesRewatched"/> field.
    /// </summary>
    public AnimeMyListStatusFieldsBuilder<TParent> AddNumTimesRewatched()
    {
        _fields.Add("num_times_rewatched");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.AnimeListStatus.RewatchValue"/> field.
    /// </summary>
    public AnimeMyListStatusFieldsBuilder<TParent> AddRewatchValue()
    {
        _fields.Add("rewatch_value");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.AnimeListStatus.Tags"/> field.
    /// </summary>
    public AnimeMyListStatusFieldsBuilder<TParent> AddTags()
    {
        _fields.Add("tags");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.AnimeListStatus.Comments"/> field.
    /// </summary>
    public AnimeMyListStatusFieldsBuilder<TParent> AddComments()
    {
        _fields.Add("comments");
        return this;
    }

    /// <summary>
    /// Add all fields of <see cref="Models.Anime.AnimeListStatus"/>.
    /// </summary>
    public AnimeMyListStatusFieldsBuilder<TParent> AddAll()
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
    public AnimeMyListStatusFieldsBuilder<TParent> Clear()
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
