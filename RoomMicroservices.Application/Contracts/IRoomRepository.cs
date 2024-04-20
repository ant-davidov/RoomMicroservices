using RoomMicroservices.Application.DTOs.Rooms;
using RoomMicroservices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.Contracts
{
    public interface IRoomRepository
    {
        Task<Room> GetByIdAsync(int id);
        Task<Tuple<List<Room>, int>> SearchRoomsAsync(SearchRoomDTO searchRoomDTO);
        Task AddRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task DeleteRoomAsync(Room room);
    }
}
