﻿using MediatR;
using RoomMicroservices.Application.DTOs.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.Features.Rooms.Requests.Queries
{
    public class GetRoomByIdRequest : IRequest<RoomDTO>
    {
        public int Id { get; set; }
    }
}
