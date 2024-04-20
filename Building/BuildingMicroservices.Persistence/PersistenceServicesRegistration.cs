using BuildingMicroservices.Application.Contracts;
using BuildingMicroservices.Persistence.DbContexts;
using BuildingMicroservices.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            if (environment.IsDevelopment())
                services.AddDbContext<BuildingDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            else
                services.AddDbContext<BuildingDbContext>(options => options.UseNpgsql(Environment.GetEnvironmentVariable("DefaultConnectionBuildingDb")));
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            return services;
        }
    }
}
