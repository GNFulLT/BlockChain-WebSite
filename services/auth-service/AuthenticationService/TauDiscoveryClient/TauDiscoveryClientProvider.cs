using TauDiscoveryClient.Interface;

namespace AuthenticationService
{
    public class TauDiscoveryClientProvider
    {
        private HttpClient _httpClient;

        private IDiscoveryClientType? discoveryClient;
        public TauDiscoveryClientProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        internal void SetDiscoveryType(IDiscoveryClientType client)
        {
            discoveryClient = client;
        }

        internal void Up(string port)
        {

            discoveryClient.Up(port, _httpClient);
        }
    }
}
