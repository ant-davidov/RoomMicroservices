using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Domain
{
    public class Room
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public Building? Building { get; set; }
        public string Name { get; set; } = null!;
        public RoomType Type { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public string Number { get; set; } = null!;

    }
    public enum RoomType
    {
        Lecture,
        Practice,
        Gym,
        Other
    }
}
