using RoomMicroservices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.DTOs.Rooms
{
    public class SearchRoomDTO
    {
        public int? BuildongId { get; set; }
        public int? Floor { get; set; }  
        public RoomType? RoomType { get; set; }
        public int Skip { get; set; }
        public int Size { get; set; }
    }
}
