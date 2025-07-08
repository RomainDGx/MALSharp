using System.Collections.Generic;

namespace MALSharp.Client.User;

public class UserInformationFieldsBuilder : IFieldsBuilder
{
    readonly HashSet<string> _fields;

    public UserInformationFieldsBuilder()
    {
        _fields = [];
    }

    bool IFieldsBuilder.IsEmpty => _fields.Count is 0;

    /// <summary>
    /// Add <see cref="Models.User.UserInformation.AnimeStatistics"/> field.
    /// </summary>
    public UserInformationFieldsBuilder AddAnimeStatistics()
    {
        _fields.Add("anime_statistics");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.User.UserInformation.TimeZone"/> field.
    /// </summary>
    public UserInformationFieldsBuilder AddTimeZone()
    {
        _fields.Add("time_zone");
        return this;
    }

    /// <summary>
    /// Add <see cref="Models.User.UserInformation.IsSupporter"/> field.
    /// </summary>
    public UserInformationFieldsBuilder AddIsSupporter()
    {
        _fields.Add("is_supporter");
        return this;
    }

    public UserInformationFieldsBuilder AddAll() => AddAnimeStatistics().AddTimeZone().AddIsSupporter();

    /// <summary>
    /// Remove all previously added fields.
    /// </summary>
    public UserInformationFieldsBuilder Clear()
    {
        _fields.Clear();
        return this;
    }

    string IFieldsBuilder.Build(bool explicitFields)
    {
        var fields = new List<string>();

        if (explicitFields)
        {
            fields.AddRange(["id", "name", "gender", "birthday", "location", "joined_at", "picture"]);
        }
        foreach (var field in _fields)
        {
            if (field is "anime_statistics" && explicitFields)
            {
                fields.Add("anime_statistics{num_items_watching,num_items_completed,num_items_on_hold,num_items_dropped,num_items_plan_to_watch,num_items,num_days_watched,num_days_watching,num_days_completed,num_days_on_hold,num_days_dropped,num_days,num_episodes,num_times_rewatched,mean_score}");
            }
            else
            {
                fields.Add(field);
            }
        }
        return string.Join(',', fields);
    }
}
