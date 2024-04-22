using Microsoft.EntityFrameworkCore;
using RoomMicroservices.Application.Contracts;
using RoomMicroservices.Domain;
using RoomMicroservices.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Persistence.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly RoomDbContext _dbContext;
        public async Task<List<Building>> GetAllBuildingsAsyn()
        {
            return await _dbContext.Buildings.OrderBy(x=>x.Id).ToListAsync();
        }
        public BuildingRepository(RoomDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Building> GetByIdAsync(int id)
        {
            return await _dbContext.Buildings.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddBuildingAsync(Building building)
        {
            _dbContext.Buildings.Add(building);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteBuildingAsync(Building building)
        {
            _dbContext.Buildings.Remove(building);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateBuildingAsync(Building building)
        {
            _dbContext.Buildings.Update(building);
            await _dbContext.SaveChangesAsync();
        }
    }
}
