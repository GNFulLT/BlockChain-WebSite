using Microsoft.OpenApi.Extensions;
using System;

namespace AuthenticationService.DiscoveryClient
{

    public enum StatusTypes
    {
        Starting = 0,
        Ready,
        Down
    }
    public static class DiscoveryClientStatus
    {
        private static string _status = nameof(StatusTypes.Starting);

        public static string CurrentStatus => _status;


        public static async Task SetStatusType(StatusTypes stype,IServiceProvider services,HttpClient client)
        {
            _status = stype.ToString();

            HttpRequestMessage msg = new();
            DiscoveryClientProvider service = (services.GetService(typeof(DiscoveryClientProvider)) as DiscoveryClientProvider)!;
            msg.RequestUri = new Uri($"{service.Config.EurekaAddress}eureka/apps/SERVICE/localhost");
            msg.Method = HttpMethod.Put;
            msg.Content = new StringContent(service.GetHeartBeat(),System.Text.Encoding.UTF8,"application/json");
#if DEBUG
            try
            {
                var res = await client.SendAsync(msg);
                var resStr = await res.Content.ReadAsStringAsync();
            }
            catch(Exception ex)
            {
                string s = ex.Message;
                
            }
#endif
        }

    }
}
