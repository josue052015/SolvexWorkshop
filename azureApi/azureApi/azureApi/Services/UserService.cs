using azureApi.Entities;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace azureApi.Services
{
    public class UserService
    {
        public async Task<ICollection<Users>> GetUsers()
        {
            IConfidentialClientApplication clientApplication = ConfidentialClientApplicationBuilder
                          .Create("ea56df0b-11e7-404e-b32a-3ee8c18bf101")
                          .WithTenantId("f8cdef31-a31e-4b4a-93e4-5f571e91255a")
                          .WithClientSecret("6rW.3X51mKoyHpK_uf2W~K1YroyFF.NFk2")
                           .Build();

            ClientCredentialProvider authProvider = new ClientCredentialProvider(clientApplication);
          //  ClientCredential authProvider = new ClientCredential("ea56df0b-11e7-404e-b32a-3ee8c18bf101", "6rW.3X51mKoyHpK_uf2W~K1YroyFF.NFk2");
            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            var responseData = await graphClient
                .Users
                .Request()
                .GetAsync();
            return (ICollection<Users>)responseData;
        } 
    }
}
