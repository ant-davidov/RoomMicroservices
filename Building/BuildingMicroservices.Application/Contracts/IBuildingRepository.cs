using BuildingMicroservices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Application.Contracts
{
    public interface IBuildingRepository
    {
        Task<Building> GetByIdAsync(int id);
        Task<List<Building>> GetAllBuildingsAsync();
        Task AddBuildingAsync(Building building);
        Task UpdateBuildingAsync(Building building);
        Task DeleteBuildingAsync(Building building);
    }
}
