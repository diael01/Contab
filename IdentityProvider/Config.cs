using Duende.IdentityModel;
using Duende.IdentityServer.Models;

namespace Globomantics.Idp;

public static class Config
{

    public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                 new IdentityResource("Contab", new [] { JwtClaimTypes.Role })
                //new IdentityResource(name: "roles",
                //    userClaims: new[] { "role" }, displayName: "Your roles")
            };



    public static IEnumerable<ApiResource> ApiResources =>
    new ApiResource[]
    {
            new ApiResource("ContabApi")
            {
                Scopes = { "ContabApi_fullaccess"},
                ApiSecrets = { new Secret("secret".Sha256()) },
            }
    };

    public static IEnumerable<ApiScope> ApiScopes =>
       new ApiScope[]
       {
                //new ApiScope("ContabApi_fullaccess", "Basic access to Contab API"),
                new ApiScope("ContabApi_fullaccess") { UserClaims = new[] {JwtClaimTypes.Email, JwtClaimTypes.Role } }
       };


    public static IEnumerable<Client> Clients =>
        new Client[]
        {

            new Client
            {
                ClientId = "ContabApi.client",
                ClientName = "Contab Api",
                 AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                    //new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256())
                },
                 AllowedScopes =
                {
                    "ContabApi_fullaccess"
                },
                Claims = new ClientClaim[]
                {
                    new ClientClaim("ClientType", "ContabApi")
                }
            
            //RequireConsent = false,
            //RedirectUris = {"https://localhost:4001/signin-oidc"},
            //PostLogoutRedirectUris = {"https://localhost:4001"},
            //AlwaysIncludeUserClaimsInIdToken = true,

            //RequirePkce = true,
            //AllowOfflineAccess = false,
            //AccessTokenLifetime = 7200,
            //Enabled = true //if we wish we can disable it
        },
       

            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "interactive",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:7113/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:7113/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:7113/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AbsoluteRefreshTokenLifetime = 2592000, // 30 days
                SlidingRefreshTokenLifetime = 1209600, // 14 days

                Claims = new ClientClaim[]
                {
                    new ClientClaim("clienttype", "interactive")
                },

                AllowedScopes = { "openid", "profile", "Contab",
                    "ContabApi_fullaccess", "ContabAuthorization" },
            },
        };
}
