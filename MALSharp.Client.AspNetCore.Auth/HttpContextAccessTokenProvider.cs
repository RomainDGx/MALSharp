using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MALSharp.Client.AspNetCore.Auth;

internal class HttpContextAccessTokenProvider : IAccessTokenProvider
{
    readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextAccessTokenProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<string?> GetAccessTokenAsync(CancellationToken token = default)
    {
        var ctx = _httpContextAccessor.HttpContext;
        if (ctx is null || ctx.User.Identity?.IsAuthenticated is not true)
        {
            return null;
        }

        var accessToken = await ctx.GetTokenAsync("access_token").ConfigureAwait(false);

        return string.IsNullOrWhiteSpace(accessToken)
            ? null
            : accessToken;
    }
}
