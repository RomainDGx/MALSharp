using MALSharp.Models.Shared;
using System;

namespace MALSharp.Client.Tests;

internal static class Generator
{
    public static string GetGuid() => Guid.NewGuid().ToString();
}
