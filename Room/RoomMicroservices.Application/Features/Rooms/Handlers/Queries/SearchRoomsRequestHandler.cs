using AutoMapper;
using MediatR;
using RoomMicroservices.Application.Contracts;
using RoomMicroservices.Application.DTOs.Rooms;
using RoomMicroservices.Application.DTOs.Rooms.Validators;
using RoomMicroservices.Application.Exceptions;
using RoomMicroservices.Application.Features.Rooms.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.Features.Rooms.Handlers.Queries
{
    public class SearchRoomsRequestHandler : IRequestHandler<SearchRoomsRequest, SearchRoomResponse>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public SearchRoomsRequestHandler(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }
        public async Task<SearchRoomResponse> Handle(SearchRoomsRequest request, CancellationToken cancellationToken)
        {
            var validator = new SearchRoomDTOValidator();
            var validationResult = validator.Validate(request.SearchRoomDTO);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);
           
            var roomTuple = await _roomRepository.SearchRoomsAsync(request.SearchRoomDTO);
            var roomDTO =   _mapper.Map<List<RoomDTO>>(roomTuple.Item1);
            return new SearchRoomResponse { Rooms =  roomDTO, PageCount = roomTuple.Item2};
        }
    }
}
