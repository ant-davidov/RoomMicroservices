using AutoMapper;
using MediatR;
using RoomMicroservices.Application.Contracts;
using RoomMicroservices.Application.DTOs.Rooms;
using RoomMicroservices.Application.Features.Rooms.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.Features.Rooms.Handlers.Queries
{
    public class GetAllRoomRequestHendler : IRequestHandler<GetAllRoomsRequest, List<RoomDTO>>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public GetAllRoomRequestHendler(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }
        public async Task<List<RoomDTO>> Handle(GetAllRoomsRequest request, CancellationToken cancellationToken)
        {
            var roomList = await _roomRepository.GetAllRoomsAsync();
            return _mapper.Map<List<RoomDTO>>(roomList);
        }
    }
}
