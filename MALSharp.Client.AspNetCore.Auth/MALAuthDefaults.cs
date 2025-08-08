namespace MALSharp.Client.AspNetCore.Auth;

public class MALAuthDefaults
{
    public const string AuthenticationScheme = "MyAnimeList";
    public const string DisplayName = "MyAnimeList";

    public const string AuthorizationEndpoint = "https://myanimelist.net/v1/oauth2/authorize";
    public const string TokenEndpoint = "https://myanimelist.net/v1/oauth2/token";

    public const string UserInformationsEndpoint = "https://api.myanimelist.net/v2/users/@me";
}
