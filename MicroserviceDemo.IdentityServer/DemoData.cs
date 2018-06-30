using IdentityServer4.Models;
using System.Collections.Generic;

namespace MicroserviceDemo.IdentityServer
{
    public static class DemoData
    {
        public static IEnumerable<ApiResource> Apis
            => new List<ApiResource>
            {
                new ApiResource("hello_api", "Hello API")
                {
                    ApiSecrets = { new Secret("secret".Sha256()) }
                }
            };

        public static IEnumerable<IdentityResource> IdentityResources
            => new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };
        public static IEnumerable<Client> Clients
            => new List<Client>
            {
                new Client
                {
                    ClientId = "implicit.shortlived",
                    ClientName = "Demo SPA Client",
                    AllowAccessTokensViaBrowser = true,
                    AllowedCorsOrigins = { "http://localhost:5005" },

                    AccessTokenLifetime = 70,

                    RedirectUris = { "http://localhost:5005" },
                    PostLogoutRedirectUris = { "https://notused" },

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "openid", "profile", "email", "hello_api" },
                }
            };
    }
}
