using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;

namespace MALSharp.Client.Hosting;

public static class HostApplicationBuilderExtensions
{
    /// <summary>
    /// Configures and registers an <see cref="IMALClient"/> for unauthenticated access,
    /// using the <c>MALClient</c> section from the application configuration.
    /// </summary>
    /// <param name="builder">The <see cref="IHostBuilder"/> instance.</param>
    /// <returns>The same <see cref="IHostBuilder"/> instance for chaining.</returns>
    public static IHostBuilder UseMALClient(this IHostBuilder builder)
    {
        builder.ConfigureServices((ctx, services) =>
        {
            services.AddSingleton<IValidateOptions<MALClientOptions>, MALClientOptionsValidator>()
                    .Configure<MALClientOptions>(ctx.Configuration.GetSection("MALClient"))
                    .AddMALClient();
        });
        return builder;
    }

    /// <summary>
    /// Configures and registers an <see cref="IMALClient"/> for authenticated access,
    /// using the <c>MALClient</c> section from the application configuration and a custom <see cref="IAccessTokenProvider"/>.
    /// </summary>
    /// <param name="builder">The <see cref="IHostBuilder"/> instance.</param>
    /// <param name="accessTokenProviderFactory">
    /// A factory function used to resolve an <see cref="IAccessTokenProvider"/> for authenticated requests.
    /// </param>
    /// <returns>The same <see cref="IHostBuilder"/> instance for chaining.</returns>
    public static IHostBuilder UseMALClient(this IHostBuilder builder,
                                            Func<IServiceProvider, IAccessTokenProvider> accessTokenProviderFactory)
    {
        builder.ConfigureServices((ctx, services) =>
        {
            services.AddSingleton<IValidateOptions<MALClientOptions>, MALClientOptionsValidator>()
                    .Configure<MALClientOptions>(ctx.Configuration.GetSection("MALClient"))
                    .AddMALClient(accessTokenProviderFactory);
        });
        return builder;
    }

    /// <summary>
    /// Configures and registers an <see cref="IMALClient"/> for unauthenticated access,
    /// using the <c>MALClient</c> section from the application configuration.
    /// Intended for use with minimal hosting APIs.
    /// </summary>
    /// <typeparam name="T">A builder type implementing <see cref="IHostApplicationBuilder"/>.</typeparam>
    /// <param name="builder">The builder instance.</param>
    /// <returns>The same builder instance for chaining.</returns>
    public static T UseMALClient<T>(this T builder) where T : IHostApplicationBuilder
    {
        builder.Services.AddSingleton<IValidateOptions<MALClientOptions>, MALClientOptionsValidator>()
                        .Configure<MALClientOptions>(builder.Configuration.GetSection("MALClient"))
                        .AddMALClient();

        return builder;
    }

    /// <summary>
    /// Configures and registers an <see cref="IMALClient"/> for authenticated access,
    /// using the <c>MALClient</c> section from the application configuration and a custom <see cref="IAccessTokenProvider"/>.
    /// Intended for use with minimal hosting APIs.
    /// </summary>
    /// <typeparam name="T">A builder type implementing <see cref="IHostApplicationBuilder"/>.</typeparam>
    /// <param name="builder">The builder instance.</param>
    /// <param name="accessTokenProviderFactory">
    /// A factory function used to resolve an <see cref="IAccessTokenProvider"/> for authenticated requests.
    /// </param>
    /// <returns>The same builder instance for chaining.</returns>
    public static T UseMALClient<T>(this T builder,
                                    Func<IServiceProvider, IAccessTokenProvider> accessTokenProviderFactory) where T : IHostApplicationBuilder
    {
        builder.Services.AddSingleton<IValidateOptions<MALClientOptions>, MALClientOptionsValidator>()
                        .Configure<MALClientOptions>(builder.Configuration.GetSection("MALClient"))
                        .AddMALClient(accessTokenProviderFactory);

        return builder;
    }
}
