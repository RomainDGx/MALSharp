using System.Threading;
using System.Threading.Tasks;

namespace MALSharp.Client.TestUtils;

public class FakeAccessTokenProvider : IAccessTokenProvider
{
    readonly string _accessToken;

    public FakeAccessTokenProvider(string accessToken)
    {
        _accessToken = accessToken;
    }

    public Task<string?> GetAccessTokenAsync(CancellationToken token = default)
    {
        return Task.FromResult<string?>(_accessToken);
    }
}
