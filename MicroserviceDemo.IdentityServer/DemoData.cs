using IdentityServer4.Models;
using System.Collections.Generic;

namespace MicroserviceDemo.IdentityServer
{
    public static class DemoData
    {
        public static IEnumerable<ApiResource> Apis
            => new List<ApiResource>();

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
                        ClientId = "implicit",
                        ClientName = "Implicit Client",
                        AllowAccessTokensViaBrowser = true,

                        RedirectUris = { "http://localhost:5001/signin-idsrv" },
                        PostLogoutRedirectUris = { "http://localhost:5001/signout-callback-idsrv" },
                        FrontChannelLogoutUri = "http://localhost:5001/signout-idsrv",

                        AllowedGrantTypes = GrantTypes.Implicit,
                        AllowedScopes = { "openid", "profile", "email", "api" },
                    },
            };
    }
}
