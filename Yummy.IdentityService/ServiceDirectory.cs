using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Yummy.IdentityService
{
    public static class ServiceDirectory
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
                        new List<IdentityResource>
                        {
                            new IdentityResources.OpenId(),
                            new IdentityResources.Email(),
                            new IdentityResources.Profile()
                        };
        public static IEnumerable<ApiScope> ApiScopes =>
                        new List<ApiScope>
                        {
                            new ApiScope("yummyfood", "YummyFood Server"),
                            new ApiScope(name: "read", displayName: "Access for READ all Data"),
                            new ApiScope(name: "write", displayName: "Access for WRITE all Data"),
                            new ApiScope(name: "delete", displayName: "Access for DELETE all Data")
                        };
        public static IEnumerable<Client> Clients =>
                        new List<Client>
                        {
                            new Client
                            {
                                ClientId = "client-4B1B9",
                                ClientSecrets = { new Secret("F5869A3C985EB89C99356FA24B1B9".Sha256()) },
                                AllowedGrantTypes = GrantTypes.ClientCredentials,
                                AllowedScopes = { "read", "write", "profile" }
                            },
                            new Client
                            {
                                ClientId = "yummyfood-F5869",
                                ClientSecrets = { new Secret("F5869A3C985EB89C99356FA24B1B9".Sha256()) },
                                AllowedGrantTypes = GrantTypes.Code,
                                RedirectUris = { "https://localhost:7222/signin-oidc" },
                                PostLogoutRedirectUris = { "https://localhost:7222/signout-callback-oidc" },
                                AllowedScopes = new List<string>
                                {
                                    IdentityServerConstants.StandardScopes.OpenId,
                                    IdentityServerConstants.StandardScopes.Email,
                                    IdentityServerConstants.StandardScopes.Profile,
                                    "yummyfood"
                                }
                            }
                        };
    }
}
