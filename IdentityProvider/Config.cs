// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Duende.IdentityServer.Models;

namespace IdentityProvider
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource(name: "roles",
                    userClaims: new[] { "role" }, displayName: "Your roles")
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("ContabApi.basicAccess", "Basic access to Contab API")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource
                {
                    Name = "ContabApi",
                    Description = "Contab API",
                    Scopes = new List<string> {"ContabApi.basicAccess" },
                    UserClaims = new[] { "role" }
                }

            };

        //    public static IEnumerable<Client> Clients =>
        //        new Client[]
        //        {
        //            // interactive client using code flow + pkce
        //            new Client
        //            {
        //                ClientId = "ContabApi",
        //                ClientName = "Contab Api",
        //                RequireConsent = false,

        //                ClientSecrets =
        //                {
        //                    new Secret("secret".Sha256())
        //                },

        //                RedirectUris = {"https://localhost:4001/signin-oidc"},
        //                PostLogoutRedirectUris = {"https://localhost:4001"},

        //                AllowedScopes =
        //                {
        //                    "openid",
        //                    "roles",
        //                    "profile",
        //                    "ContabApi.basicAccess",
        //                },

        //                AlwaysIncludeUserClaimsInIdToken = true,
        //                AllowedGrantTypes = GrantTypes.Code,
        //                RequirePkce = true,
        //                AllowOfflineAccess = true
        //            },
        //        };

        public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // m2mclient credentials
            //for now this is client which is Contab API
         
            new Client
            {
                ClientId = "ContabApi",
                ClientName = "Contab Api",
                RequireConsent = false,

                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },

                RedirectUris = {"https://localhost:4001/signin-oidc"},
                PostLogoutRedirectUris = {"https://localhost:4001"},

                AllowedScopes =
                {
                    "ContabApi.basicAccess",
                },

                AlwaysIncludeUserClaimsInIdToken = true,
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                RequirePkce = true,
                AllowOfflineAccess = false,
                AccessTokenLifetime = 7200,
                Enabled = true //if we wish we can disable it
            },
       

         // interactive client using code flow + pkce
         //this will be via UI OIDC
        //new Client
        //{
        //    Enabled = false, //for now
        //    ClientId = "interactive",
        //    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },
        //    AllowedGrantTypes = GrantTypes.Code,
        //    RequirePkce = true,

        //    //todo: change the urls when ui is implemented
        //    RedirectUris = { "https://localhost:7113/signin-oidc" },
        //    FrontChannelLogoutUri = "https://localhost:7113/signout-oidc",
        //    PostLogoutRedirectUris = { "https://localhost:7113/signout-callback-oidc" },

        //    AllowOfflineAccess = false,
        //    AbsoluteRefreshTokenLifetime = 2592000, // 30 days
        //    SlidingRefreshTokenLifetime = 1209600, // 14 days

        //    Claims = new ClientClaim[]
        //    {
        //        new ClientClaim("clienttype", "interactive")
        //    },

        //    AllowedScopes = {
        //            "openid",
        //            "roles",
        //            "profile",
        //            "ContabApi.basicAccess" },
        //},
      };

    }
}

