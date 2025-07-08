using System;
using System.Text.Encodings.Web;

namespace MALSharp.Client;

/// <summary>
/// Provides options to be used with <see cref="MALClient"/>.
/// </summary>
public class MALClientOptions
{
    /// <summary>
    /// Defines the minimum delay between two consecutive API requests performed by the client,
    /// to respect MyAnimeList rate limits and avoid being temporarily blocked when fetching paginated results.
    /// </summary>
    public TimeSpan InterRequestDelay { get; set; } = TimeSpan.FromMilliseconds(500);

    /// <summary>
    /// Defines the <see cref="System.Text.Encodings.Web.JavaScriptEncoder"/> used when serializing the client’s models back to JSON.
    /// This controls how characters such as HTML tags or non-ASCII symbols are escaped.
    /// Does not affect deserialization of incoming JSON.
    /// </summary>
    public JavaScriptEncoder JavaScriptEncoder { get; set; } = JavaScriptEncoder.Default;

    /// <summary>
    /// If true, the client will explicitly include all requested fields in the API request URL,
    /// making it clear which data will be retrieved, even for fields that MyAnimeList returns by default.
    /// </summary>
    public bool ExplicitFields { get; set; } = false;
}
