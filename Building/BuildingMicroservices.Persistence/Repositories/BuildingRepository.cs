using BuildingMicroservices.Application.Contracts;
using BuildingMicroservices.Domain;
using BuildingMicroservices.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Persistence.Repositories
{
    internal class BuildingRepository : IBuildingRepository
    {
        private readonly BuildingDbContext _dbContext;

        public BuildingRepository(BuildingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  async Task<bool> NameAlreadyExistsAsync(string name, int id = -1)
        {
           return await  _dbContext.Buildings.AnyAsync(x => x.Name == name && x.Id != id); 
        }
        public async Task<List<Building>> GetAllBuildingsAsync()
        {
            return await _dbContext.Buildings.OrderBy(x=> x.Id).ToListAsync();
        }
        public async Task<Building> GetByIdAsync(int id)
        {
           return await _dbContext.Buildings.FirstOrDefaultAsync(b => b.Id == id);
            
        }

        public async Task AddBuildingAsync(Building building)
        {
            _dbContext.Buildings.Add(building);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateBuildingAsync(Building building)
        {
            _dbContext.Buildings.Update(building);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBuildingAsync(Building building)
        {
           
                _dbContext.Buildings.Remove(building);
                await _dbContext.SaveChangesAsync();
           
        }

        public IDbContextTransaction CreateTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }
    }
}
