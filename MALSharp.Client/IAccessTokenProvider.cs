using System.Threading;
using System.Threading.Tasks;

namespace MALSharp.Client;

public interface IAccessTokenProvider
{
    Task<string?> GetAccessTokenAsync(CancellationToken token = default);
}
