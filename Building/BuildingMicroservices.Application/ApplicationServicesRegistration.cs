﻿using BuildingMicroservices.Application.DTOs;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            RabbitMqOptions args = new ();
            if (environment.IsDevelopment())
                configuration.GetSection("RabbitMqOptions").Bind(args);
            else
            {
                args.Hostname = Environment.GetEnvironmentVariable("RABBITMQ_HOSTNAME")!;
                args.VirtualHost = Environment.GetEnvironmentVariable("RABBITMQ_VIRTUALHOST")!;
                args.Username = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME")!;
                args.Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD")!;
            }
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(args.Hostname, args.VirtualHost, h =>
                    {
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
