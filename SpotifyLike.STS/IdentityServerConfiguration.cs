using IdentityServer4.Models;
using IdentityServer4;

namespace SpotifyLike.STS
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<IdentityResource> GetIdentityResource()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResource()
        {
            return new List<ApiResource>()
            {
                new ApiResource("Streaming-api", "Streaming", new String[] { "streaming-user" })
                {
                    ApiSecrets =
                    {
                        new Secret("StreamingSecret".Sha256())
                    },
                    Scopes =
                    {
                        "StreamingScope"
                    }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope()
                {
                    Name = "StreamingScope",
                    DisplayName = "Streaming API",
                    UserClaims = { "Streaming-user" }
                }
            };
        }

        public static IEnumerable<Client>GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "client-angular-Streaming",
                    ClientName = "Acesso do front as APIS",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("StreamingSecret".Sha256())
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "StreamingScope"
                    }
                }
            };
        }
    }
}
