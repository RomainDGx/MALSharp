using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MALSharp.Client.Hosting;

public static class HostApplicationBuilderExtensions
{
    /// <summary>
    /// Configures and registers <see cref="MALClient"/> as <see cref="IMALClient"/> into the <see cref="IServiceCollection"/>.
    /// Using the <c>MALClient</c> section from the application configuration.
    /// </summary>
    /// <param name="builder">The <see cref="IHostBuilder"/> instance.</param>
    /// <returns>The same <see cref="IHostBuilder"/> instance for chaining.</returns>
    public static IHostBuilder UseMALClient(this IHostBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ConfigureServices((ctx, services) =>
        {
            services.AddMALClient(options =>
            {
                ApplyConfiguration(ctx.Configuration, options);
            });
        });
        return builder;
    }

    /// <summary>
    /// Configures and registers <see cref="MALClient"/> as <see cref="IMALClient"/> into the <see cref="IServiceCollection"/>.
    /// Using the <c>MALClient</c> section from the application configuration.
    /// </summary>
    /// <param name="builder">The <see cref="IHostBuilder"/> instance.</param>
    /// <param name="configureOptions">The delegate used to configure <see cref="MALClientOptions"/>.</param>
    /// <returns>The same <see cref="IHostBuilder"/> instance for chaining.</returns>
    public static IHostBuilder UseMALClient(this IHostBuilder builder, Action<MALClientOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(configureOptions);

        builder.ConfigureServices((ctx, services) =>
        {
            services.AddMALClient(options =>
            {
                ApplyConfiguration(ctx.Configuration, options);
                configureOptions(options);
            });
        });
        return builder;
    }

    /// <summary>
    /// Configures and registers <see cref="MALClient"/> as <see cref="IMALClient"/> into the <see cref="IServiceCollection"/>.
    /// Using the <c>MALClient</c> section from the application configuration.
    /// Intended for use with minimal hosting APIs.
    /// </summary>
    /// <typeparam name="T">A builder type implementing <see cref="IHostApplicationBuilder"/>.</typeparam>
    /// <param name="builder">The builder instance.</param>
    /// <returns>The same builder instance for chaining.</returns>
    public static T UseMALClient<T>(this T builder) where T : IHostApplicationBuilder
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.AddMALClient(options =>
        {
            ApplyConfiguration(builder.Configuration, options);
        });

        return builder;
    }

    /// <summary>
    /// Configures and registers <see cref="MALClient"/> as <see cref="IMALClient"/> into the <see cref="IServiceCollection"/>.
    /// Using the <c>MALClient</c> section from the application configuration.
    /// Intended for use with minimal hosting APIs.
    /// </summary>
    /// <typeparam name="T">A builder type implementing <see cref="IHostApplicationBuilder"/>.</typeparam>
    /// <param name="builder">The builder instance.</param>
    /// <param name="configureOptions">The delegate used to configure <see cref="MALClientOptions"/>.</param>
    /// <returns>The same builder instance for chaining.</returns>
    public static T UseMALClient<T>(this T builder, Action<MALClientOptions> configureOptions) where T : IHostApplicationBuilder
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(configureOptions);

        builder.Services.AddMALClient(options =>
        {
            ApplyConfiguration(builder.Configuration, options);
            configureOptions(options);
        });

        return builder;
    }

    static void ApplyConfiguration(IConfiguration config, MALClientOptions options)
    {
        var section = config.GetSection("MALClient");
        if (section is null)
        {
            return;
        }

        var strInterRequestDelay = section["InterRequestDelay"];
        if (strInterRequestDelay is not null)
        {
            if (!TimeSpan.TryParse(section["InterRequestDelay"], out var interRequestDelay))
            {
                throw new ArgumentException("Invalid value for MALClient:InterRequestDelay in configuration.");
            }
            options.InterRequestDelay = interRequestDelay;
        }

        var strExplicitFields = section["ExplicitFields"];
        if (strExplicitFields is not null)
        {
            if (!bool.TryParse(strExplicitFields, out var explicitFields))
            {
                throw new ArgumentException("Invalid value for MALClient:ExplicitFields in configuration.");
            }
            options.ExplicitFields = explicitFields;
        }

        var clientId = section["ClientId"];
        if (clientId is not null)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentException("Invalid value for MALClient:ClientId in configuration.");
            }
            options.ClientId = clientId;
        }

        var clientSecret = section["ClientSecret"];
        if (clientSecret is not null)
        {
            if (string.IsNullOrWhiteSpace(clientSecret))
            {
                throw new ArgumentException("Invalid value for MALClient:ClientSecret in configuration.");
            }
            options.ClientSecret = clientSecret;
        }

        var baseUrl = section["BaseUrl"];
        if (baseUrl is not null)
        {
            if (!Uri.IsWellFormedUriString(baseUrl, UriKind.Absolute))
            {
                throw new ArgumentException("Invalid value for MALClient:BaseUrl from configuration.");
            }
            options.BaseUrl = baseUrl;
        }

        var strTimeout = section["Timeout"];
        if (strTimeout is not null)
        {
            if (!TimeSpan.TryParse(strTimeout, out var timeout))
            {
                throw new ArgumentException("Invalid value for MALClient:Timeout from configuration.");
            }
            options.Timeout = timeout;
        }
    }
}
