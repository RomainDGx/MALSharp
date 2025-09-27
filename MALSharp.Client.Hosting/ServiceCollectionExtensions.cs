using Microsoft.Extensions.DependencyInjection;
using System;

namespace MALSharp.Client.Hosting;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers <see cref="MALClient"/> as <see cref="IMALClient"/> into the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The enriched <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddMALClient(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        return services.AddSingleton(_ => new MALClientOptions())
                       .AddScoped<IMALClient, MALClient>();
    }

    /// <summary>
    /// Registers <see cref="MALClient"/> as <see cref="IMALClient"/> into the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configureOptions">The delegate used to configure <see cref="MALClientOptions"/>.</param>
    /// <returns>The enriched <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddMALClient(this IServiceCollection services, Action<MALClientOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);

        return services.AddSingleton(_ =>
                       {
                           var options = new MALClientOptions();
                           configureOptions(options);
                           return options;
                       })
                       .AddScoped<IMALClient, MALClient>();
    }
}
