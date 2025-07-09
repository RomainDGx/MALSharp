using MALSharp.Models.Anime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MALSharp.Client;

internal class MALUriBuilder
{
    readonly string _path;
    readonly Dictionary<string, string> _parameters;

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
        _parameters.Add("limit", int.Min(limit, maxValue).ToString());
        return this;
    }

    internal MALUriBuilder AddOffset(int offset)
    {
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(offset), "Offset cannot be negative.");
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
