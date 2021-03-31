using System.Collections.Generic;

namespace PartsPipelineer.Services.Tools.Extensions.Consul
{
    public class ConsulConfiguration
    {
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Url { get; set; }
        public List<string> Tags { get; set; }
        public string Port { get; set; }
        public string HealthCheckUrl { get; set; }
        public string Interval { get; set; }
        public string DeregisterAterTime { get; set; }
        public string ServiceRegisterUrl { get; set; }        
    }
}