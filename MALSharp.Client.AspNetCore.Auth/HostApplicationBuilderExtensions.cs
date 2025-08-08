using MALSharp.Client.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MALSharp.Client.AspNetCore.Auth;

public static class HostApplicationBuilderExtensions
{
    public static IHostBuilder UseMALClientAuth(this IHostBuilder builder)
    {
        builder.UseMALClient(s => new HttpContextAccessTokenProvider(s.GetRequiredService<IHttpContextAccessor>()))
               .ConfigureServices(services => services.AddHttpContextAccessor());

        return builder;
    }

    public static T UseMALClientAuth<T>(this T builder) where T : IHostApplicationBuilder
    {
        builder.UseMALClient(s => new HttpContextAccessTokenProvider(s.GetRequiredService<IHttpContextAccessor>()))
               .Services.AddHttpContextAccessor();

        return builder;
    } 
}
