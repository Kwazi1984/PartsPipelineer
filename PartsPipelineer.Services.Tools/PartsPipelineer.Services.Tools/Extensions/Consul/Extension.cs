using System;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            
            var consulClient = app.ApplicationServices.GetService<ConsulConfiguration>();
            
            using (var scope = app.ApplicationServices.CreateScope())
            {
                // var configuration = scope.ServiceProvider.GetService<IConfiguration>();

                // //var config = configuration.Bind(<ConsulConfiguration>("Consul");

                // var consulServiceRistration = new AgentServiceRegistration
                // {
                //     Name = config.Service,
                //     ID = consulServiceID,
                //     Address = config.Address,
                //     Port = config.Port
                // };

                return app;
            }  
                  
        }

    }
}