using System.Threading;
using System.Threading.Tasks;

namespace MALSharp.Client;

/// <summary>
/// Provides access tokens for authenticating HTTP requests to the MyAnimeList API.
/// </summary>
public interface IAccessTokenProvider
{
    /// <summary>
    /// Asynchronously retrieves a valid access token for the current context.
    /// </summary>
    /// <param name="token">A token to cancel the operation.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The result contains the access token string,
    /// or <c>null</c> if no token is available in the current context.
    /// </returns>
    Task<string?> GetAccessTokenAsync(CancellationToken token = default);
}
