using AutoMapper;
using MediatR;
using RoomMicroservices.Application.Contracts;
using RoomMicroservices.Application.DTOs.Rooms;
using RoomMicroservices.Application.DTOs.Rooms.Validators;
using RoomMicroservices.Application.Exceptions;
using RoomMicroservices.Application.Features.Rooms.Requests.Commands;
using RoomMicroservices.Application.Features.Rooms.Requests.Queries;
using RoomMicroservices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.Features.Rooms.Handlers.Commands
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, RoomDTO>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;
        public CreateRoomCommandHandler(IRoomRepository roomRepository, IBuildingRepository buildingRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public async Task<RoomDTO> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateRoomDTOValidator();
            var validationResult = validator.Validate(request.CreateRoomDTO);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);
            var building = await _buildingRepository.GetByIdAsync(request.CreateRoomDTO.BuildingId) ?? throw new NotFoundException($"Not found building with id  {request.CreateRoomDTO.BuildingId} ");
            if (request.CreateRoomDTO.Floor > building.Floors)
                throw new ValidationException("There is no floor");
            var room = _mapper.Map<Room>(request.CreateRoomDTO);
            await _roomRepository.AddRoomAsync(room);
            return _mapper.Map<RoomDTO>(room);
        }
    }
}
