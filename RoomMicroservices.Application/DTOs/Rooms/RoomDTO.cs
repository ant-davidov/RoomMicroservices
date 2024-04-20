using RoomMicroservices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.DTOs.Rooms
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public string Name { get; set; }
        public RoomType Type { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public string Number { get; set; }
    }
}
