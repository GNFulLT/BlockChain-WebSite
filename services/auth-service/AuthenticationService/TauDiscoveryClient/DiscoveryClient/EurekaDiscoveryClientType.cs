using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TauDiscoveryClient.Interface;

namespace TauDiscoveryClient.DiscoveryClient
{
    internal class EurekaDiscoveryClientType : IDiscoveryClientType
    {
        internal override void Up(string port,HttpClient client)
        {
            var body = $@"
            {{
            ""instance"": {{
            ""hostName"": ""localhost"",
            ""app"": ""SERVICE"",
            ""vipAddress"": ""myservice"",
            ""secureVipAddress"": ""myservice"",
            ""ipAddr"": ""10.0.0.10"",
            ""status"": ""OK"",
            ""port"": {{
                ""$"": ""49354"",
                ""@enabled"": ""true""
            }},
            ""securePort"": {{
            ""$"": ""{port}"",
            ""@enabled"": ""true""
            }},
            ""healthCheckUrl"": ""http://localhost:{port}/healthcheck"",
            ""statusPageUrl"": ""http://localhost:{port}/status"",
            ""homePageUrl"": ""http://localhost:{port}"",
            ""dataCenterInfo"": {{
                ""@class"": ""com.netflix.appinfo.InstanceInfo$DefaultDataCenterInfo"",
                ""name"": ""MyOwn""
            }}
            }}
            }}";

            HttpRequestMessage msg = new();
            msg.Method = HttpMethod.Post;
            var uri = $"{Config.EurekaAddress}eureka/apps/{Config.ClientName}";
            msg.RequestUri = new Uri(uri);

            msg.Content = new StringContent(body, Encoding.UTF8, "application/json");
            msg.Headers.TryAddWithoutValidation("Accept", "application/json");

            try
            {
                var res = client.Send(msg);
                var strRes = res.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
