using RoomMicroservices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.Contracts
{
    public interface IBuildingRepository
    {
        public Task DeleteBuildingAsync(Building building);
        public Task<Building> GetByIdAsync(int id);
        public Task AddBuildingAsync(Building building);
        public Task UpdateBuildingAsync(Building building);     
    }
}
