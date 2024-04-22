using Microsoft.EntityFrameworkCore;
using RoomMicroservices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Persistence.DbContexts
{
    public class RoomDbContext : DbContext
    {
        public RoomDbContext(DbContextOptions<RoomDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.Migrate();
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Building> Buildings { get; set; }
    }
}
