using System.Collections.Generic;

namespace MALSharp.Client.Anime;

public class CharacterFieldsBuilder : IFieldsBuilder
{
    readonly HashSet<string> _fields;
    AnimeListFieldsBuilder<CharacterFieldsBuilder>? _animeography;

    public CharacterFieldsBuilder()
    {
        _fields = [];
        _animeography = null;
    }

    bool IFieldsBuilder.IsEmpty => _fields.Count is 0;

    /// <summary>
    /// Add <see cref="Models.Anime.Character.FirstName"/> field.
    /// </summary>
    public CharacterFieldsBuilder AddFirstName()
    {
        _fields.Add("first_name");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Character.LastName"/> field.
    /// </summary>
    public CharacterFieldsBuilder AddLastName()
    {
        _fields.Add("last_name");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Character.AlternativeName"/> field.
    /// </summary>
    public CharacterFieldsBuilder AddAlternativeName()
    {
        _fields.Add("alternative_name");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Character.MainPicture"/> field.
    /// </summary>
    public CharacterFieldsBuilder AddMainPicture()
    {
        _fields.Add("main_picture");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Character.Biography"/> field.
    /// </summary>
    public CharacterFieldsBuilder AddBiography()
    {
        _fields.Add("biography");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Character.Pictures"/> field.
    /// </summary>
    public CharacterFieldsBuilder AddPictures()
    {
        _fields.Add("pictures");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Character.Animeography"/> field.
    /// </summary>
    public AnimeListFieldsBuilder<CharacterFieldsBuilder> AddAnimeography()
    {
        return _animeography ??= new(this);
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Character.NumFavorites"/> field.
    /// </summary>
    public CharacterFieldsBuilder AddNumFavorites()
    {
        _fields.Add("num_favorites");
        return this;
    }

    /// <summary>
    /// Add all fields of <see cref="Models.Anime.Character"/>.
    /// </summary>
    public CharacterFieldsBuilder AddAll()
    {
        return AddFirstName()
              .AddLastName()
              .AddAlternativeName()
              .AddMainPicture()
              .AddBiography()
              .AddPictures()
              .AddAnimeography().AddAll().Parent
              .AddNumFavorites();
    }

    /// <summary>
    /// Remove all previously added fields.
    /// </summary>
    public CharacterFieldsBuilder Clear()
    {
        _fields.Clear();
        _animeography = null;
        return this;
    }

    string IFieldsBuilder.Build(bool explicitFields)
    {
        var fields = new List<string>();

        if (explicitFields)
        {
            fields.Add("id");
        }
        fields.AddRange(_fields);

        if (_animeography is not null)
        {
            var content = _animeography.Build(explicitFields);
            if (content == string.Empty)
            {
                fields.Add("animeography");
            }
            else
            {
                fields.Add($"animeography{{{content}}}");
            }
        }
        return string.Join(',', fields);
    }
}
