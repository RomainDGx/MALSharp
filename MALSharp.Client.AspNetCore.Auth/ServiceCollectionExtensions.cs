using MALSharp.Client.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MALSharp.Client.AspNetCore.Auth;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMALClientAuth(this IServiceCollection services)
    {
        return services.AddMALClientAuth(_ => { });
    }

    public static IServiceCollection AddMALClientAuth(this IServiceCollection services, Action<MALClientOptions> configureOptions)
    {
        return services.AddMALClient(configureOptions, s => new HttpContextAccessTokenProvider(s.GetRequiredService<IHttpContextAccessor>()))
                       .AddHttpContextAccessor();
    }
}
