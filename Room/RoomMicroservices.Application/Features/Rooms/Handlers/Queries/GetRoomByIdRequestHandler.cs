using AutoMapper;
using MediatR;
using RoomMicroservices.Application.Contracts;
using RoomMicroservices.Application.DTOs.Rooms;
using RoomMicroservices.Application.Exceptions;
using RoomMicroservices.Application.Features.Rooms.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.Features.Rooms.Handlers.Queries
{
    public class GetRoomByIdRequestHandler : IRequestHandler<GetRoomByIdRequest, RoomDTO>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public GetRoomByIdRequestHandler(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<RoomDTO> Handle(GetRoomByIdRequest request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException($"{request.Id}");
            return _mapper.Map<RoomDTO>(room);
        }
    }
}
