using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace MALSharp.Client.AspNetCore.Auth;

public static class AuthenticationBuilderExtensions
{
    public static AuthenticationBuilder AddMyAnimeListAuth(this IServiceCollection services, Action<OAuthOptions> configureOptions)
    {
        return services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = MALAuthDefaults.AuthenticationScheme;
        })
        .AddCookie(options =>
        {
            options.Cookie.SameSite = SameSiteMode.None;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        })
        .AddMyAnimeListAuth(configureOptions);
    }

    public static AuthenticationBuilder AddMyAnimeListAuth(this AuthenticationBuilder builder, Action<OAuthOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(configureOptions);

        return builder.AddOAuth(MALAuthDefaults.AuthenticationScheme, MALAuthDefaults.DisplayName, options =>
        {
            options.CallbackPath = "/signin-myanimelist";

            options.AuthorizationEndpoint = MALAuthDefaults.AuthorizationEndpoint;
            options.TokenEndpoint = MALAuthDefaults.TokenEndpoint;
            options.UserInformationEndpoint = MALAuthDefaults.UserInformationsEndpoint;

            options.Scope.Add("write:users");

            options.SaveTokens = true;
            options.UsePkce = true;

            options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");

            options.Events = new OAuthEvents
            {
                OnRedirectToAuthorizationEndpoint = ctx =>
                {
                    var redirectUri = ctx.RedirectUri;
                    if (ctx.Properties.Items.TryGetValue("code_verifier", out var codeVerifier))
                    {
                        redirectUri = QueryHelpers.AddQueryString(redirectUri, new Dictionary<string, string?>
                        {
                            ["code_challenge"] = codeVerifier,
                            ["code_challenge_method"] = "plain" // Use plain method due to MAL OAuth2 implementation.
                        });
                    }
                    ctx.Response.Redirect(redirectUri);
                    return Task.CompletedTask;
                },
                OnCreatingTicket = async ctx =>
                {
                    using var req = new HttpRequestMessage(HttpMethod.Get, ctx.Options.UserInformationEndpoint);
                    req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", ctx.AccessToken);

                    using var res = await ctx.Backchannel.SendAsync(req).ConfigureAwait(false);
                    res.EnsureSuccessStatusCode();

                    using var stream = await res.Content.ReadAsStreamAsync().ConfigureAwait(false);
                    var token = await JsonDocument.ParseAsync(stream).ConfigureAwait(false);
                    ctx.RunClaimActions(token.RootElement);
                }
            };

            configureOptions(options);
        });
    }
}
