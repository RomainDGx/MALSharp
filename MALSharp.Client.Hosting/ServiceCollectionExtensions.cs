using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;

namespace MALSharp.Client.Hosting;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers an <see cref="IMALClient"/> without any access token provider.
    /// This method is intended for unauthenticated use to access public endpoints of the MyAnimeList API.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The enriched <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddMALClient(this IServiceCollection services)
    {
        return services.AddMALClient(_ => { });
    }

    /// <summary>
    /// Registers an <see cref="IMALClient"/> with a custom access token provider.
    /// This method allows authenticated access to the MyAnimeList API using OAuth2.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="accessTokenProviderFactory">
    /// A factory delegate used to resolve an <see cref="IAccessTokenProvider"/> instance
    /// responsible for supplying valid access tokens for authenticated requests.
    /// </param>
    /// <returns>The enriched <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddMALClient(this IServiceCollection services,
                                                  Func<IServiceProvider, IAccessTokenProvider> accessTokenProviderFactory)
    {
        return services.AddMALClient(_ => { }, accessTokenProviderFactory);
    }

    /// <summary>
    /// Registers an <see cref="IMALClient"/> without any access token provider.
    /// This method is intended for unauthenticated use to access public endpoints of the MyAnimeList API.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configureOptions">The delegate used to configure <see cref="MALClientOptions"/>.</param>
    /// <returns>The enriched <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddMALClient(this IServiceCollection services,
                                                  Action<MALClientOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);

        return services.Configure(configureOptions)
                       .AddMALHttpClient()
                       .AddScoped<IMALClient>(provider => CreateMALClient(provider, false));
    }

    /// <summary>
    /// Registers an <see cref="IMALClient"/> with a custom access token provider.
    /// This method allows authenticated access to the MyAnimeList API using OAuth2.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configureOptions">The delegate used to configure <see cref="MALClientOptions"/>.</param>
    /// <param name="accessTokenProviderFactory">
    /// A factory delegate used to resolve an <see cref="IAccessTokenProvider"/> instance
    /// responsible for supplying valid access tokens for authenticated requests.
    /// </param>
    /// <returns>The enriched <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddMALClient(this IServiceCollection services,
                                                  Action<MALClientOptions> configureOptions,
                                                  Func<IServiceProvider, IAccessTokenProvider> accessTokenProviderFactory)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);
        ArgumentNullException.ThrowIfNull(accessTokenProviderFactory);

        return services.Configure(configureOptions)
                       .AddMALHttpClient()
                       .AddScoped(accessTokenProviderFactory)
                       .AddScoped<IMALClient>(provider => CreateMALClient(provider, true));
    }

    static IServiceCollection AddMALHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient("MALSharp", (provider, client) =>
        {
            var options = provider.GetRequiredService<IOptions<MALClientOptions>>().Value;
            client.BaseAddress = new Uri(options.BaseUrl);
            client.Timeout = options.Timeout;
            client.DefaultRequestHeaders.Add("X-MAL-CLIENT-ID", options.ClientId);
        });

        return services;
    }

    static MALClient CreateMALClient(IServiceProvider provider, bool withAccessToken)
    {
        var options = provider.GetRequiredService<IOptions<MALClientOptions>>().Value;

        var httpClient = provider.GetRequiredService<IHttpClientFactory>().CreateClient("MALSharp");

        var accessTokenProvider = withAccessToken
            ? provider.GetRequiredService<IAccessTokenProvider>()
            : null;

        var logger = provider.GetService<ILogger<MALClient>>();

        if (accessTokenProvider is not null && logger is not null)
        {
            return new MALClient(options, httpClient, accessTokenProvider, logger);
        }
        else if (accessTokenProvider is not null)
        {
            return new MALClient(options, httpClient, accessTokenProvider);
        }
        else if (logger is not null)
        {
            return new MALClient(options, httpClient, logger);
        }

        return new MALClient(options, httpClient);
    }
}
