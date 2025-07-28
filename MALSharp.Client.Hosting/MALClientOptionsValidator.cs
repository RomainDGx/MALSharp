using Microsoft.Extensions.Options;

namespace MALSharp.Client.Hosting;

class MALClientOptionsValidator : IValidateOptions<MALClientOptions>
{
    public ValidateOptionsResult Validate(string? name, MALClientOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.ClientId))
        {
            return ValidateOptionsResult.Fail("Missing or empty value for MALClient:ClientId from configuration.");
        }
        if (string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            return ValidateOptionsResult.Fail("Missing or empty value for MALClient:BaseUrl from configuration.");
        }
        return ValidateOptionsResult.Success;
    }
}
