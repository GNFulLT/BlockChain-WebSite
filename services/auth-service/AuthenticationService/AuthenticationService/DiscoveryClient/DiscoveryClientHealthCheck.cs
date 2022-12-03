namespace AuthenticationService.DiscoveryClient
{
    public static class DiscoveryClientHealthCheck
    {
        public static string GetHealth()
        {
            return ($@"
                    {{
                        ""status"" : $""{DiscoveryClientStatus.CurrentStatus}"" 
                    }}
            ");
        }
    }
}
