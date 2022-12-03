using System.Text.Json;

namespace AuthenticationService.DiscoveryClient
{
    public class DiscoveryClientBuilder : ServiceDescriptor
    {

        public DiscoveryClientBuilder(HttpClient client,DiscoveryClientConfig config ) : base(typeof(DiscoveryClientProvider),new DiscoveryClientProvider(client,config))
        {

           
        }

    }
}
