using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            RabbitMqOptions args = new();
            if (environment.IsDevelopment())
                configuration.GetSection("RabbitMqOptions").Bind(args);
            else
            {
                args.Hostname = Environment.GetEnvironmentVariable("RABBITMQ_HOSTNAME")!;
                args.VirtualHost = Environment.GetEnvironmentVariable("RABBITMQ_VIRTUALHOST")!;
                args.Username = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME")!;
                args.Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD")!;
            }

            services.AddMassTransit(x =>
            {
                x.AddConsumer<BuildingConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(args.Hostname, args.VirtualHost, h => {
                        h.Username(args.Username);
                        h.Password(args.Password);
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });
            return services;
        }
    }
}
