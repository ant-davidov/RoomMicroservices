using BuildingMicroservices.Domain;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Application.Contracts
{
    public interface IBuildingRepository
    {
        public Task<bool> NameAlreadyExistsAsync(string name, int id = -1);
        IDbContextTransaction CreateTransaction();
        Task<Building> GetByIdAsync(int id);
        Task<List<Building>> GetAllBuildingsAsync();
        Task AddBuildingAsync(Building building);
        Task UpdateBuildingAsync(Building building);
        Task DeleteBuildingAsync(Building building);
    }
}
