using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerSample
{
    public class IdentityConfiguration
    {
        //public static IEnumerable<ApiResource> GetApiResource()
        //{
        //    return new List<ApiResource>
        //    {
        //        new ApiResource("myresourceapi", "My Resource API")
        //        {
        //            //Scopes =  {new Scope ("apiscope")}
        //            Scopes = new List<string> {"api1.read"}
        //        }
        //    };
        //}


        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "api1",
                    DisplayName = "API #1",
                    Description = "Allow the application to access API #1 on your behalf",
                    Scopes = new List<string> {"api1.read", "api1.write"},
                    ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
            {
                return new[]
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                    new IdentityResources.Email(),
                    new IdentityResource
                    {
                        Name = "role",
                        UserClaims = new List<string> {"role"}
                    }
                };
            }


        //This is a list of clients registered on identity server,
        //so that identity server can know the clients that are allowed to use it.
        public static IEnumerable<Client> GetClients()
        {

            return new List<Client>
            {
                new Client
                {
                    ClientId = "oauthClient",
                    ClientName = "Example client application using client credentials",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, // change me!
                    AllowedScopes = new List<string> {"api1.read"}
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
            new ApiScope("api1.read", "Read Access to API #1"),
            new ApiScope("api1.write", "Write Access to API #1")
            };
        }
    }
}
