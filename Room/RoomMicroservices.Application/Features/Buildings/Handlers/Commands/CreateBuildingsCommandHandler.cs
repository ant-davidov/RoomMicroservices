using AutoMapper;
using MediatR;
using RoomMicroservices.Application.Contracts;
using RoomMicroservices.Application.DTOs.Buildings.Validators;
using RoomMicroservices.Application.Features.Buildings.Requests.Commands;
using RoomMicroservices.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.Features.Buildings.Handlers.Commands
{
    public class CreateBuildingsCommandHandler : IRequestHandler<CreateBuildingsCommand, Unit>
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;
        public CreateBuildingsCommandHandler(IBuildingRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateBuildingsCommand request, CancellationToken cancellationToken)
        {
            var validator = new BuildingDTOValidator();
            var validationResult = validator.Validate(request.CreateBuildingDTO);
            if (!validationResult.IsValid)
                Debug.WriteLine("CreateBuildingDTO is not valid");

            if(await _buildingRepository.GetByIdAsync(request.CreateBuildingDTO.Id) != null)
                Debug.WriteLine($"Building already exists with id {request.CreateBuildingDTO.Id}");

            var building = _mapper.Map<Building>(request.CreateBuildingDTO);
            await _buildingRepository.AddBuildingAsync(building);
            return Unit.Value;
        }
    }
}
