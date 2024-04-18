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
    public class RoomRepository : IRoomRepository
    {
        private readonly RoomDbContext _dbContext;
        public RoomRepository(RoomDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Room>> GetAllRoomsAsync()
        {
            return await _dbContext.Rooms.ToListAsync();
        }

        public async Task AddRoomAsync(Room room)
        {
            _dbContext.Rooms.Add(room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRoomAsync(Room room)
        {
            _dbContext.Rooms.Update(room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(Room room)
        {
            _dbContext.Rooms.Remove(room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Room> GetByIdAsync(int id)
        {
          return await _dbContext.Rooms.FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
