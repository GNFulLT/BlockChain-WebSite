using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TauDiscoveryClient
{
    public class TauDiscoveryClientConfig
    {
        virtual public string ClientName { get; set; }
        virtual public string EurekaAddress { get; set; }


        private static TauDiscoveryClientConfig _defaultConfig = new TauDiscoveryClientConfig("service", "http://localhost:8761/");

        public static TauDiscoveryClientConfig DefaultConfig => _defaultConfig;
        public TauDiscoveryClientConfig(string clientName, string eurekaAddress)
        {
            ClientName = clientName;
            EurekaAddress = eurekaAddress;
        }
    }
}
