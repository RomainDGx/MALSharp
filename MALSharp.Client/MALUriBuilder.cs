using MALSharp.Models.Anime;
using MALSharp.Models.Manga;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MALSharp.Client;

internal class MALUriBuilder
{
    readonly string _path;
    readonly Dictionary<string, string> _parameters;
    int _limitMaxValue;

    internal MALUriBuilder(string path)
    {
        _parameters = [];
        _path = path;
    }

    internal MALUriBuilder AddLimit(int limit, int maxValue)
    {
        if (limit <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Limit cannot be negative or zero.");
        }
        _limitMaxValue = maxValue;
        _parameters.Add("limit", int.Min(limit, maxValue).ToString());
        return this;
    }

    internal MALUriBuilder SetLimit(int limit)
    {
        if (limit <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Limit cannot be negative or zero.");
        }
        _parameters["limit"] = int.Min(limit, _limitMaxValue).ToString();
        return this;
    }

    internal MALUriBuilder SetOffset(int offset)
    {
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(offset), "Offset cannot be negative.");
        }
        if (_parameters.ContainsKey("offset"))
        {
            _parameters["offset"] = offset.ToString();
            return this;
        }
        _parameters.Add("offset", offset.ToString());
        return this;
    }

    internal MALUriBuilder AddNsfw(bool nsfw)
    {
        _parameters.Add("nsfw", nsfw.ToString().ToLower());
        return this;
    }

    internal MALUriBuilder AddFields<T>(T? builder, bool explicitFields) where T : IFieldsBuilder, new()
    {
        if ((builder is not null && !builder.IsEmpty) || explicitFields)
        {
            builder ??= new();
            _parameters.Add("fields", builder.Build(explicitFields));
        }
        return this;
    }

    internal MALUriBuilder Add(string key, string value)
    {
        if (string.IsNullOrEmpty(key = key.Trim()))
        {
            throw new ArgumentException("String query key cannot be empty.");
        }
        if (string.IsNullOrEmpty(value = value.Trim()))
        {
            throw new ArgumentException("String query value cannot be empty.");
        }
        _parameters.Add(key, value);
        return this;
    }

    internal MALUriBuilder AddWatchingStatus(WatchingStatus? status)
    {
        if (status.HasValue)
        {
            Add("status", status.Value switch
            {
                WatchingStatus.Watching => "watching",
                WatchingStatus.Completed => "completed",
                WatchingStatus.OnHold => "on_hold",
                WatchingStatus.Dropped => "dropped",
                WatchingStatus.PlanToWatch => "plan_to_watch",
                _ => throw new InvalidEnumArgumentException(nameof(status), (int)status, typeof(WatchingStatus))
            });
        }
        return this;
    }

    internal MALUriBuilder AddReadingStatus(ReadingStatus? status)
    {
        if (status.HasValue)
        {
            Add("status", status.Value switch
            {
                ReadingStatus.Reading => "reading",
                ReadingStatus.Completed => "completed",
                ReadingStatus.OnHold => "on_hold",
                ReadingStatus.Dropped => "dropped",
                ReadingStatus.PlanToRead => "plan_to_read",
                _ => throw new InvalidEnumArgumentException(nameof(status), (int)status, typeof(ReadingStatus))
            });
        }
        return this;
    }

    internal string Build()
    {
        var builder = new StringBuilder(_path);
        var first = true;

        foreach (var field in _parameters)
        {
            builder.Append(first ? '?' : '&')
                   .Append(Uri.EscapeDataString(field.Key))
                   .Append('=')
                   .Append(Uri.EscapeDataString(field.Value));

            first = false;
        }
        return builder.ToString();
    }
}
