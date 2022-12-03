namespace AuthenticationService.DiscoveryClient
{
    public record DiscoveryClientConfig
    {
        virtual public string ClientName { get; set; }
        virtual public string EurekaAddress { get; set; }


        private static DiscoveryClientConfig _defaultConfig = new DiscoveryClientConfig("service","http://localhost:8761/");

        public static DiscoveryClientConfig DefaultConfig => _defaultConfig;
        public DiscoveryClientConfig(string clientName, string eurekaAddress)
        {
            ClientName = clientName;
            EurekaAddress = eurekaAddress;
        }
    }
}
