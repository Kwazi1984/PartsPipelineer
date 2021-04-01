using System;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PartsPipelineer.Services.Tools.Extensions.Consul
{
    public static class Extension
    {
        public static IServiceCollection AddConsul(this IServiceCollection services, IConfiguration configuration)
        {
            var consulConfiguration = configuration.GetSection("Consul").Get<ConsulConfiguration>();

            services.AddSingleton(consulConfiguration);

            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                consulConfig.Address = new Uri(consulConfiguration.Url);
            }));

            return services;     
        }

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app)
        {          
            var consul = app.ApplicationServices.GetRequiredService<IConsulClient>();           
            var consulConfig = app.ApplicationServices.GetService<ConsulConfiguration>();    
            var applifetime =   app.ApplicationServices.GetService<IHostApplicationLifetime>();    
            
            Guid serviceId = Guid.NewGuid();

            string consulServiceID = $"{consulConfig.ServiceName}:{serviceId}";

            var registration = new AgentServiceRegistration()
            {
                ID = consulServiceID,
                Name = consulConfig.ServiceName,
                Address = consulConfig.ServiceHost,
                Port = consulConfig.ServicePort  
            };

            var check = new AgentServiceCheck
            {
                Interval = TimeSpan.FromSeconds(consulConfig.Interval),
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(consulConfig.RemoveAfterInterval),
                HTTP = consulConfig.HealthCheckUrl
            };
            registration.Checks = new[] {check};

            consul.Agent.ServiceRegister(registration).ConfigureAwait(true);

            applifetime.ApplicationStopping.Register(() =>
            {
                consul.Agent.ServiceDeregister(consulServiceID);
            });

            return app;                  
        }

    }
}