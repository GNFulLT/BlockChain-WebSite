namespace AuthenticationService.DiscoveryClient
{
    public static class DiscoveryClientExtensions
    {
        public static IServiceCollection AddEurekaClient
        (this IServiceCollection services,HttpClient client, DiscoveryClientConfig? config = null)
        {
            if(config == null)
            {
                services.Add(new DiscoveryClientBuilder(client, DiscoveryClientConfig.DefaultConfig));
                return services;
            }
            services.Add(new DiscoveryClientBuilder(client, config));
            return services;
        }
    }
}
