using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.DTOs.Rooms
{
    public class SearchRoomResponse
    {
        public List<RoomDTO> Rooms { get; set; }
        public int PageCount { get; set; }
    }
}
