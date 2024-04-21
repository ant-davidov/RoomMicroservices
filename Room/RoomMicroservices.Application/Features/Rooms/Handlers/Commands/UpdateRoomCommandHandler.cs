using AutoMapper;
using MediatR;
using RoomMicroservices.Application.Contracts;
using RoomMicroservices.Application.DTOs.Rooms;
using RoomMicroservices.Application.DTOs.Rooms.Validators;
using RoomMicroservices.Application.Exceptions;
using RoomMicroservices.Application.Features.Rooms.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.Features.Rooms.Handlers.Commands
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, RoomDTO>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;
        public UpdateRoomCommandHandler(IRoomRepository roomRepository, IBuildingRepository buildingRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }
        public async Task<RoomDTO> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRoomDTOValidator();
            var validationResult = validator.Validate(request.RoomDTO);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var room = await _roomRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException($"{request.Id}");

            if (room.Floor != request.RoomDTO.Floor)
            {
                var building = await _buildingRepository.GetByIdAsync(room.BuildingId) ?? throw new NotFoundException($"Not found building with id  {room.BuildingId} ");
                if (request.RoomDTO.Floor > building.Floors)
                    throw new ValidationException("There is no floor");
            }

            room = _mapper.Map(request.RoomDTO, room);
            await _roomRepository.UpdateRoomAsync(room);
            return _mapper.Map<RoomDTO>(room);  

        }
    }
}
