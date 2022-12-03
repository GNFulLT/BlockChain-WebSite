using Grpc.Core;
using Newtonsoft.Json;
using Steeltoe.Discovery.Eureka.AppInfo;
using System.Text;
using System.Xml.Linq;

namespace AuthenticationService.DiscoveryClient
{
    public class DiscoveryClientProvider 
    {
        HttpClient _client;
        DiscoveryClientConfig _config;

        public DiscoveryClientConfig Config => _config;

        ~DiscoveryClientProvider()
        {
            HttpRequestMessage msg = new();
            msg.Method = HttpMethod.Delete;
            var uri = $"{_config.EurekaAddress}eureka/apps/{_config.ClientName}/localhost";
            msg.RequestUri = new Uri(uri);
            _client.Send(msg);
        }
        public DiscoveryClientProvider(HttpClient client, DiscoveryClientConfig config)
        {
            _client = client;
            _config = config;
            HttpRequestMessage msg = new();
            msg.Method = HttpMethod.Post;
            var uri = $"{_config.EurekaAddress}eureka/apps/{_config.ClientName}";
            msg.RequestUri = new Uri(uri);
           
            var body = $@"
            {{
            ""instance"": {{
            ""hostName"": ""localhost"",
            ""app"": ""SERVICE"",
            ""vipAddress"": ""myservice"",
            ""secureVipAddress"": ""myservice"",
            ""ipAddr"": ""10.0.0.10"",
            ""status"": ""{DiscoveryClientStatus.CurrentStatus}"",
            ""port"": {{
                ""$"": ""49354"",
                ""@enabled"": ""true""
            }},
            ""securePort"": {{
            ""$"": ""44374"",
            ""@enabled"": ""true""
            }},
            ""healthCheckUrl"": ""http://localhost:44374/healthcheck"",
            ""statusPageUrl"": ""http://localhost:44374/status"",
            ""homePageUrl"": ""http://localhost:44374"",
            ""dataCenterInfo"": {{
                ""@class"": ""com.netflix.appinfo.InstanceInfo$DefaultDataCenterInfo"",
                ""name"": ""MyOwn""
            }}
            }}
            }}";
            
            msg.Content = new StringContent(body, Encoding.UTF8,"application/json");
            msg.Headers.TryAddWithoutValidation("Accept", "application/json");

            try 
            { 
                var res = _client.Send(msg);
                var strRes = res.Content.ReadAsStringAsync().Result;
            }
            catch(Exception ex)
            {

            }
            /*if (!res.IsSuccessStatusCode)
            {
                throw new Exception("couldn't register to the eureka server");
            }
            */
        }

        public string GetHeartBeat()
        {
            return $@"
            {{
            ""instance"": {{
            ""hostName"": ""localhost"",
            ""app"": ""SERVICE"",
            ""vipAddress"": ""myservice"",
            ""secureVipAddress"": ""myservice"",
            ""ipAddr"": ""10.0.0.10"",
            ""status"": ""{DiscoveryClientStatus.CurrentStatus}"",
            ""port"": {{
                ""$"": ""49354"",
                ""@enabled"": ""true""
            }},
            ""securePort"": {{
            ""$"": ""44374"",
            ""@enabled"": ""true""
            }},
            ""healthCheckUrl"": ""http://localhost:44374/healthcheck"",
            ""statusPageUrl"": ""http://localhost:44374/status"",
            ""homePageUrl"": ""http://localhost:44374"",
            ""dataCenterInfo"": {{
                ""@class"": ""com.netflix.appinfo.InstanceInfo$DefaultDataCenterInfo"",
                ""name"": ""MyOwn""
            }}
            }}
            }}";
        }
    
    }
}
