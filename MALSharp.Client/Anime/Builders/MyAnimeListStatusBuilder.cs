using MALSharp.Models.Anime;
using MALSharp.Models.Converters;
using System;
using System.Collections.Generic;

namespace MALSharp.Client.Anime;

public class MyAnimeListStatusBuilder
{
    readonly Dictionary<string, string> _fields;

    public MyAnimeListStatusBuilder()
    {
        _fields = [];
    }

    internal Dictionary<string, string> Fields => _fields;

    /// <summary>
    /// Set <see cref="AnimeListStatus.Status"/> field.
    /// </summary>
    public MyAnimeListStatusBuilder SetWatchingStatus(WatchingStatus status)
    {
        _fields["status"] = WatchingStatusConverter.Format(status);
        return this;
    }

    /// <summary>
    /// Set <see cref="AnimeListStatus.IsRewatching"/> field.
    /// </summary>
    public MyAnimeListStatusBuilder SetIsRewatching(bool isRewatching)
    {
        _fields["is_rewatching"] = isRewatching ? "true" : "false";
        return this;
    }

    /// <summary>
    /// Set <see cref="AnimeListStatus.Score"/>.
    /// </summary>
    /// <param name="score">Value between 0 and 10.</param>
    public MyAnimeListStatusBuilder SetScore(int score)
    {
        if (score is < 0 or > 10)
        {
            throw new ArgumentOutOfRangeException(nameof(score), "Score value must be between 0 and 10.");
        }
        _fields["score"] = score.ToString();
        return this;
    }

    /// <summary>
    /// Set <see cref="AnimeListStatus.NumEpisodesWatched"/> field.
    /// </summary>
    public MyAnimeListStatusBuilder SetNumWatchedEpisodes(int numEpisodesWatched)
    {
        if (numEpisodesWatched < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numEpisodesWatched), "Cannot be negative.");
        }
        _fields["num_watched_episodes"] = numEpisodesWatched.ToString();
        return this;
    }

    /// <summary>
    /// Set <see cref="AnimeListStatus.Priority"/> field.
    /// </summary>
    /// <param name="priority">Value between 0 and 2.</param>
    public MyAnimeListStatusBuilder SetPriority(int priority)
    {
        if (priority is < 0 or > 2)
        {
            throw new ArgumentOutOfRangeException(nameof(priority), "Priority value must be between 0 and 2.");
        }
        _fields["priority"] = priority.ToString();
        return this;
    }

    /// <summary>
    /// Set <see cref="AnimeListStatus.NumTimesRewatched"/> field.
    /// </summary>
    public MyAnimeListStatusBuilder SetNumTimesRewatched(int numTimesRewatched)
    {
        if (numTimesRewatched < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numTimesRewatched), "Cannot be negative.");
        }
        _fields["num_times_rewatched"] = numTimesRewatched.ToString();
        return this;
    }

    /// <summary>
    /// Set <see cref="AnimeListStatus.RewatchValue"/> field.
    /// </summary>
    /// <param name="rewatchValue">Value between 0 and 5.</param>
    public MyAnimeListStatusBuilder SetRewatchValue(int rewatchValue)
    {
        if (rewatchValue is < 0 or > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(rewatchValue), "Rewatch value value must be between 0 and 5.");
        }
        _fields["rewatch_value"] = rewatchValue.ToString();
        return this;
    }

    /// <summary>
    /// Set <see cref="AnimeListStatus.Tags"/> field.
    /// </summary>
    public MyAnimeListStatusBuilder SetTags(string tags)
    {
        if (string.IsNullOrEmpty(tags))
        {
            throw new ArgumentNullException(nameof(tags), "Tags cannot be null");
        }
        _fields["tags"] = tags;
        return this;
    }

    /// <summary>
    /// Set <see cref="AnimeListStatus.Comments"/> field.
    /// </summary>
    public MyAnimeListStatusBuilder SetComments(string comments)
    {
        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentNullException(nameof(comments), "Comments cannot be null");
        }
        _fields["comments"] = comments;
        return this;
    }
}
