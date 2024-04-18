using BuildingMicroservices.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Persistence.DbContexts
{
    internal class BuildingDbContext : DbContext
    {
        public BuildingDbContext(DbContextOptions<BuildingDbContext> options) : base(options) 
        {
            Database.Migrate();
        }
        public DbSet<Building> Buildings { get; set; }
    }

}
