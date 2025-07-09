using System.Collections.Generic;

namespace MALSharp.Client.Manga;

public class MangaListFieldsBuilder<TParent>
{
    readonly HashSet<string> _fields;
    readonly TParent _parent;

    internal MangaListFieldsBuilder(TParent parent)
    {
        _fields = [];
        _parent = parent;
    }

    public TParent Parent => _parent;

    /// <summary>
    /// Add all fields of <see cref="Models.Manga.Manga"/> available in list.
    /// </summary>
    public MangaListFieldsBuilder<TParent> AddAll()
    {
        return this;
    }

    /// <summary>
    /// Remove all previously added fields.
    /// </summary>
    public MangaListFieldsBuilder<TParent> Clear()
    {
        _fields.Clear();
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
