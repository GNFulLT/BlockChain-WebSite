using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TauDiscoveryClient.Interface
{
    internal abstract class IDiscoveryClientType
    {
        public TauDiscoveryClientConfig Config { get; set; }

        public IDiscoveryClientType()
        {
            Config = TauDiscoveryClientConfig.DefaultConfig;
        }
        public IDiscoveryClientType(TauDiscoveryClientConfig config)
        {
            Config = config;
        }

        internal abstract void Up(string port,HttpClient client);
    }
}
