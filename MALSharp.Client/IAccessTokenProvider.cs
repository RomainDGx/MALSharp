using System.Threading;
using System.Threading.Tasks;

namespace MALSharp.Client;

/// <summary>
/// Provides access tokens for authenticating HTTP requests to the MyAnimeList API.
/// </summary>
public interface IAccessTokenProvider
{
    /// <summary>
    /// Retrieves a valid access token for the current context.
    /// </summary>
    /// <param name="token">A token to cancel the operation.</param>
    /// <returns>
    /// The result contains the access token string,
    /// or <c>null</c> if no token is available in the current context.
    /// </returns>
    Task<string?> GetAccessTokenAsync(CancellationToken token = default);

    /// <summary>
    /// Refreshes the access token for the current context.
    /// </summary>
    /// <param name="token">A token to cancel the operation.</param>
    /// <returns>
    /// The result is <c>true</c> if the refresh succeeded and a new access token was obtained,
    /// or <c>false</c> if the refresh failed.
    /// </returns>
    Task<bool> RefreshAccessTokenAsync(CancellationToken token = default);
}
