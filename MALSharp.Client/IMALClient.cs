using MALSharp.Client.User;
using MALSharp.Models.User;
using System.Threading;
using System.Threading.Tasks;

namespace MALSharp.Client;

public interface IMALClient
{
    #region User
    Task<UserInformation> GetMyUserInformationsAsync(UserInformationFieldsBuilder? fields = null,
                                                     CancellationToken token = default);
    #endregion
}
