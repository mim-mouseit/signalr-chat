using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrWebApplication_lastexam.Configurations
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email()
            };

        public static IEnumerable<ApiScope> GetScopes =>
            new List<ApiScope>
            {
                new ApiScope("api.WebApp", "WebApp API")
            };

        public static IEnumerable<ApiResource> GetApiResources =>
            new List<ApiResource>
            {
                new ApiResource("api.WebApp", "WebApp API")
            };

        public static IEnumerable<Client> GetClients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "WebApp",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = true,
                    RequirePkce = true,
                    AllowOfflineAccess = true,
                    AllowedCorsOrigins = {"https://localhost"},

                    RedirectUris = { "https://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = {"https://localhost:5002/signout-callback-oidc"},

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "api.WebApp"
                    }
                },
                new Client
                {
                    ClientId = "swagger",
                    ClientName = "Swagger Client",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,

                    RedirectUris = {"https://localhost:5000/swagger/oauth2-redirect.html"},
                    PostLogoutRedirectUris = {"https://localhost:5000/swagger/oauth2-redirect.htlm"},
                    AllowedCorsOrigins = {"https://localhost:5000"},

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api.WebApp"
                    }
                }
            };
    }
}
