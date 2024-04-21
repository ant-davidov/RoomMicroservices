using Microsoft.EntityFrameworkCore;
using RoomMicroservices.Application.Contracts;
using RoomMicroservices.Application.DTOs.Rooms;
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
        public async Task<Tuple<List<Room>, int>> SearchRoomsAsync(SearchRoomDTO searchRoomDTO)
        {
            var query = _dbContext.Rooms.AsQueryable();
            if (searchRoomDTO.BuildongId != null)
                query = query.Where(x => x.BuildingId == searchRoomDTO.BuildongId);
            if (searchRoomDTO.Floor != null)
                query = query.Where(x => x.Floor == searchRoomDTO.Floor);
            if (searchRoomDTO.RoomType != null)
                query = query.Where(x => x.Type == searchRoomDTO.RoomType);

            int totalCount = await query.CountAsync(); // Подсчитываем общее количество записей

            var list = await query.AsNoTracking()
                                  .OrderBy(x => x.BuildingId)
                                  .ThenBy(x => x.Id)
                                  .Skip(searchRoomDTO.Skip)
                                  .Take(searchRoomDTO.Size)
                                  .Include(x => x.Building)
                                  .ToListAsync();

            int pageCount = (int)Math.Ceiling((double)totalCount / searchRoomDTO.Size); // Вычисляем количество страниц

            return Tuple.Create(list, pageCount);


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
            return await _dbContext.Rooms.Include(x=>x.Building).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
