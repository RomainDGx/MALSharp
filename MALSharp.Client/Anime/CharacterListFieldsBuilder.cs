using System.Collections.Generic;

namespace MALSharp.Client.Anime;

public class CharacterListFieldsBuilder : IFieldsBuilder
{
    readonly HashSet<string> _fields;

    public CharacterListFieldsBuilder()
    {
        _fields = [];
    }

    bool IFieldsBuilder.IsEmpty => _fields.Count is 0;

    /// <summary>
    /// Add <see cref="Models.Anime.Character.FirstName"/> field.
    /// </summary>
    public CharacterListFieldsBuilder AddFirstName()
    {
        _fields.Add("first_name");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Character.LastName"/> field.
    /// </summary>
    public CharacterListFieldsBuilder AddLastName()
    {
        _fields.Add("last_name");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Character.AlternativeName"/> field.
    /// </summary>
    public CharacterListFieldsBuilder AddAlternativeName()
    {
        _fields.Add("alternative_name");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Character.MainPicture"/> field.
    /// </summary>
    public CharacterListFieldsBuilder AddMainPicture()
    {
        _fields.Add("main_picture");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Character.Biography"/> field.
    /// </summary>
    public CharacterListFieldsBuilder AddBiography()
    {
        _fields.Add("biography");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.Anime.Character.NumFavorites"/> field.
    /// </summary>
    public CharacterListFieldsBuilder AddNumFavorites()
    {
        _fields.Add("num_favorites");
        return this;
    }

    /// <summary>
    /// Add all fields of <see cref="Models.Anime.Character"/> available in list.
    /// </summary>
    public CharacterListFieldsBuilder AddAll()
    {
        return AddFirstName()
              .AddLastName()
              .AddAlternativeName()
              .AddMainPicture()
              .AddBiography()
              .AddNumFavorites();
    }

    /// <summary>
    /// Remove all previously added fields.
    /// </summary>
    public CharacterListFieldsBuilder Clear()
    {
        _fields.Clear();
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

        return string.Join(',', fields);
    }
}
