using System;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Identity.Service.Auth
{
    public static class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new()
                {
                    ClientId = "user.api.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AccessTokenLifetime = 36000,
                    IdentityTokenLifetime = 36000,
                    AllowOfflineAccess = true,
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    AllowedScopes = { "user.api.scope" },
                    UpdateAccessTokenClaimsOnRefresh = true,
                    ClientSecrets = { new Secret("user.api.secret".Sha256()) },
                }
            };
        }

        public static IEnumerable<ApiResource> GetResources()
        {
            return new List<ApiResource>
            {
                new("user.api.resource") { Scopes = { "user.api.scope" } },
            };
        }

        public static IEnumerable<ApiScope> GetScopes()
        {
            return new List<ApiScope>
            {
                new("user.api.scope"),
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new()
            {
                new TestUser()
                {
                    Username = "superUser",
                    Password = "superPassword",
                    IsActive = true,
                    SubjectId = Guid.Parse("a78f94cd-32e8-499f-8574-66073e1f8616").ToString(),
                    Claims = new List<Claim>
                    {
                        new("birthDate", DateTime.Now.ToShortDateString()),
                        new("age", "30")
                    }
                }
            };
        }
    }
}