using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RoomMicroservices.Application.Contracts;
using RoomMicroservices.Persistence.DbContexts;
using RoomMicroservices.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            if (environment.IsDevelopment())
                services.AddDbContext<RoomDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            else
                services.AddDbContext<RoomDbContext>(options => options.UseNpgsql(Environment.GetEnvironmentVariable("DockerConnectionRoomDb")));
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            return services;
        }

    }
}
