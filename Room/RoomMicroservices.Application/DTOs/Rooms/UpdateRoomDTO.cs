using RoomMicroservices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.DTOs.Rooms
{
    public class UpdateRoomDTO
    {
        public string Name { get; set; } = null!;
        public RoomType Type { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public string Number { get; set; } = null!;
    }
}
