using MALSharp.Client.User;
using MALSharp.Models.User;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MALSharp.Client;

public partial class MALClient
{
    public Task<UserInformation> GetMyUserInformationsAsync(UserInformationFieldsBuilder? fields = null,
                                                            CancellationToken token = default)
    {
        var uri = new MALUriBuilder("users/@me")
            .AddFields(fields, _options.ExplicitFields)
            .Build();

        return ExecuteRequestAsync<UserInformation>(HttpMethod.Get, uri, token);
    }
}
