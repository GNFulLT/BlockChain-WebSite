using AuthenticationService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TauDiscoveryClient.DiscoveryClient;

namespace TauDiscoveryClient
{
    public static class TauDiscoveryClientExtensions
    {

        public static void AddDiscoveryClient(this IServiceCollection service)
        {
            service.AddHttpClient<TauDiscoveryClientProvider>(conf =>
            {
                
            });
        }
        public static void UseEurekaDiscoveryClient(this WebApplication app)
        {
            var clientProv = app.Services.GetService<TauDiscoveryClientProvider>();
            if (clientProv is null)
                throw new Exception("Please Use AddDiscoveryClient in builder");
            var port = Environment.GetEnvironmentVariable("PORT");
            clientProv.SetDiscoveryType(new EurekaDiscoveryClientType());

            clientProv.Up(port);
        }
    }
}
