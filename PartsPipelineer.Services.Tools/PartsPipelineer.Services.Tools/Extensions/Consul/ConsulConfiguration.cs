using System.Collections.Generic;

namespace PartsPipelineer.Services.Tools.Extensions.Consul
{
    public class ConsulConfiguration
    {
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Url { get; set; }
        public List<string> Tags { get; set; }
        public string ServiceHost { get; set; }
        public int ServicePort { get; set; }
        public string HealthCheckUrl { get; set; }
        public int Interval { get; set; }
        public int RemoveAfterInterval { get; set; }   
    }
}