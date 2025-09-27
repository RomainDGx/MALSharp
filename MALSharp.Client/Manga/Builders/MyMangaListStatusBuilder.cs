using MALSharp.Models.Converters;
using MALSharp.Models.Manga;
using System;
using System.Collections.Generic;

namespace MALSharp.Client.Manga;

public class MyMangaListStatusBuilder
{
    readonly Dictionary<string, string> _fields;

    public MyMangaListStatusBuilder()
    {
        _fields = [];
    }

    internal Dictionary<string, string> Fields => _fields;

    /// <summary>
    /// Set <see cref="MangaListStatus.Status"/> field.
    /// </summary>
    public MyMangaListStatusBuilder SetStatus(ReadingStatus status)
    {
        _fields["status"] = ReadingStatusConverter.Format(status);
        return this;
    }

    /// <summary>
    /// Set <see cref="MangaListStatus.IsRereading"/> field.
    /// </summary>
    public MyMangaListStatusBuilder SetIsReading(bool isRereading)
    {
        _fields["is_rereading"] = isRereading ? "true" : "false";
        return this;
    }

    /// <summary>
    /// Set <see cref="MangaListStatus.Score"/> field.
    /// </summary>
    /// <param name="score">Value between 0 and 10.</param>
    public MyMangaListStatusBuilder SetScore(int score)
    {
        if (score is < 0 or > 10)
        {
            throw new ArgumentOutOfRangeException(nameof(score), "Score value must be between 0 and 10.");
        }
        _fields["score"] = score.ToString();
        return this;
    }

    /// <summary>
    /// Set <see cref="MangaListStatus.NumVolumesRead"/> field.
    /// </summary>
    public MyMangaListStatusBuilder SetNumVolumesRead(int numVolumesRead)
    {
        if (numVolumesRead < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numVolumesRead), "Cannot be negative.");
        }
        _fields["num_volumes_read"] = numVolumesRead.ToString();
        return this;
    }

    /// <summary>
    /// Set <see cref="MangaListStatus.NumChaptersRead"/> field.
    /// </summary>
    public MyMangaListStatusBuilder SetNumChaptersRead(int numChaptersRead)
    {
        if (numChaptersRead < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numChaptersRead), "Cannot be negative.");
        }
        _fields["num_chapters_read"] = numChaptersRead.ToString();
        return this;
    }

    /// <summary>
    /// Set <see cref="MangaListStatus.Priority"/> field.
    /// </summary>
    /// <param name="priority">Value between 0 and 2.</param>

    public MyMangaListStatusBuilder SetPriority(int priority)
    {
        if (priority is < 0 or > 2)
        {
            throw new ArgumentOutOfRangeException(nameof(priority), "Priority value must be between 0 and 2.");
        }
        _fields["priority"] = priority.ToString();
        return this;
    }

    /// <summary>
    /// Set <see cref="MangaListStatus.NumTimesReread"/> field.
    /// </summary>
    public MyMangaListStatusBuilder SetNumTimesReread(int numTimesReread)
    {
        if (numTimesReread < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numTimesReread), "Cannot be negative.");
        }
        _fields["num_times_reread"] = numTimesReread.ToString();
        return this;
    }

    /// <summary>
    /// Set <see cref="MangaListStatus.RereadValue"/> field.
    /// </summary>
    /// <param name="rereadValue">Value beteen 0 and 5.</param>
    public MyMangaListStatusBuilder SetRereadValue(int rereadValue)
    {
        if (rereadValue is < 0 or > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(rereadValue), "Rewatch value value must be between 0 and 5.");
        }
        _fields["reread_value"] = rereadValue.ToString();
        return this;
    }

    /// <summary>
    /// Set <see cref="MangaListStatus.Tags"/> field.
    /// </summary>
    public MyMangaListStatusBuilder SetTags(string tags)
    {
        if (tags is null)
        {
            throw new ArgumentNullException(nameof(tags), "Tags cannot be null.");
        }
        _fields["tags"] = tags;
        return this;
    }

    /// <summary>
    /// Set <see cref="MangaListStatus.Comments"/> field.
    /// </summary>
    public MyMangaListStatusBuilder SetComments(string comments)
    {
        if (comments is null)
        {
            throw new ArgumentNullException(nameof(comments), "Comments cannot be null.");
        }
        _fields["comments"] = comments;
        return this;
    }
}
