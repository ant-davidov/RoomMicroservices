using AutoMapper;
using RoomMicroservices.Application.DTOs.Buildings;
using RoomMicroservices.Application.DTOs.Rooms;
using RoomMicroservices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.Profiles
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBuildingDTO, Building>();

            CreateMap<CreateRoomDTO, Room>();
            CreateMap<UpdateRoomDTO, Room>();
            CreateMap<Room, RoomDTO>();
        }
    }
}
